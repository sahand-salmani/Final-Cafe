#pragma checksum "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Areas\Panel\Views\Products\Contracts.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fa6ce0c70e8acf77fea368f874cbd95a1d332400"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Panel_Views_Products_Contracts), @"mvc.1.0.view", @"/Areas/Panel/Views/Products/Contracts.cshtml")]
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
#line 4 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Areas\Panel\Views\_ViewImports.cshtml"
using Domain.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Areas\Panel\Views\_ViewImports.cshtml"
using Infrastructure.Common;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Areas\Panel\Views\_ViewImports.cshtml"
using System.Globalization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Areas\Panel\Views\_ViewImports.cshtml"
using Humanizer;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Areas\Panel\Views\_ViewImports.cshtml"
using Humanizer.Localisation;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fa6ce0c70e8acf77fea368f874cbd95a1d332400", @"/Areas/Panel/Views/Products/Contracts.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b2e678e1e498e0b84e32a5b9531791a8b8e4be48", @"/Areas/Panel/Views/_ViewImports.cshtml")]
    public class Areas_Panel_Views_Products_Contracts : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DataAccess.Pagination.PaginatedList<Contract>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "2", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "3", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "SearchByName", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-route-page", "1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Restaurants", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Panel", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Contracts", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Update", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("dropdown-item"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_12 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Areas\Panel\Views\Products\Contracts.cshtml"
  
    Layout = "_Layout";
    ViewData["Title"] = "Müqavilə Siyahısı";
    ViewData["MainTitle"] = "Müqavilə";
    ViewData["SubTitle"] = "Siyahısı";
    ViewData["services"] = "active";
    var prevDisabled = !Model.HasPreviousPage ? "disabled" : "";
    var nextDisabled = !Model.HasNextPage ? "disabled" : "";


#line default
#line hidden
#nullable disable
            WriteLiteral("\n<div class=\"card\">\n    <div class=\"card-body\">\n        <h5 class=\"mb-3\">Axtar</h5>\n\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fa6ce0c70e8acf77fea368f874cbd95a1d3324008849", async() => {
                WriteLiteral(@"
            <div class=""input-group mb-3"">
                <div class=""form-group-feedback form-group-feedback-left w-75"">
                    <input type=""text"" name=""name"" class=""form-control form-control-lg"" placeholder=""Müqaviləni Axtar"">
                    <div class=""form-control-feedback form-control-feedback-lg"">
                        <i class=""icon-search4 text-muted""></i>
                    </div>
                </div>

                <div class=""form-group-feedback w-auto"">
                    <select name=""searchOption"" class=""form-control form-control-lg"">
                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fa6ce0c70e8acf77fea368f874cbd95a1d3324009733", async() => {
                    WriteLiteral("Restoran");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fa6ce0c70e8acf77fea368f874cbd95a1d33240010980", async() => {
                    WriteLiteral("Müqavilə");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fa6ce0c70e8acf77fea368f874cbd95a1d33240012228", async() => {
                    WriteLiteral("Şəhər");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n                    </select>\n                </div>\n\n                <div class=\"input-group-append\">\n                    <button type=\"submit\" class=\"btn btn-primary btn-lg\">Axtar</button>\n                </div>\n            </div>\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-page", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["page"] = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Area = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
    </div>
</div>
<!-- /search field -->
<!-- /search field -->
<!-- Bordered table -->
<div class=""card"">
    <div class=""card-header header-elements-inline"">
        <h5 class=""card-title"">Müqavilə Siyahısı</h5>
        <div class=""header-elements"">
            
        </div>
    </div>

    

    <table class=""table datatable-basic table-bordered"">
        <thead>
            <tr>
                <th>No</th>
                <th>Müqavilə adı</th>
                <th>Rstoran</th>
                <th>Başlama tarixi</th>
                <th>Bitmə tarixi</th>
                <th>Qalır</th>
                <th>Satış əməkdaşı</th>
                <th class=""text-center"">Əməliyyatlar</th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 68 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Areas\Panel\Views\Products\Contracts.cshtml"
             if (Model != null)
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 70 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Areas\Panel\Views\Products\Contracts.cshtml"
                 if (Model.Count != 0)
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 72 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Areas\Panel\Views\Products\Contracts.cshtml"
                     for (int i = 0; i < Model.Count; i++)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\n                            <td>");
#nullable restore
#line 75 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Areas\Panel\Views\Products\Contracts.cshtml"
                            Write(i+1);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                            <td>");
#nullable restore
#line 76 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Areas\Panel\Views\Products\Contracts.cshtml"
                           Write(Model[i].Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                            <td>");
#nullable restore
#line 77 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Areas\Panel\Views\Products\Contracts.cshtml"
                           Write(Model[i].Restaurant.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                            <td>");
#nullable restore
#line 78 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Areas\Panel\Views\Products\Contracts.cshtml"
                           Write(AzCulture.ToAzDateTimeFormatFull(Model[i].StartDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                            <td>");
#nullable restore
#line 79 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Areas\Panel\Views\Products\Contracts.cshtml"
                           Write(AzCulture.ToAzDateTimeFormatFull(Model[i].EndDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                            <td>");
#nullable restore
#line 80 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Areas\Panel\Views\Products\Contracts.cshtml"
                            Write((AzCulture.Difference(Model[i].EndDate, Model[i].StartDate)).Humanize(5, maxUnit:TimeUnit.Year, minUnit:TimeUnit.Day, culture:AzCulture.AzCulture()));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                            <td>");
#nullable restore
#line 81 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Areas\Panel\Views\Products\Contracts.cshtml"
                           Write(Model[i].Employee.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
                            <td class=""text-center"">
                                <div class=""list-icons"">
                                    <div class=""dropdown"">
                                        <a href=""#"" class=""list-icons-item"" data-toggle=""dropdown"">
                                            <i class=""icon-menu9""></i>
                                        </a>

                                        <div class=""dropdown-menu dropdown-menu-right"">
                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fa6ce0c70e8acf77fea368f874cbd95a1d33240020507", async() => {
                WriteLiteral("<i class=\"icon-pencil\"></i>Redaktə Et");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_9.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 90 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Areas\Panel\Views\Products\Contracts.cshtml"
                                                                                                WriteLiteral(Model[i].Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n                                            <a data-toggle=\"modal\" data-target=\"#modal_theme_danger-");
#nullable restore
#line 91 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Areas\Panel\Views\Products\Contracts.cshtml"
                                                                                               Write(Model[i].Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" class=\"dropdown-item\"><i class=\"icon-eraser3\"></i>Sil</a>\n                                        </div>\n                                    </div>\n                                </div>\n                            </td>\n                        </tr>\n");
#nullable restore
#line 97 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Areas\Panel\Views\Products\Contracts.cshtml"

                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 98 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Areas\Panel\Views\Products\Contracts.cshtml"
                     
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 99 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Areas\Panel\Views\Products\Contracts.cshtml"
                 
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </tbody>\n    </table>\n</div>\n<!-- /bordered table -->\n\n\n\n");
#nullable restore
#line 109 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Areas\Panel\Views\Products\Contracts.cshtml"
 foreach (var contract in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div");
            BeginWriteAttribute("id", " id=\"", 4322, "\"", 4358, 2);
            WriteAttributeValue("", 4327, "modal_theme_danger-", 4327, 19, true);
#nullable restore
#line 111 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Areas\Panel\Views\Products\Contracts.cshtml"
WriteAttributeValue("", 4346, contract.Id, 4346, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"modal fade\" tabindex=\"-1\">\n\n        <div class=\"modal-dialog\">\n            <div class=\"modal-content\">\n                <div class=\"modal-header bg-danger\">\n                    <h6 class=\"modal-title\">Müqaviləni silmək ");
#nullable restore
#line 116 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Areas\Panel\Views\Products\Contracts.cshtml"
                                                         Write(contract.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h6>
                    <button type=""button"" class=""close"" data-dismiss=""modal"">&times;</button>
                </div>

                <div class=""modal-body"">
                    <h6 class=""font-weight-semibold"">Önəmli Qeyd!!!</h6>
                    <p>Məhsulu silmək istədiyinizdən əminmisiniz mi? </p>

                </div>

                <div class=""modal-footer"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fa6ce0c70e8acf77fea368f874cbd95a1d33240026223", async() => {
                WriteLiteral("\n                        <button type=\"button\" class=\"btn btn-link\" data-dismiss=\"modal\">Bağla</button>\n                        <button type=\"submit\" class=\"btn bg-danger\">Sil</button>\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_11.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_11);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Area = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 127 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Areas\Panel\Views\Products\Contracts.cshtml"
                                                                                            WriteLiteral(contract.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_12.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_12);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n                </div>\n            </div>\n        </div>\n    </div>\n");
#nullable restore
#line 135 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Areas\Panel\Views\Products\Contracts.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n<ul class=\"pagination align-self-end\">\n    <li");
            BeginWriteAttribute("class", " class=\"", 5442, "\"", 5473, 2);
            WriteAttributeValue("", 5450, "page-item", 5450, 9, true);
#nullable restore
#line 139 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Areas\Panel\Views\Products\Contracts.cshtml"
WriteAttributeValue(" ", 5459, prevDisabled, 5460, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><a href=\"#\" class=\"page-link\">&larr; &nbsp; Prev</a></li>\n");
#nullable restore
#line 140 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Areas\Panel\Views\Products\Contracts.cshtml"
     for (int i = 1; i <= Model.TotalPages; i++)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <td>\n");
#nullable restore
#line 143 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Areas\Panel\Views\Products\Contracts.cshtml"
             if (i != Model.PageIndex)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li class=\"page-item active\"><a href=\"#\" class=\"page-link\">");
#nullable restore
#line 145 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Areas\Panel\Views\Products\Contracts.cshtml"
                                                                  Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\n");
#nullable restore
#line 146 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Areas\Panel\Views\Products\Contracts.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li class=\"page-item disabled\"><a href=\"#\" class=\"page-link\">");
#nullable restore
#line 149 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Areas\Panel\Views\Products\Contracts.cshtml"
                                                                    Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\n");
#nullable restore
#line 150 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Areas\Panel\Views\Products\Contracts.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </td>\n");
#nullable restore
#line 152 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Areas\Panel\Views\Products\Contracts.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    <li");
            BeginWriteAttribute("class", " class=\"", 5900, "\"", 5931, 2);
            WriteAttributeValue("", 5908, "page-item", 5908, 9, true);
#nullable restore
#line 153 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Areas\Panel\Views\Products\Contracts.cshtml"
WriteAttributeValue(" ", 5917, nextDisabled, 5918, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><a href=\"#\" class=\"page-link\">Next &nbsp; &rarr;</a></li>\n</ul>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DataAccess.Pagination.PaginatedList<Contract>> Html { get; private set; }
    }
}
#pragma warning restore 1591
