#pragma checksum "E:\PBTProject\Ajit Singh\CrimeReportingSystem\CRS\CRS.Web\Views\Crime\ViewCaseDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "31a668a01a8609e69cd1ab84a6b7a2e92b52bf67"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Crime_ViewCaseDetails), @"mvc.1.0.view", @"/Views/Crime/ViewCaseDetails.cshtml")]
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
#line 1 "E:\PBTProject\Ajit Singh\CrimeReportingSystem\CRS\CRS.Web\Views\_ViewImports.cshtml"
using CRS.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\PBTProject\Ajit Singh\CrimeReportingSystem\CRS\CRS.Web\Views\_ViewImports.cshtml"
using CRS.Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"31a668a01a8609e69cd1ab84a6b7a2e92b52bf67", @"/Views/Crime/ViewCaseDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"470181f602829588e3675afd38d33d349051232e", @"/Views/_ViewImports.cshtml")]
    public class Views_Crime_ViewCaseDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "E:\PBTProject\Ajit Singh\CrimeReportingSystem\CRS\CRS.Web\Views\Crime\ViewCaseDetails.cshtml"
  
	ViewData["Title"] = @localizer["Case Details"];


#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!-- Content Header (Page header) -->\r\n<section class=\"content-header\">\r\n\r\n <div class=\"container-fluid\">\r\n  <div class=\"row mb-2\">\r\n   <div class=\"col-sm-6\">\r\n\t<h1>");
#nullable restore
#line 13 "E:\PBTProject\Ajit Singh\CrimeReportingSystem\CRS\CRS.Web\Views\Crime\ViewCaseDetails.cshtml"
   Write(localizer["Case Details"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n   </div>\r\n   <div class=\"col-sm-6\">\r\n\t<ol class=\"breadcrumb float-sm-right\">\r\n\t <li class=\"breadcrumb-item\"><a href=\"#\">");
#nullable restore
#line 17 "E:\PBTProject\Ajit Singh\CrimeReportingSystem\CRS\CRS.Web\Views\Crime\ViewCaseDetails.cshtml"
                                        Write(localizer["Home"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n\t <li class=\"breadcrumb-item active\">");
#nullable restore
#line 18 "E:\PBTProject\Ajit Singh\CrimeReportingSystem\CRS\CRS.Web\Views\Crime\ViewCaseDetails.cshtml"
                                   Write(localizer["Case Details"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n\t</ol>\r\n   </div>\r\n  </div>\r\n </div><!-- /.container-fluid -->\r\n</section>\r\n\r\n<!-- Main content -->\r\n<section class=\"content\">\r\n\r\n <div class=\"container-fluid\">\r\n\r\n  <div class=\"card\">\r\n   <div class=\"card-header\">\r\n\t<h3 class=\"card-title\">");
#nullable restore
#line 32 "E:\PBTProject\Ajit Singh\CrimeReportingSystem\CRS\CRS.Web\Views\Crime\ViewCaseDetails.cshtml"
                      Write(localizer["Case Details"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
	<div class=""card-tools"">
	 <button type=""button"" class=""btn btn-tool"" data-card-widget=""remove"" title=""Remove"" onclick=""redirect()"">
	  <i class=""fas fa-times""></i>
	 </button>
	</div>
   </div>
   <div class=""card-body"">
	<div class=""row"">
	 <div class=""col-12"">
	  <div class=""row"">
	   <div class=""col-12"">
		<div class=""info-box bg-light"">
		 <div class=""row"">
		  <div class=""col-4"">
		   <div class=""info-box-content"">
			<strong><i class=""fas fa-book mr-1""></i>");
#nullable restore
#line 48 "E:\PBTProject\Ajit Singh\CrimeReportingSystem\CRS\CRS.Web\Views\Crime\ViewCaseDetails.cshtml"
                                               Write(localizer["Case Number"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </strong>\r\n\t\t\t<p class=\"text-muted\" id=\"pCaseNumber\">\r\n\t\t\t</p>\r\n\t\t   </div>\r\n\t\t  </div>\r\n\t\t  <div class=\"col-4\">\r\n\t\t   <div class=\"info-box-content\">\r\n\t\t\t<strong><i class=\"fas fa-book mr-1\"></i>");
#nullable restore
#line 55 "E:\PBTProject\Ajit Singh\CrimeReportingSystem\CRS\CRS.Web\Views\Crime\ViewCaseDetails.cshtml"
                                               Write(localizer["Case Type"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </strong>\r\n\t\t\t<p class=\"text-muted\" id=\"pcasetype\">\r\n\t\t\t</p>\r\n\t\t   </div>\r\n\t\t  </div>\r\n\t\t  <div class=\"col-4\">\r\n\t\t   <div class=\"info-box-content\">\r\n\t\t\t<strong><i class=\"fas fa-book mr-1\"></i>");
#nullable restore
#line 62 "E:\PBTProject\Ajit Singh\CrimeReportingSystem\CRS\CRS.Web\Views\Crime\ViewCaseDetails.cshtml"
                                               Write(localizer["Complainer Name"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </strong>\r\n\t\t\t<p class=\"text-muted\" id=\"pComplainerName\">\r\n\t\t\t</p>\r\n\t\t   </div>\r\n\t\t  </div>\r\n\t\t  <div class=\"col-4\">\r\n\t\t   <div class=\"info-box-content\">\r\n\t\t\t<strong><i class=\"fas fa-book mr-1\"></i>");
#nullable restore
#line 69 "E:\PBTProject\Ajit Singh\CrimeReportingSystem\CRS\CRS.Web\Views\Crime\ViewCaseDetails.cshtml"
                                               Write(localizer["Complainer ContactNo"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </strong>\r\n\t\t\t<p class=\"text-muted\" id=\"pComplainerContactNo\">\r\n\t\t\t</p>\r\n\t\t   </div>\r\n\t\t  </div>\r\n\t\t  <div class=\"col-4\">\r\n\t\t   <div class=\"info-box-content\">\r\n\t\t\t<strong><i class=\"fas fa-book mr-1\"></i>");
#nullable restore
#line 76 "E:\PBTProject\Ajit Singh\CrimeReportingSystem\CRS\CRS.Web\Views\Crime\ViewCaseDetails.cshtml"
                                               Write(localizer["Complainer Address"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </strong>\r\n\t\t\t<p class=\"text-muted\" id=\"pComplainerAddress\">\r\n\t\t\t</p>\r\n\t\t   </div>\r\n\t\t  </div>\r\n\t\t </div>\r\n\t\t</div>\r\n\t   </div>\r\n\r\n\t  </div>\r\n\t  <div class=\"row\">\r\n\t   <div class=\"col-12\">\r\n\t\t<h4>");
#nullable restore
#line 88 "E:\PBTProject\Ajit Singh\CrimeReportingSystem\CRS\CRS.Web\Views\Crime\ViewCaseDetails.cshtml"
       Write(localizer["Recent Activity"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h4>
		<div class=""post"">
		 <div class=""user-block"">
		  <img class=""img-circle img-bordered-sm"" src=""../../dist/img/avatar5.png"" alt=""user image"">
		  <span class=""username"">
		   <a id=""username""></a>
		  </span>
		  <span class=""description"" id=""datecreate""></span>
		 </div>

		 <div class=""row"" id=""loghistory"">
		  <!-- /.user-block -->



		 </div>
		</div>

	   </div>
	  </div>
	 </div>
	</div>
   </div>
  </div>
  <!-- /.card-body -->
 </div>
 <!-- /.container-fluid -->
</section>
<!-- /.content -->
");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"

<script>
	var x = document.getElementById(""overlay"");
	const urlSearchParams = new URLSearchParams(window.location.search);
	const params = Object.fromEntries(urlSearchParams.entries());
	var paramId = params.Id;

	function redirect() {

		window.location.replace('/Crime/ViewCase');

	}

		$(document).ready(function () {

			GetMSTCrimeHeadLogByCaseId();
			GetMSTCrimeHeadLogHistoryByCaseId();
		});

		function GetMSTCrimeHeadLogByCaseId(){

		$.ajax({
			type: ""POST"",
			data: {
				""id"": paramId
			},
			url: 'GetMSTCrimeHeadLogByCaseId',
			dataSrc: '',
			success: function (response) {

				document.getElementById(""pcasetype"").innerHTML = response[0].crimeName;
				document.getElementById(""pCaseNumber"").innerHTML = response[0].caseNo;
				document.getElementById(""pComplainerName"").innerHTML = response[0].complainerName;
				document.getElementById(""pComplainerContactNo"").innerHTML = response[0].complainerContactNo;
				document.getElementById(""pComplainerAddress"").inne");
                WriteLiteral(@"rHTML = response[0].complainerAddress;

			},
			error: function (xhr, status, error) {
				// var err = eval(""("" + xhr.responseText + "")"");
				console.log(xhr.responseText);
			}
			});
		}

		function GetMSTCrimeHeadLogHistoryByCaseId(){
			//alert('hi');
			var Logdiv = """";
		$.ajax({
			type: ""POST"",
			data: {
				""id"": paramId
			},
			url: 'GetMSTCrimeHeadLogHistoryByCaseId',
			dataSrc: '',
			success: function (response) {
				document.getElementById(""username"").innerHTML = response[0].createdBy;
				document.getElementById(""datecreate"").innerHTML = response[0].createdOn;
				for (var i = 0; i < response.length; i++) {

				Logdiv += '<div class=""col-4"">';
				Logdiv += '<div class=""info-box-content"">';
				Logdiv += '<strong>'+(i+1)+') '+response[i].crimeHeadName+'</strong>';
				Logdiv += '<p class=""text-muted"">'+response[i].value+'</p>';
				Logdiv += '</div></div>';

			}
			   $(""#loghistory"").append(Logdiv);
			},
			error: function (xhr, status, error) {
			");
                WriteLiteral("\t// var err = eval(\"(\" + xhr.responseText + \")\");\r\n\t\t\t\tconsole.log(xhr.responseText);\r\n\t\t\t}\r\n\t\t\t});\r\n\t\t}\r\n\r\n</script>\r\n");
            }
            );
            WriteLiteral("\r\n\r\n\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Microsoft.AspNetCore.Mvc.Localization.IViewLocalizer localizer { get; private set; }
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
