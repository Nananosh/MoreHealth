#pragma checksum "C:\Users\nanan\RiderProjects\MoreHealth\MoreHealth\Views\Admin\Doctor.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0624e6732b9e596d9a8009a66bc17c08a51e7c0e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Doctor), @"mvc.1.0.view", @"/Views/Admin/Doctor.cshtml")]
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
#line 1 "C:\Users\nanan\RiderProjects\MoreHealth\MoreHealth\Views\_ViewImports.cshtml"
using MoreHealth;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\nanan\RiderProjects\MoreHealth\MoreHealth\Views\_ViewImports.cshtml"
using MoreHealth.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\nanan\RiderProjects\MoreHealth\MoreHealth\Views\Admin\Doctor.cshtml"
using Microsoft.EntityFrameworkCore.Metadata.Internal;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0624e6732b9e596d9a8009a66bc17c08a51e7c0e", @"/Views/Admin/Doctor.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a3f4ac2e0e60d98d84c9441b1741d07565121ecb", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_Doctor : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div class=""content"">
    <div class=""mt-5"">
        <p>Дата начала:
            <input id=""startDate"" class=""mb-3"" style=""margin:15px;""/>
            Дата окончания:
            <input id=""endDate"" class=""mb-3"" style=""margin:15px;""/>
        </p>
        <div id=""grid""> </div>
    </div>
</div>
<script>
$(document).ready(function () {
    onFilterChange();
});

    $(""#startDate"").kendoDatePicker({
        value: new Date('");
#nullable restore
#line 18 "C:\Users\nanan\RiderProjects\MoreHealth\MoreHealth\Views\Admin\Doctor.cshtml"
                    Write(DateTime.Now.AddMonths(-1).ToString("yyyy-MM-ddTHH:mm:ss"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"'),
        change: onFilterChange,
        format: ""{0:dd/MM/yyyy}""
    });
    
    function onFilterChange() {
            $(""#grid"").data(""kendoGrid"").dataSource.read();
        }
        
    $(""#endDate"").kendoDatePicker({
        value: new Date('");
#nullable restore
#line 28 "C:\Users\nanan\RiderProjects\MoreHealth\MoreHealth\Views\Admin\Doctor.cshtml"
                    Write(DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"'),
        change: onFilterChange,
        format: ""{0:dd/MM/yyyy}""
        });
    
    $(""#grid"").kendoGrid({
                    dataSource: {
                        transport: {
                            read: { 
                                url: """);
#nullable restore
#line 37 "C:\Users\nanan\RiderProjects\MoreHealth\MoreHealth\Views\Admin\Doctor.cshtml"
                                 Write(Url.Action("GetAppointmentsByDateFilter", "Admin"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@""",
                                data: function () {
                                    var dateStart = $(""#startDate"").data(""kendoDatePicker"").value();
                                    var dateEnd = $(""#endDate"").data(""kendoDatePicker"").value();
                                    var dateStartConverted = kendo.toString(dateStart, ""dd/MM/yyyy"");
                                    var dateEndConverted = kendo.toString(dateEnd, ""dd/MM/yyyy"");
                                    var doctorId = ");
#nullable restore
#line 43 "C:\Users\nanan\RiderProjects\MoreHealth\MoreHealth\Views\Admin\Doctor.cshtml"
                                              Write(ViewBag.DoctorId);

#line default
#line hidden
#nullable disable
            WriteLiteral(@";
                                    return {
                                        dateStart: kendo.toString(dateStartConverted, ""dd/MM/yyyy""),
                                        dateEnd: kendo.toString(dateEndConverted, ""dd/MM/yyyy""),
                                        doctorId: doctorId
                                    };
                                }
                            },
                        },
                        schema: {
                                                    model: {
                                                        fields: {
                                                            Patient: { from: ""patient"", nullable: true, validation: { required: true } },
                                                            DateStart: { from: ""dateStart"", type: ""date"", validation: { required: true } }
                                                        }
                                                    }
                       ");
            WriteLiteral(@"                         },
                                                pageSize: 20,
                                                serverPaging: true,
                                                serverFiltering: true,
                                                serverSorting: true
                                            },
                                            toolbar: [
                                                                {name: ""excel""}
                                                            ],
                                            height: 550,
                                            pageable: true,
                                            columns: [
                                                {
                                                    field: ""Patient.fullName"",
                                                    title: ""Клиент""
                                                },
                                              ");
            WriteLiteral(@"  {
                                                    field: ""DateStart"",
                                                    title: ""День"",
                                                    format: ""{0:dd-MM-yyyy HH:MM}""
                                                }
                                            ]
        });
</script>
");
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
