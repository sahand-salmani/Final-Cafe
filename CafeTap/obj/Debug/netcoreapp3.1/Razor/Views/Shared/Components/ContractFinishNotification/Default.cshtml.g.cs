#pragma checksum "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Views\Shared\Components\ContractFinishNotification\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dd2f942d51d0d5ca0496cf81ca30916d4a3e4f8d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_ContractFinishNotification_Default), @"mvc.1.0.view", @"/Views/Shared/Components/ContractFinishNotification/Default.cshtml")]
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
#line 4 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Views\_ViewImports.cshtml"
using Infrastructure.Common;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Mvc.TagHelpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Views\_ViewImports.cshtml"
using Humanizer;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Views\_ViewImports.cshtml"
using Humanizer.Localisation;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Views\_ViewImports.cshtml"
using static Infrastructure.Common.ClaimsList;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dd2f942d51d0d5ca0496cf81ca30916d4a3e4f8d", @"/Views/Shared/Components/ContractFinishNotification/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"29cb1d535e7ca2410b898a4bdbe21b3b16e0f345", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_ContractFinishNotification_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Infrastructure.Contracts.ViewModels.ContractNotificationVm>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Contracts", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-route-page", "1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("bg-light text-grey w-100 py-2"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Hammısı"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Views\Shared\Components\ContractFinishNotification\Default.cshtml"
  
    var notificationCount = 0;
    var notificationExists = false;
    if (Model != null)
    {
        if (Model.Any())
        {
            notificationCount = Model.Count;
            notificationExists = true;
        }
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<a href=\"#\" class=\"navbar-nav-link dropdown-toggle caret-0\" data-toggle=\"dropdown\">\n    <i class=\"icon-bubbles4\"></i>\n    <span class=\"d-md-none ml-2\">Müqavilələr</span>\n");
#nullable restore
#line 19 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Views\Shared\Components\ContractFinishNotification\Default.cshtml"
     if (notificationExists)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <span class=\"badge badge-pill bg-warning-400 ml-auto ml-md-0\">");
#nullable restore
#line 21 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Views\Shared\Components\ContractFinishNotification\Default.cshtml"
                                                                 Write(notificationCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\n");
#nullable restore
#line 22 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Views\Shared\Components\ContractFinishNotification\Default.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</a>

<div class=""dropdown-menu dropdown-menu-right dropdown-content wmin-md-350"">
    <div class=""dropdown-content-header"">
        <span class=""font-weight-semibold"">Müqavilələr</span>
    </div>

    <div class=""dropdown-content-body dropdown-scrollable"">
        <ul class=""media-list"">
            
");
#nullable restore
#line 33 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Views\Shared\Components\ContractFinishNotification\Default.cshtml"
             if (Model != null)
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 35 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Views\Shared\Components\ContractFinishNotification\Default.cshtml"
                 foreach (var contract in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li class=\"media\">\n                        <div class=\"media-body\">\n                            <div class=\"media-title\">\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dd2f942d51d0d5ca0496cf81ca30916d4a3e4f8d8584", async() => {
                WriteLiteral("\n                                    <span class=\"font-weight-semibold\">Müqavilə: ");
#nullable restore
#line 41 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Views\Shared\Components\ContractFinishNotification\Default.cshtml"
                                                                            Write(contract.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral(" </span>\n                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 40 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Views\Shared\Components\ContractFinishNotification\Default.cshtml"
                                                                                 WriteLiteral(contract.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n                                <span class=\"text-muted float-right font-size-sm\">");
#nullable restore
#line 43 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Views\Shared\Components\ContractFinishNotification\Default.cshtml"
                                                                             Write(contract.Remaining);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\n                            </div>\n\n                            <span class=\"text-muted\">Restoran: ");
#nullable restore
#line 46 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Views\Shared\Components\ContractFinishNotification\Default.cshtml"
                                                          Write(contract.RestaurantName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\n                        </div>\n                    </li>\n");
#nullable restore
#line 49 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Views\Shared\Components\ContractFinishNotification\Default.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 49 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Views\Shared\Components\ContractFinishNotification\Default.cshtml"
                 
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            \n        </ul>\n    </div>\n\n    <div class=\"dropdown-content-footer justify-content-center p-0\">\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dd2f942d51d0d5ca0496cf81ca30916d4a3e4f8d13064", async() => {
                WriteLiteral("<i class=\"icon-menu7 d-block top-0\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-page", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"] = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n    </div>\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public AzCultureInfo AzCulture { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Infrastructure.Contracts.ViewModels.ContractNotificationVm>> Html { get; private set; }
    }
}
#pragma warning restore 1591
