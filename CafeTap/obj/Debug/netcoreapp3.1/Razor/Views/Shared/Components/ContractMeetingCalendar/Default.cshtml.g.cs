#pragma checksum "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Views\Shared\Components\ContractMeetingCalendar\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bdcaa11b73d8ff22a1098b1bd386d8ad012c5b12"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_ContractMeetingCalendar_Default), @"mvc.1.0.view", @"/Views/Shared/Components/ContractMeetingCalendar/Default.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bdcaa11b73d8ff22a1098b1bd386d8ad012c5b12", @"/Views/Shared/Components/ContractMeetingCalendar/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"29cb1d535e7ca2410b898a4bdbe21b3b16e0f345", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_ContractMeetingCalendar_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Infrastructure.ViewModels.ContractMeetingCalendarVm>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 4 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Views\Shared\Components\ContractMeetingCalendar\Default.cshtml"
     if (Model != null)
    {
        if (Model.MeetingCalendarVm.Any())
        {
            foreach (var meetingCalendarVm in Model.MeetingCalendarVm)
            {
                meetingCalendarVm.Url = Url.Action("Get", "RestaurantMeetings", new { id = meetingCalendarVm.Id });
            }
        }

        if (Model.ContractCalendarVm.Any())
        {
            foreach (var contract in Model.ContractCalendarVm)
            {
                contract.Url = Url.Action("Get", "Contracts", new { id = contract.Id });
            }
        }
    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"


<!-- Event colors -->
<div class=""card"">
    <div class=""card-header header-elements-inline"">
        <h5 class=""card-title"">Müqavilə və Görüşlər Təqvimi</h5>
    </div>

    <div class=""card-body"">
        <div class=""fullcalendar-event-colors""></div>
    </div>
</div>



<script type=""text/javascript"">
    var FullCalendarStyling = function() {

        var model = ");
#nullable restore
#line 42 "C:\Users\sahan\Desktop\CafeTap-master\Desktop\cafe_tap\CafeTap\Views\Shared\Components\ContractMeetingCalendar\Default.cshtml"
               Write(Json.Serialize(Model));

#line default
#line hidden
#nullable disable
            WriteLiteral(@";
        var result = [...model.contractCalendarVm, ...model.meetingCalendarVm];
        //var result = Object.assign({}, a);
        //console.log(model.contractCalendarVm);
        //console.log(result);


        //
        // Setup module components
        //

        // External events
        var _componentFullCalendarStyling = function () {
            if (typeof FullCalendar == 'undefined') {
                console.warn('Warning - Fullcalendar files are not loaded.');
                return;
            }


            // Add events
            // ------------------------------

            // Event colors
            var eventColors = result;

            // Initialization
            // ------------------------------

            //
            // Event colors
            //
            function toJSONLocal(date) {
                var local = new Date(date);
                local.setMinutes(date.getMinutes() - date.getTimezoneOffset());
                return local.toJSON().slice(0, 10);
        ");
            WriteLiteral(@"    };
            var today = new Date();
            today = toJSONLocal(today);

            // Define element
            var calendarEventColorsElement = document.querySelector('.fullcalendar-event-colors');

            // Initialize
            if (calendarEventColorsElement) {
                var calendarEventColorsInit = new FullCalendar.Calendar(calendarEventColorsElement, {
                    plugins: ['dayGrid', 'interaction'],
                    header: {
                        left: 'prev,next today',
                        center: 'title',
                        right: 'dayGridMonth,dayGridWeek,dayGridDay'
                    },
                    defaultDate: today,
                    editable: true,
                    events: eventColors
                }).render();
            }


            //
            // Event background colors
            //

            // Define element
            var calendarEventBgColorsElement = document.querySelector('.fullcalendar-background-colors');
");
            WriteLiteral(@"
            // Initialize
            if (calendarEventBgColorsElement) {
                var calendarEventBgColorsInit = new FullCalendar.Calendar(calendarEventBgColorsElement, {
                    plugins: ['dayGrid', 'interaction'],
                    header: {
                        left: 'prev,next today',
                        center: 'title',
                        right: 'dayGridMonth,dayGridWeek,dayGridDay'
                    },
                    defaultDate: today,
                    editable: true,
                    events: eventBackgroundColors
                }).render();
            }
        };


        //
        // Return objects assigned to module
        //

        return {
            init: function () {
                _componentFullCalendarStyling();
            }
        }
    }();


    // Initialize module
    // ------------------------------

    document.addEventListener('DOMContentLoaded', function () {
        FullCalendarStyling.init();
    });

</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Infrastructure.ViewModels.ContractMeetingCalendarVm> Html { get; private set; }
    }
}
#pragma warning restore 1591
