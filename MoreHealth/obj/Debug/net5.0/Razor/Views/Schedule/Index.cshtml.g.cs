#pragma checksum "F:\Education\More\MoreHealth\MoreHealth\Views\Schedule\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8f857d22cc92001a2d7b91ee1883d22ebb09aa24"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Schedule_Index), @"mvc.1.0.view", @"/Views/Schedule/Index.cshtml")]
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
#line 1 "F:\Education\More\MoreHealth\MoreHealth\Views\_ViewImports.cshtml"
using MoreHealth;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\Education\More\MoreHealth\MoreHealth\Views\_ViewImports.cshtml"
using MoreHealth.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8f857d22cc92001a2d7b91ee1883d22ebb09aa24", @"/Views/Schedule/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a3f4ac2e0e60d98d84c9441b1741d07565121ecb", @"/Views/_ViewImports.cshtml")]
    public class Views_Schedule_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div id=""ticketPlan""></div>
<script id=""customEditorTemplate"" type=""text/x-kendo-template"">
    <!-- notice how the Title is hidden if the event is new -->
    <div class=""k-edit-label"">
        <label for=""start"">Start</label>
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
    <div class=""k-edit-label""><label for=""end"">End</label></div>
    <div data-container-for=""end"" class=""k-edit-field"">
        <input type=""text"" data-type=""date"" data-role=""datetimepicker"" data-bind=""value");
            WriteLiteral(@":end,invisible:isAllDay"" name=""end"" data-datecompare-msg=""End date should be greater than or equal to the start date"" />
        <input type=""text"" data-type=""date"" data-role=""datepicker"" data-bind=""value:end,visible:isAllDay"" name=""end"" data-datecompare-msg=""End date should be greater than or equal to the start date"" />
        <span data-bind=""text: endTimezone""></span>
        <span data-bind=""text: startTimezone, invisible: endTimezone""></span>
        <span data-for=""end"" class=""k-invalid-msg"" style=""display: none;""></span>
      </div>
    <div class=""k-edit-label""><label for=""recurrenceRule"">Repeat</label></div>
    <div data-container-for=""recurrenceRule"" class=""k-edit-field"">
        <div data-bind=""value:recurrenceRule"" name=""recurrenceRule"" data-role=""recurrenceeditor""></div>
      </div>
    <div class=""k-edit-label""><label for=""ownerId"">Owner</label></div>
        <input id=""doctors"" style=""width: 100%;"" />

    # $(""#doctors"").kendoDropDownList({ #
        # dataTextField: ""fullNam");
            WriteLiteral("e\", #\r\n        # dataValueField: \"id\", #\r\n        # optionLabel: \"Выберите врача...\", #\r\n        # height: 500, #\r\n        # dataSource: { #\r\n           # transport: { #\r\n               # read: { #\r\n                   # url: \"");
#nullable restore
#line 46 "F:\Education\More\MoreHealth\MoreHealth\Views\Schedule\Index.cshtml"
                      Write(Url.Action("GetAllDoctors", "FeedBack"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@""", #
                   # dataType: ""json"", #
                   # cache: false #
              # } #
          #  } #
      # } #
    # }); #
</script>   

<script>
    $(""#doctors"").kendoDropDownList({
        dataTextField: ""fullName"",
        dataValueField: ""id"",
        optionLabel: ""Выберите врача..."",
        height: 500,
        dataSource: {
            transport: {
                read: {
                    url: """);
#nullable restore
#line 64 "F:\Education\More\MoreHealth\MoreHealth\Views\Schedule\Index.cshtml"
                     Write(Url.Action("GetAllDoctors", "FeedBack"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@""",
                    dataType: ""json"",
                    cache: false
                }
            }
        }
    });
var date = ""FREQ=WEEKLY;BYDAY=TU,TH""
    $(function () {
        $(""#ticketPlan"").kendoScheduler({
            date: new Date(""2021/12/05""),
            startTime: new Date(""2021/12/05 07:00 AM""),
            height: 600,
            views: [
                ""day"",
                { type: ""workWeek"", selected: true },
                ""week"",
                ""month"",
                ""agenda""
            ],
            timezone: ""Europe/Minsk"",
           editable: { template: $(""#customEditorTemplate"").html()},
            dataSource: {
                batch: true,
                transport: {
                    read: {
                        url: ""/Appointment/GetAllTalons"",
                        dataType: ""json""
                    }
                },
                schema: {
                    model: {
                        id: ""taskId"", // (Man");
            WriteLiteral(@"datory) The ""id"" of the event is the ""taskId"" field.
                        fields: {
                            // Describe the Scheduler event fields and map them to the fields returned by the remote service.
                            taskId: {
                                from: ""Id"", // The 'TaskID' server-side field is mapped to the 'taskId' client-side field.
                                type: ""number""
                            },
                            title: {
                                from: ""patient.surname"", // The 'Title' server-side field is mapped to the 'title' client-side field.
                                defaultValue: ""No title"",
                                validation: { required: true }
                            },
                            start: {
                                type: ""date"",
                                from: ""dateStart"" // The 'Start' server-side field is mapped to the 'start' client-side field.
                        ");
            WriteLiteral(@"    },
                            end: {
                                type: ""date"",
                                from: ""dateEnd"" // The 'End' server-side field is mapped to the 'end' client-side field.
                            },
                            recurrenceRule: {from : ""recurrenceRule""}
                        }
                    }
                }
            }
        });

        $(""#create"").click(function () {
            $(""#ticketPlan"").data(""kendoScheduler"").addEvent({
                start: new Date(""2013/6/13""),
                end: new Date(""2013/6/13"")
            });
        });
    });
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
