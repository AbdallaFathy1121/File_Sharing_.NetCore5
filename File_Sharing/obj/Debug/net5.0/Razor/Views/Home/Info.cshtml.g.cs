#pragma checksum "D:\Asp.net Projects\File_Sharing\File_Sharing\Views\Home\Info.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a04f0cf1dc3a4bce41c59453121cf321c4dd883b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Info), @"mvc.1.0.view", @"/Views/Home/Info.cshtml")]
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
#line 1 "D:\Asp.net Projects\File_Sharing\File_Sharing\Views\_ViewImports.cshtml"
using File_Sharing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Asp.net Projects\File_Sharing\File_Sharing\Views\_ViewImports.cshtml"
using File_Sharing.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Asp.net Projects\File_Sharing\File_Sharing\Views\_ViewImports.cshtml"
using File_Sharing.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a04f0cf1dc3a4bce41c59453121cf321c4dd883b", @"/Views/Home/Info.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c96e1a8c33b6374280f73d199495dea0719a507f", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Info : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "D:\Asp.net Projects\File_Sharing\File_Sharing\Views\Home\Info.cshtml"
  
    ViewData["Title"] = "Info";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Info</h2>\r\n<hr />\r\n\r\n<p>\r\n    <strong>Logged In User: <span>");
#nullable restore
#line 10 "D:\Asp.net Projects\File_Sharing\File_Sharing\Views\Home\Info.cshtml"
                             Write(User.Identity.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></strong>\r\n</p>\r\n\r\n<br />\r\n\r\n<h2>Manage</h2>\r\n<a class=\"btn btn-outline-primary\">\r\n    Change Password\r\n</a>\r\n\r\n");
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