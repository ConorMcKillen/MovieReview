#pragma checksum "C:\Users\44778\Documents\B00800202-McKillen-Conor-Assignment\MMS.Web\Views\Shared\_BreadCrumbs.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f9579aba8e0104f285b604cf4861570f07b5937d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__BreadCrumbs), @"mvc.1.0.view", @"/Views/Shared/_BreadCrumbs.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\44778\Documents\B00800202-McKillen-Conor-Assignment\MMS.Web\Views\_ViewImports.cshtml"
using System.Collections.Generic;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\44778\Documents\B00800202-McKillen-Conor-Assignment\MMS.Web\Views\_ViewImports.cshtml"
using MMS.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\44778\Documents\B00800202-McKillen-Conor-Assignment\MMS.Web\Views\_ViewImports.cshtml"
using MMS.Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\44778\Documents\B00800202-McKillen-Conor-Assignment\MMS.Web\Views\_ViewImports.cshtml"
using MMS.Data.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f9579aba8e0104f285b604cf4861570f07b5937d", @"/Views/Shared/_BreadCrumbs.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3ab85c53f7c37d1d28fc557bce4925c0180d3216", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__BreadCrumbs : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IList<(string,string)>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\44778\Documents\B00800202-McKillen-Conor-Assignment\MMS.Web\Views\Shared\_BreadCrumbs.cshtml"
 if (Model == null)
{
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <nav aria-label=\"breadcrumb\">\r\n        <ol class=\"breadcrumb\">\r\n");
#nullable restore
#line 10 "C:\Users\44778\Documents\B00800202-McKillen-Conor-Assignment\MMS.Web\Views\Shared\_BreadCrumbs.cshtml"
             foreach (var (link,crumb) in Model)
            {
                /*@*/if (link == null || link.Length == 0)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li class=\"breadcrumb-item active\" aria-current=\"page\">");
#nullable restore
#line 14 "C:\Users\44778\Documents\B00800202-McKillen-Conor-Assignment\MMS.Web\Views\Shared\_BreadCrumbs.cshtml"
                                                                      Write(crumb);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 15 "C:\Users\44778\Documents\B00800202-McKillen-Conor-Assignment\MMS.Web\Views\Shared\_BreadCrumbs.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li class=\"breadcrumb-item\">\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 505, "\"", 517, 1);
#nullable restore
#line 19 "C:\Users\44778\Documents\B00800202-McKillen-Conor-Assignment\MMS.Web\Views\Shared\_BreadCrumbs.cshtml"
WriteAttributeValue("", 512, link, 512, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 19 "C:\Users\44778\Documents\B00800202-McKillen-Conor-Assignment\MMS.Web\Views\Shared\_BreadCrumbs.cshtml"
                                   Write(crumb);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                    </li>\r\n");
#nullable restore
#line 21 "C:\Users\44778\Documents\B00800202-McKillen-Conor-Assignment\MMS.Web\Views\Shared\_BreadCrumbs.cshtml"
                }
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </ol>\r\n    </nav>\r\n");
#nullable restore
#line 25 "C:\Users\44778\Documents\B00800202-McKillen-Conor-Assignment\MMS.Web\Views\Shared\_BreadCrumbs.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IList<(string,string)>> Html { get; private set; }
    }
}
#pragma warning restore 1591
