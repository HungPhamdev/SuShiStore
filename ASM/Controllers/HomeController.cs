using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ASM.Models;
using ASM.Interfaces;
using ASM.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using ASM.Models.ViewModels;
using Newtonsoft.Json;
using ASM.Filters;

namespace ASM.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IWebHostEnvironment _webHostEnvironment;
        private IFoodSvc _foodSvc;
        private ICustomerSvc _customerSvc;
        private IOrderSvc _orderSvc;
        private IOrderDetailSvc _orderDetailSvc;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment webHostEnvironment, 
            IFoodSvc foodSvc, IOrderSvc orderSvc, ICustomerSvc customerSvc, IOrderDetailSvc orderDetailSvc)
        {
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
            _foodSvc = foodSvc;
            _customerSvc = customerSvc;
            _orderSvc = orderSvc;
            _orderDetailSvc = orderDetailSvc;
        }

        public IActionResult Foods()
        {
            return View(_foodSvc.GetFoodAll_Foods());
        }

        public IActionResult Combos()
        {
            return View(_foodSvc.GetFoodAll_Combos());
        }

        public IActionResult Waters()
        {
            return View(_foodSvc.GetFoodAll_Waters());
        }

        public IActionResult Index()
        {
            return View(_foodSvc.GetFoodAll());
        }

        public IActionResult FindFoodAll()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FindFoodAll(string nameFood)
        {
            if (nameFood != null && nameFood != "")
            {
                return View(_foodSvc.FindFoodAll(nameFood));
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AddCart(int id)
        {
            var cart = HttpContext.Session.GetString("cart");// get key cart
            if (cart == null)
            {
                var food = _foodSvc.GetFood(id);
                List<ViewCart> listCart = new List<ViewCart>()
                {
                    new ViewCart
                    {
                        Food=food,
                        Quantity=1
                    }
                };
                HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(listCart));
            }
            else
            {
                List<ViewCart> dataCart = JsonConvert.DeserializeObject<List<ViewCart>>(cart);
                bool check = true;
                for(int i = 0; i < dataCart.Count; i++)
                {
                    if (dataCart[i].Food.FoodID == id)
                    {
                        dataCart[i].Quantity++;
                        check = false;
                    }
                }
                if (check)
                {
                    var food = _foodSvc.GetFood(id);
                    dataCart.Add(new ViewCart
                    {
                        Food = food,
                        Quantity = 1
                    });
                }
                HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(dataCart));
            }
            return Ok();
        }

        public IActionResult Cart()
        {
            List<ViewCart> dataCart = new List<ViewCart>();
            var cart = HttpContext.Session.GetString("cart"); // get key cart
            if (cart != null)
            {
                dataCart = JsonConvert.DeserializeObject<List<ViewCart>>(cart);
            }
            return View(dataCart);
        }

        [HttpPost]
        public IActionResult UpdateCart(int id, int quantity) 
        {
            var cart = HttpContext.Session.GetString("cart");
            double total = 0;
            if (cart != null)
            {
                List<ViewCart> dataCart = JsonConvert.DeserializeObject<List<ViewCart>>(cart);
                for(int i = 0; i < dataCart.Count; i++)
                {
                    if (dataCart[i].Food.FoodID == id)
                    {
                        dataCart[i].Quantity = quantity;
                        break;
                    }
                }
                HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(dataCart));
                total = TotalMoney();
                return Ok(total);
            }
            return BadRequest();
        }

        [HttpPost]
        public IActionResult DeleteCart(int id) 
        {
            var cart = HttpContext.Session.GetString("cart");
            double total = 0;
            if (cart != null)
            {
                List<ViewCart> dataCart = JsonConvert.DeserializeObject<List<ViewCart>>(cart);
                for (int i = 0; i < dataCart.Count; i++)
                {
                    if (dataCart[i].Food.FoodID == id)
                    {
                        dataCart.RemoveAt(i);
                    }
                }
                HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(dataCart));
                total = TotalMoney();
                return Ok(total);
            }
            return BadRequest();
        }

        [AuthenticationFilterAttribute_Cus]
        [HttpPost]
        public IActionResult OrderCart() 
        {
            string kH_Email=HttpContext.Session.GetString(SessionKey.Customer.Cus_FullName);
            if (kH_Email == null || kH_Email == "") // there was session
            {
                return BadRequest();
            }
            var cart = HttpContext.Session.GetString("cart");
            if (cart != null && cart.Count() > 0)
            {
                #region Order
                var customerContext = HttpContext.Session.GetString(SessionKey.Customer.CustomerContext);
                var customerId = JsonConvert.DeserializeObject<Customer>(customerContext).CustomerID;
                double total = TotalMoney();
                var order = new Order()
                {
                    Status = OrderStatus.NewOrdered,
                    CustomerID = customerId,
                    TotalMoney = total,
                    OrderDate = DateTime.Now,
                    Note = ""
                };

                _orderSvc.AddOrder(order);
                int orderId = order.OrderID;

                #region Detail
                List<ViewCart> dataCart = JsonConvert.DeserializeObject<List<ViewCart>>(cart);
                for (int i=0; i < dataCart.Count; i++)
                {
                    OrderDetail detail = new OrderDetail()
                    {
                        OrderID = orderId,
                        FoodID = dataCart[i].Food.FoodID,
                        Quantity = dataCart[i].Quantity,
                        IntoMoney = dataCart[i].Food.Price * dataCart[i].Quantity,
                        Note = ""
                    };
                    _orderDetailSvc.AddOrderDetail(detail);
                }
                #endregion
                #endregion
                HttpContext.Session.Remove("cart");
                return Ok();
            }
            return BadRequest();
        }

        [NonAction]
        private double TotalMoney()
        {
            double total = 0;
            var cart = HttpContext.Session.GetString("cart");
            if (cart != null)
            {
                List<ViewCart> dataCart = JsonConvert.DeserializeObject<List<ViewCart>>(cart);
                for(int i = 0; i < dataCart.Count; i++)
                {
                    total += (dataCart[i].Food.Price * dataCart[i].Quantity);
                }                
            }
            return total;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #region Login - Logout - Regiter
        public IActionResult Login(string returnUrl)
        {
            string kH_Email = HttpContext.Session.GetString(SessionKey.Customer.Cus_FullName);
            if (kH_Email != null && kH_Email != "")// đã có session
            {
                return RedirectToAction("Index", "Home");
            }

            #region Display login
            ViewWebLogin login = new ViewWebLogin();
            login.ReturnUrl = returnUrl;
            return View(login);
            #endregion
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(ViewWebLogin viewWebLogin)
        {
            if (ModelState.IsValid)
            {
                Customer customer = _customerSvc.Login(viewWebLogin);
                if (customer != null)
                {
                    HttpContext.Session.SetString(SessionKey.Customer.Cus_Email, customer.Email);
                    HttpContext.Session.SetString(SessionKey.Customer.Cus_FullName, customer.FullName);
                    HttpContext.Session.SetString(SessionKey.Customer.CustomerContext, 
                        JsonConvert.SerializeObject(customer));

                    return RedirectToAction(nameof(HomeController.Index), "Home");
                }
            }
            return View(viewWebLogin);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
             HttpContext.Session.Remove(SessionKey.Customer.Cus_Email);
             HttpContext.Session.Remove(SessionKey.Customer.Cus_FullName);
             HttpContext.Session.Remove(SessionKey.Customer.CustomerContext);
             return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Customer customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //var check = _dataContext.Users.FirstOrDefault(x => x.Email == user.Email);
                    //if (check == null)
                    //{
                    if (!_customerSvc.CheckEmail(customer.Email))
                    {
                        _customerSvc.AddCustomer(customer);
                        return RedirectToAction(nameof(Login), new { id = customer.CustomerID });
                    }
                    else
                    {
                        ViewBag.Error = "Email đã tồn tại vui lòng nhập email khác";
                    }
                    //}  
                }
                return View();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }
        #endregion

        #region Info + History order
        [AuthenticationFilterAttribute_Cus]
        public ActionResult Info()
        {
            string kH_Email = HttpContext.Session.GetString(SessionKey.Customer.Cus_FullName);
            if(kH_Email == null || kH_Email == "") // Đã có session
            {
                return RedirectToAction("Index", "Home");
            }
            var customerContext = HttpContext.Session.GetString(SessionKey.Customer.CustomerContext);
            var customerId = JsonConvert.DeserializeObject<Customer>(customerContext).CustomerID;
            var customer = _customerSvc.GetCustomer(customerId);
            return View(customer);
        }

        [AuthenticationFilterAttribute_Cus]
        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Info(int customerID, Customer customer)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                    _customerSvc.EditCustomer(customerID, customer);
                    return RedirectToAction(nameof(Index), new { id = customer.CustomerID});
                //}
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return RedirectToAction(nameof(Index));
        }

        [AuthenticationFilterAttribute_Cus]
        public ActionResult Details(int id)
        {
            return View(_orderSvc.GetOrder(id));
        }

        [AuthenticationFilterAttribute_Cus]
        public IActionResult History()
        { 
            string kH_Email = HttpContext.Session.GetString(SessionKey.Customer.Cus_FullName);
            var customerContext = HttpContext.Session.GetString(SessionKey.Customer.CustomerContext);
            var customerID = JsonConvert.DeserializeObject<Customer>(customerContext).CustomerID;
            // Lấy id của Khách hàng khi khách hàng đã đăng nhập
            if (kH_Email==null||kH_Email=="") // Đã có session
            {
                return RedirectToAction("Index", "Home");
            }            
            return View(_orderSvc.GetOrderbyCustomer(customerID));


            // sai ne2, goi ham kia va lay id khach hang truyen vo,  ok nha
            // nhac cac ban nha, co nhieu ban cung sai loi nay
        }
        #endregion
    }
}
