using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASM.Helpers;
using ASM.Interfaces;
using ASM.Models;
using ASM.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ASM
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDistributedMemoryCache(); // Đăng ký dịch vụ lưu cache trong bộ nhớ (Session sẽ sử dụng nó))

            services.AddSession(option => { option.IdleTimeout = TimeSpan.FromMinutes(30); });

            services.AddDbContext<DataContext>(options => options.UseSqlServer(
                Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IEncodeHelper, EncodeHelper>();

            services.AddTransient<IUploadHelper, UploadHelper>();

            services.AddTransient<IFoodSvc, FoodSvc>();

            services.AddTransient<IUserSvc, UserSvc>();

            services.AddTransient<ICustomerSvc, CustomerSvc>();

            services.AddTransient<IOrderSvc, OrderSvc>();

            services.AddTransient<IOrderDetailSvc, OrderDetailSvc>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
