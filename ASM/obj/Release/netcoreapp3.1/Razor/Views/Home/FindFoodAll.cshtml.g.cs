#pragma checksum "D:\HK_Summer_2021\Block_1\Lap_trinh_C#5\PS13663_PhamLyHung_UC15302_AsmFinal\ASM\ASM\Views\Home\FindFoodAll.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "499ef563bab5423d489631006da8c4a3089d0ab0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_FindFoodAll), @"mvc.1.0.view", @"/Views/Home/FindFoodAll.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\HK_Summer_2021\Block_1\Lap_trinh_C#5\PS13663_PhamLyHung_UC15302_AsmFinal\ASM\ASM\Views\_ViewImports.cshtml"
using ASM;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\HK_Summer_2021\Block_1\Lap_trinh_C#5\PS13663_PhamLyHung_UC15302_AsmFinal\ASM\ASM\Views\_ViewImports.cshtml"
using ASM.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"499ef563bab5423d489631006da8c4a3089d0ab0", @"/Views/Home/FindFoodAll.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"de453dc6ef1879827b9c87cbe9f0cf8e206f5ca6", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_FindFoodAll : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ASM.Models.Food>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/busy.gif"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("display:none"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\HK_Summer_2021\Block_1\Lap_trinh_C#5\PS13663_PhamLyHung_UC15302_AsmFinal\ASM\ASM\Views\Home\FindFoodAll.cshtml"
  
    Layout = "~/Views/Shared/_WebLayout.cshtml";
    ViewData["Title"] = "Tìm kiếm món ăn";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<style>
    .list-product {
        margin: auto;
        display: flex;
        flex-wrap: wrap;
    }

    .product {
        margin-top: 10px;
        margin-right: 10px;
        width: 205px;
    }

    .img {
        width: 150px;
        height: 150px;
        margin: auto;
    }

    .title {
        color: #0e0e0e;
        font-size: 15px;
        font-weight: bold;
        text-align: center;
    }

    .field-price {
        font-size: 24px;
        color: #d50000;
        margin-bottom: 15px;
        font-weight: 700;
        text-align: center;
    }

    .viewProduct, .addProduct {
        border: 0;
        font-weight: 700;
        padding: 9px 5px;
        background: #ffd800;
        -webkit-border-radius: 5px;
        -moz-border-radius: 5px;
        border-radius: 5px;
        margin: 0 auto;
        color: #0e0e0e;
    }
    .addProduct:hover{
        background-color:cyan;
    }
");
            WriteLiteral("</style>\r\n\r\n<div class=\"text-center\">\r\n    <p class=\"display-4 h2 mt-2 font-weight-bold text-warning\">Món ăn được tìm kiếm</p>\r\n</div>\r\n<div class=\"container\">\r\n    <div class=\"row\">\r\n");
#nullable restore
#line 66 "D:\HK_Summer_2021\Block_1\Lap_trinh_C#5\PS13663_PhamLyHung_UC15302_AsmFinal\ASM\ASM\Views\Home\FindFoodAll.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"col-lg-3 col-md-3 col-sm-6 col-xs-12\">\r\n                <div class=\"box card\">\r\n                    <div class=\"box cardImg\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "499ef563bab5423d489631006da8c4a3089d0ab05872", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1578, "~/images/food/", 1578, 14, true);
#nullable restore
#line 71 "D:\HK_Summer_2021\Block_1\Lap_trinh_C#5\PS13663_PhamLyHung_UC15302_AsmFinal\ASM\ASM\Views\Home\FindFoodAll.cshtml"
AddHtmlAttributeValue("", 1592, item.Image, 1592, 11, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"info\">\r\n                        <span class=\"title\">");
#nullable restore
#line 74 "D:\HK_Summer_2021\Block_1\Lap_trinh_C#5\PS13663_PhamLyHung_UC15302_AsmFinal\ASM\ASM\Views\Home\FindFoodAll.cshtml"
                                       Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                        <div class=\"field-price\">");
#nullable restore
#line 75 "D:\HK_Summer_2021\Block_1\Lap_trinh_C#5\PS13663_PhamLyHung_UC15302_AsmFinal\ASM\ASM\Views\Home\FindFoodAll.cshtml"
                                            Write(item.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                        <a class=\"addProduct\"");
            BeginWriteAttribute("href", " href=\"", 1853, "\"", 1893, 3);
            WriteAttributeValue("", 1860, "javascript:addCart(", 1860, 19, true);
#nullable restore
#line 76 "D:\HK_Summer_2021\Block_1\Lap_trinh_C#5\PS13663_PhamLyHung_UC15302_AsmFinal\ASM\ASM\Views\Home\FindFoodAll.cshtml"
WriteAttributeValue("", 1879, item.FoodID, 1879, 12, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1891, ");", 1891, 2, true);
            EndWriteAttribute();
            WriteLiteral(" style=\"text-decoration:none\">\r\n                            <i class=\"fas fa-cart-plus\"></i> Thêm ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "499ef563bab5423d489631006da8c4a3089d0ab08853", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "id", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2001, "imgBusy_", 2001, 8, true);
#nullable restore
#line 77 "D:\HK_Summer_2021\Block_1\Lap_trinh_C#5\PS13663_PhamLyHung_UC15302_AsmFinal\ASM\ASM\Views\Home\FindFoodAll.cshtml"
AddHtmlAttributeValue("", 2009, item.FoodID, 2009, 12, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </a>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 82 "D:\HK_Summer_2021\Block_1\Lap_trinh_C#5\PS13663_PhamLyHung_UC15302_AsmFinal\ASM\ASM\Views\Home\FindFoodAll.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </div>
</div>

<script>
    function addCart(id) {
        $(""#imgCart"").attr(""src"", '/images/cartA.png');
        $(""#imgBusy_"" + id).show();
        setTimeout(function () {
            $.ajax({
                url: ""/Home/AddCart?Id="" + id,
                type: ""Post"",
                success: function (result) {
                    //alert(result);
                },
                error: function (e) {
                    alert(this.url);
                }
            });
            $(""#imgBusy_"" + id).hide();
        }, 500);
    }
</script>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ASM.Models.Food>> Html { get; private set; }
    }
}
#pragma warning restore 1591
