#pragma checksum "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Areas\Panel\Views\Stants\SearchByName.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8a00823c00ef34207bd94453a848c867cd7928b6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Panel_Views_Stants_SearchByName), @"mvc.1.0.view", @"/Areas/Panel/Views/Stants/SearchByName.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8a00823c00ef34207bd94453a848c867cd7928b6", @"/Areas/Panel/Views/Stants/SearchByName.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b2e678e1e498e0b84e32a5b9531791a8b8e4be48", @"/Areas/Panel/Views/_ViewImports.cshtml")]
    public class Areas_Panel_Views_Stants_SearchByName : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DataAccess.Pagination.PaginatedList<Stant>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "SearchByName", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-route-page", "1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Stants", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Panel", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Update", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("dropdown-item"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Areas\Panel\Views\Stants\SearchByName.cshtml"
   
    Layout = "_Layout";
    ViewData["Title"] = "Stendlərin siyahısı";
    ViewData["MainTitle"] = "Stendlər";
    ViewData["SubTitle"] = "Siyahı";
    ViewData["services"] = "active";
    var prevDisabled = !Model.HasPreviousPage ? "disabled" : "";
    var nextDisabled = !Model.HasNextPage ? "disabled" : "";
    int counter = 1;
    int modalCounter = 1;
    var cultInfo = CultureInfo.GetCultureInfo("az-Latn-AZ");

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n<!-- search field -->\n<div class=\"card\">\n    <div class=\"card-body\">\n        <h5 class=\"mb-3\">Stend axtar</h5>\n\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8a00823c00ef34207bd94453a848c867cd7928b67670", async() => {
                WriteLiteral(@"
            <div class=""input-group mb-3"">
                <div class=""form-group-feedback form-group-feedback-left"">
                    <input type=""text"" name=""name"" class=""form-control form-control-lg"" placeholder=""Axtar"">
                    <div class=""form-control-feedback form-control-feedback-lg"">
                        <i class=""icon-search4 text-muted""></i>
                    </div>
                </div>

                <div class=""input-group-append"">
                    <button type=""submit"" class=""btn btn-primary btn-lg"">Axtar</button>
                </div>
            </div>
        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-page", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["page"] = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Area = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
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
<!-- Bordered table -->
<div class=""card"">
    <div class=""card-header header-elements-inline"">
        <h5 class=""card-title"">Stendlərin siyahısı</h5>
        <div class=""header-elements"">
            <div class=""list-icons"">
                <a class=""list-icons-item"" data-action=""collapse""></a>
                <a class=""list-icons-item"" data-action=""reload""></a>
                <a class=""list-icons-item"" data-action=""remove""></a>
            </div>
        </div>
    </div>
</div>

<table class=""table datatable-basic table-bordered"">
    <thead>
        <tr>
            <th>No</th>
            <th>Restoran adı</th>
            <th>Stendlərin sayı</th>
            <th>Ödəniş</th>
            <th class=""text-center"">Əməliyyatlar</th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 63 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Areas\Panel\Views\Stants\SearchByName.cshtml"
         if (Model != null)
        {

#line default
#line hidden
#nullable disable
#nullable restore
#line 65 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Areas\Panel\Views\Stants\SearchByName.cshtml"
 if (Model.Count != 0)
{

#line default
#line hidden
#nullable disable
#nullable restore
#line 67 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Areas\Panel\Views\Stants\SearchByName.cshtml"
 for (int i = 0; i < Model.Count; i++)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("<tr>\n    <td>");
#nullable restore
#line 70 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Areas\Panel\Views\Stants\SearchByName.cshtml"
    Write(i+1);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n    <td>");
#nullable restore
#line 71 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Areas\Panel\Views\Stants\SearchByName.cshtml"
   Write(Model[i].Restaurant.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n    <td>");
#nullable restore
#line 72 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Areas\Panel\Views\Stants\SearchByName.cshtml"
   Write(Model[i].Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n    <td>");
#nullable restore
#line 73 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Areas\Panel\Views\Stants\SearchByName.cshtml"
   Write(Model[i].Price.ToString("C", cultInfo));

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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8a00823c00ef34207bd94453a848c867cd7928b613814", async() => {
                WriteLiteral("<i class=\"icon-pencil\"></i>Redaktə et");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 82 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Areas\Panel\Views\Stants\SearchByName.cshtml"
                                                                     WriteLiteral(Model[i].Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n                    <a data-toggle=\"modal\" data-target=\"#modal_theme_danger-");
#nullable restore
#line 83 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Areas\Panel\Views\Stants\SearchByName.cshtml"
                                                                       Write(counter);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" class=\"dropdown-item\"><i class=\"icon-eraser3\"></i>Sil </a>\n                </div>\n            </div>\n        </div>\n    </td>\n</tr>\n");
#nullable restore
#line 89 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Areas\Panel\Views\Stants\SearchByName.cshtml"
               }

#line default
#line hidden
#nullable disable
#nullable restore
#line 89 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Areas\Panel\Views\Stants\SearchByName.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 89 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Areas\Panel\Views\Stants\SearchByName.cshtml"
                 }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n    </tbody>\n</table>\n</div>\n<!-- /bordered table -->\n\n\n\n");
#nullable restore
#line 98 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Areas\Panel\Views\Stants\SearchByName.cshtml"
 foreach (var stant in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("<div");
            BeginWriteAttribute("id", " id=\"", 3194, "\"", 3231, 2);
            WriteAttributeValue("", 3199, "modal_theme_danger-", 3199, 19, true);
#nullable restore
#line 100 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Areas\Panel\Views\Stants\SearchByName.cshtml"
WriteAttributeValue("", 3218, modalCounter, 3218, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"modal fade\" tabindex=\"-1\">\n");
#nullable restore
#line 101 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Areas\Panel\Views\Stants\SearchByName.cshtml"
       modalCounter += 1; 

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"modal-dialog\">\n        <div class=\"modal-content\">\n            <div class=\"modal-header bg-danger\">\n                <h6 class=\"modal-title\">Stend silinəcək: ");
#nullable restore
#line 105 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Areas\Panel\Views\Stants\SearchByName.cshtml"
                                                    Write(stant.Restaurant.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h6>
                <button type=""button"" class=""close"" data-dismiss=""modal"">&times;</button>
            </div>
            <div class=""modal-body"">
                <h6 class=""font-weight-semibold"">Vacib qeyd!!!</h6>
                <p>Bu stendi silmək istədiyinizdən əminsiniz mi?</p>
            </div>

            <div class=""modal-footer"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8a00823c00ef34207bd94453a848c867cd7928b619480", async() => {
                WriteLiteral("\n                    <button type=\"button\" class=\"btn btn-link\" data-dismiss=\"modal\">Bağla</button>\n                    <button type=\"submit\" class=\"btn bg-danger\">Sil</button>\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Area = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 114 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Areas\Panel\Views\Stants\SearchByName.cshtml"
                                                                                     WriteLiteral(stant.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n            </div>\n        </div>\n    </div>\n</div>");
#nullable restore
#line 121 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Areas\Panel\Views\Stants\SearchByName.cshtml"
      }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
#nullable restore
#line 123 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Areas\Panel\Views\Stants\SearchByName.cshtml"
  
    var start = Math.Max((Model.PageIndex - 3), 1);
    int ends = Math.Min((Model.PageIndex + 3), Model.TotalPages);
    //TODO: LATER

#line default
#line hidden
#nullable disable
            WriteLiteral("<ul class=\"pagination align-self-end\">\n    <li");
            BeginWriteAttribute("class", " class=\"", 4402, "\"", 4433, 2);
            WriteAttributeValue("", 4410, "page-item", 4410, 9, true);
#nullable restore
#line 129 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Areas\Panel\Views\Stants\SearchByName.cshtml"
WriteAttributeValue(" ", 4419, prevDisabled, 4420, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><a href=\"#\" class=\"page-link\">&larr; &nbsp; Prev</a></li>\n");
#nullable restore
#line 130 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Areas\Panel\Views\Stants\SearchByName.cshtml"
     for (int i = start; i <= ends; i++)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("<td>\n");
#nullable restore
#line 133 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Areas\Panel\Views\Stants\SearchByName.cshtml"
     if (i != Model.PageIndex)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("<li class=\"page-item active\"><a href=\"#\" class=\"page-link\">");
#nullable restore
#line 135 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Areas\Panel\Views\Stants\SearchByName.cshtml"
                                                      Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\n");
#nullable restore
#line 136 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Areas\Panel\Views\Stants\SearchByName.cshtml"
 }
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("<li class=\"page-item disabled\"><a href=\"#\" class=\"page-link\">");
#nullable restore
#line 139 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Areas\Panel\Views\Stants\SearchByName.cshtml"
                                                        Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\n");
#nullable restore
#line 140 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Areas\Panel\Views\Stants\SearchByName.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </td>");
#nullable restore
#line 141 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Areas\Panel\Views\Stants\SearchByName.cshtml"
         }

#line default
#line hidden
#nullable disable
            WriteLiteral("    <li");
            BeginWriteAttribute("class", " class=\"", 4756, "\"", 4787, 2);
            WriteAttributeValue("", 4764, "page-item", 4764, 9, true);
#nullable restore
#line 142 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Areas\Panel\Views\Stants\SearchByName.cshtml"
WriteAttributeValue(" ", 4773, nextDisabled, 4774, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><a href=\"#\" class=\"page-link\">Next &nbsp; &rarr;</a></li>\n</ul>\n\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DataAccess.Pagination.PaginatedList<Stant>> Html { get; private set; }
    }
}
#pragma warning restore 1591
