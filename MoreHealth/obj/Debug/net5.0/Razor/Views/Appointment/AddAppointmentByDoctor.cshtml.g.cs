#pragma checksum "C:\Users\great\RiderProjects\MoreHealth\MoreHealth\Views\Appointment\AddAppointmentByDoctor.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "052969669afc444d97ca0ef5f3801df9269deba6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Appointment_AddAppointmentByDoctor), @"mvc.1.0.view", @"/Views/Appointment/AddAppointmentByDoctor.cshtml")]
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
#line 1 "C:\Users\great\RiderProjects\MoreHealth\MoreHealth\Views\_ViewImports.cshtml"
using MoreHealth;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\great\RiderProjects\MoreHealth\MoreHealth\Views\_ViewImports.cshtml"
using MoreHealth.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"052969669afc444d97ca0ef5f3801df9269deba6", @"/Views/Appointment/AddAppointmentByDoctor.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a3f4ac2e0e60d98d84c9441b1741d07565121ecb", @"/Views/_ViewImports.cshtml")]
    public class Views_Appointment_AddAppointmentByDoctor : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div id=""example"">
    <div id=""scheduler""></div>
</div>
<script id=""event-template"" type=""text/x-kendo-template"">
    <div class=""movie-template"">
      <p>#: title #</p>
      </div>
    </script>
<script id=""customEditorTemplate"" type=""text/x-kendo-template"">
    <div class=""k-edit-label"">
        <label for=""start"">Начало</label>
      </div>
    <div data-container-for=""start"" class=""k-edit-field"">
        <input type=""text""
               data-role=""datetimepicker""
               data-interval=""15""
               data-type=""date""
               data-bind=""value:start,invisible:isAllDay""
               name=""start""/>
        <input type=""text"" data-type=""date"" data-role=""datepicker"" data-bind=""value:start,visible:isAllDay"" name=""start"" />
        <span data-bind=""text: startTimezone""></span>
        <span data-for=""start"" class=""k-invalid-msg"" style=""display: none;""></span>
      </div>
    <div class=""k-edit-label""><label for=""end"">Конец</label></div>
    <div data-container-for=");
            WriteLiteral(@"""end"" class=""k-edit-field"">
        <input type=""text"" data-type=""date"" data-role=""datetimepicker"" data-bind=""value:end,invisible:isAllDay"" name=""end"" data-datecompare-msg=""End date should be greater than or equal to the start date"" />
        <input type=""text"" data-type=""date"" data-role=""datepicker"" data-bind=""value:end,visible:isAllDay"" name=""end"" data-datecompare-msg=""End date should be greater than or equal to the start date"" />
        <span data-bind=""text: endTimezone""></span>
        <span data-bind=""text: startTimezone, invisible: endTimezone""></span>
        <span data-for=""end"" class=""k-invalid-msg"" style=""display: none;""></span>
      </div>
    </script>
<script>

$(function() {
    $(""#scheduler"").kendoScheduler({
        footer: false,
        date: new Date(""");
#nullable restore
#line 38 "C:\Users\great\RiderProjects\MoreHealth\MoreHealth\Views\Appointment\AddAppointmentByDoctor.cshtml"
                   Write(DateTime.Now.ToString("yyyy-M-d"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\"),\r\n        startTime: new Date(\"");
#nullable restore
#line 39 "C:\Users\great\RiderProjects\MoreHealth\MoreHealth\Views\Appointment\AddAppointmentByDoctor.cshtml"
                        Write(DateTime.Now.ToString("yyyy-M-d 08:00"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"""),
        allDaySlot: false,
        views: [
            {
                type: ""day"",
                selected: true,
            },
            {
                type: ""workWeek""
            }

        ],
        editable: {
            template: $(""#customEditorTemplate"").html(),
        },
        eventTemplate: $(""#event-template"").html(),
        timezone: ""Europe/Minsk"",
        dataSource: {
            batch: true,
            transport: {
                read: {
                    url: """);
#nullable restore
#line 60 "C:\Users\great\RiderProjects\MoreHealth\MoreHealth\Views\Appointment\AddAppointmentByDoctor.cshtml"
                     Write(Url.Action("GetTalonsByDoctorId", "Appointment", new {id = ViewBag.Id}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\",\r\n                    dataType: \"json\"\r\n                },\r\n                update: {\r\n                    url: \"");
#nullable restore
#line 64 "C:\Users\great\RiderProjects\MoreHealth\MoreHealth\Views\Appointment\AddAppointmentByDoctor.cshtml"
                     Write(Url.Action("EditDoctorTalon", "Appointment"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\",\r\n                    dataType: \"json\",\r\n                    type: \"POST\"\r\n                },\r\n                destroy: {\r\n                    url: \"");
#nullable restore
#line 69 "C:\Users\great\RiderProjects\MoreHealth\MoreHealth\Views\Appointment\AddAppointmentByDoctor.cshtml"
                     Write(Url.Action("DeleteDoctorTalon", "Appointment"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\",\r\n                    dataType: \"json\",\r\n                    type: \"DELETE\"\r\n                },    \r\n                create: {\r\n                    url: \"");
#nullable restore
#line 74 "C:\Users\great\RiderProjects\MoreHealth\MoreHealth\Views\Appointment\AddAppointmentByDoctor.cshtml"
                     Write(Url.Action("AddDoctorTalon", "Appointment"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@""",
                    dataType: ""json"",
                    type: ""POST""
                },
                parameterMap: function(options, operation) {
                    if (operation !== ""read"" && options.models) {
                        console.log(options.models[0])
                        options.models[0].dateStart = kendo.toString(options.models[0].dateStart, ""dd/MM/yyyy HH:mm"");
                        options.models[0].dateEnd = kendo.toString(options.models[0].dateEnd, ""dd/MM/yyyy HH:mm"");
                        console.log(options.models[0])
                        return options.models[0];
                    }
                }
            },
            schema: {
                model: {
                    id: ""id"",
                    fields: {
                        id: {
                            from: ""id"",
                            type: ""number""
                        },
                        title: {
                            defaultValue: ""No title""");
            WriteLiteral(@",
                            validation: {
                                required: false
                            }
                        },
                        start: {
                            type: ""date"",
                            from: ""dateStart""
                        },
                        end: {
                            type: ""date"",
                            from: ""dateEnd""
                        },
                        doctorId: {
                            type: ""number"",
                            from: ""doctorId"",
                            defaultValue: ");
#nullable restore
#line 113 "C:\Users\great\RiderProjects\MoreHealth\MoreHealth\Views\Appointment\AddAppointmentByDoctor.cshtml"
                                     Write(ViewBag.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        }
                    }
                }
            }
        }
    });
});
</script>
<style>
    .k-icon.k-i-arrow-60-down{
        display: none;
        }
    .k-icon.k-i-arrow-60-up{
        display: none;
        }
    .k-current-time{
            display: none;
        }
</style>");
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
