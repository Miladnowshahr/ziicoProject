#pragma checksum "C:\Users\Milad\source\repos\Zicco\ziicoProject\ECommerce\Ecommerce\ECommerce.Presentation.Web\Views\Order\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "372c502f8f779fe74c5012cddcf3f147961c90c4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_Index), @"mvc.1.0.view", @"/Views/Order/Index.cshtml")]
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
#line 2 "C:\Users\Milad\source\repos\Zicco\ziicoProject\ECommerce\Ecommerce\ECommerce.Presentation.Web\Views\_ViewImports.cshtml"
using ECommerce.Models.ViewModels.BrandVM;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"372c502f8f779fe74c5012cddcf3f147961c90c4", @"/Views/Order/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"097e816b3b4cadd60a0ffdf48b7dda2520f5bb3e", @"/Views/_ViewImports.cshtml")]
    public class Views_Order_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/Order/Order.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("order-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\Milad\source\repos\Zicco\ziicoProject\ECommerce\Ecommerce\ECommerce.Presentation.Web\Views\Order\Index.cshtml"
  
    ViewData["Title"] = "ثبت سفارش";
    Layout = "~/Views/shared/_CUILayout.cshtml";


#line default
#line hidden
#nullable disable
            DefineSection("Styles", async() => {
                WriteLiteral("\r\n\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "372c502f8f779fe74c5012cddcf3f147961c90c44745", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
            WriteLiteral("\r\n<div class=\"panel wide-wrap\">\r\n    <h1 class=\"panel__title\">ثبت سفارش</h1>\r\n    <div class=\"panel__content\">\r\n        <div class=\"order-summary\">\r\n            <p class=\"order-summary__text\">مبلغ قابل پرداخت: 400,000 </p>\r\n            <a");
            BeginWriteAttribute("href", " href=\"", 420, "\"", 427, 0);
            EndWriteAttribute();
            WriteLiteral(" class=\"button\"><span class=\"button-text\">سبد خرید</span></a>\r\n        </div>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "372c502f8f779fe74c5012cddcf3f147961c90c46470", async() => {
                WriteLiteral(@"
            <section class=""order-form__section"">
                <h2 class=""order-form__header"">اطلاعات تماس</h2>
                <div class=""order-form__content"">
                    <div class=""order-form__group"">
                        <label class=""order-form__label"" for=""txtProvince"">استان : </label>
                        <div class=""order-form__field"">
                        <input class=""order-form__input"" id=""txtProvince"" name=""Province"" />
                        <span class=""order-form__validation order-form__validation--show mdi mdi-alert-circle-outline"">درج استان الزامی می باشد</span>
                        </div>
                    </div>

                    <div class=""order-form__group"">
                        <label class=""order-form__label"" for=""txtCity"">شهر : </label>
                        <div class=""order-form__field"">
                            <input class=""order-form__input"" id=""txtCity"" name=""city"" />
                            <span class=""order-form__val");
                WriteLiteral(@"idation order-form__validation--show mdi mdi-alert-circle-outline"">درج استان الزامی می باشد</span>

                        </div>
                    </div>

                    <div class=""order-form__group"">
                        <label class=""order-form__label"" for=""txtAddress"">آدرس : </label>
                        <div class=""order-form__field"">
                            <textarea class=""order-form__input--multiple"" id=""txtAddress"" name=""Address"" rows=""5"" cols=""30""></textarea>
                            <span class=""order-form__validation order-form__validation--show mdi mdi-alert-circle-outline"">درج استان الزامی می باشد</span>

                        </div>
                    </div>

                    <div class=""order-form__group"">
                        <label class=""order-form__label"" for=""txtTel"">شماره تماس : </label>
                        <div class=""order-form__field"">
                            <input class=""order-form__input"" id=""txtTel"" name=""tel"" />
           ");
                WriteLiteral(@"                 <span class=""order-form__validation order-form__validation--show mdi mdi-alert-circle-outline"">درج استان الزامی می باشد</span>
                        </div>
                    </div>
                </div>
            </section>
            <section class=""order-form__section"">
                <h2 class=""order-form__header"">نحوه ارسال</h2>
                <div class=""order-form__content"">
                    <div class=""order-form__group"">
                        <span class=""order-form__label""></span>
                        <div class=""order-form__field"">
                            <label class=""order-form-radio"">
                                <input type=""radio"" class=""order-form-radio__input"" name=""shipping"" value=""1"" />
                                <span class=""order-form-radio__content"">
                                    <span class=""order-form-radio__title""> پست پیشتاز <span class=""order-form-radio__title--highlight"">  (8,000 تومان)</span></span>
              ");
                WriteLiteral(@"                      <span class=""order-form-radio__text""> حداقل تا 24 ساعت بعد کالا به دست شما میر سد </span>
                                </span>
                            </label>
                        </div>
                    </div>
                    <div class=""order-form__group"">
                        <span class=""order-form__label""></span>
                        <div class=""order-form__field"">
                            <label class=""order-form-radio"">
                                <input type=""radio"" class=""order-form-radio__input"" name=""shipping"" value=""2"" />
                                <span class=""order-form-radio__content"">
                                    <span class=""order-form-radio__title""> باربری <span class=""order-form-radio__title--highlight"">  (8,000 تومان)</span></span>
                                    <span class=""order-form-radio__text""> حداقل تا 24 ساعت بعد کالا به دست شما میر سد </span>
                                </span>
                 ");
                WriteLiteral(@"           </label>
                        </div>
                    </div>
                </div>
            </section>
            <section class=""order-form__section"">
                <h2 class=""order-form__header"">نحوه پرداخت</h2>
                <div class=""order-form__content"">

                    <div class=""order-form__group"">
                        <span class=""order-form__label""></span>
                        <div class=""order-form__field"">
                            <label class=""order-form-radio"">
                                <input type=""radio"" class=""order-form-radio__input"" name=""payment"" value=""1"" />
                                <span class=""order-form-radio__content"">
                                    <span class=""order-form-radio__title""> آنلاین </span>
                                    <span class=""order-form-radio__text""> حداقل تا 24 ساعت بعد کالا به دست شما میر سد </span>
                                </span>
                            </label>
     ");
                WriteLiteral(@"                   </div>
                    </div>
                    <div class=""order-form__group"">
                        <span class=""order-form__label""></span>
                        <div class=""order-form__field"">
                            <label class=""order-form-radio"">
                                <input type=""radio"" class=""order-form-radio__input"" name=""payment"" value=""2"" />
                                <span class=""order-form-radio__content"">
                                    <span class=""order-form-radio__title""> پرداخت درب منزل </span>
                                    <span class=""order-form-radio__text""> حداقل تا 24 ساعت بعد کالا به دست شما میر سد </span>
                                </span>
                            </label>
                        </div>
                    </div>
                    <div class=""order-form__group"">
                        <span class=""order-form__label""></span>
                        <div class=""order-form__field"">
    ");
                WriteLiteral("                        <button type=\"submit\" class=\"button\"><span class=\"button-text\">ثبت سفارش</span></button>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </section>\r\n\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
