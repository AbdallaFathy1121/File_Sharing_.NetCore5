#pragma checksum "D:\Asp.net Projects\File_Sharing\File_Sharing\Views\Uploads\Results.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a4fee9f67c1891a3fd975b1f8b08f8055d8dd56e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Uploads_Results), @"mvc.1.0.view", @"/Views/Uploads/Results.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a4fee9f67c1891a3fd975b1f8b08f8055d8dd56e", @"/Views/Uploads/Results.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c96e1a8c33b6374280f73d199495dea0719a507f", @"/Views/_ViewImports.cshtml")]
    public class Views_Uploads_Results : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<UploadViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Asp.net Projects\File_Sharing\File_Sharing\Views\Uploads\Results.cshtml"
  
    ViewData["Title"] = "Results";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Results</h1>\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 13 "D:\Asp.net Projects\File_Sharing\File_Sharing\Views\Uploads\Results.cshtml"
           Write(Html.DisplayNameFor(model => model.OriginalFileName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 16 "D:\Asp.net Projects\File_Sharing\File_Sharing\Views\Uploads\Results.cshtml"
           Write(Html.DisplayNameFor(model => model.FileName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 19 "D:\Asp.net Projects\File_Sharing\File_Sharing\Views\Uploads\Results.cshtml"
           Write(Html.DisplayNameFor(model => model.ContentType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 22 "D:\Asp.net Projects\File_Sharing\File_Sharing\Views\Uploads\Results.cshtml"
           Write(Html.DisplayNameFor(model => model.Size));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 25 "D:\Asp.net Projects\File_Sharing\File_Sharing\Views\Uploads\Results.cshtml"
           Write(Html.DisplayNameFor(model => model.CreationDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 31 "D:\Asp.net Projects\File_Sharing\File_Sharing\Views\Uploads\Results.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 34 "D:\Asp.net Projects\File_Sharing\File_Sharing\Views\Uploads\Results.cshtml"
           Write(Html.DisplayFor(modelItem => item.OriginalFileName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 37 "D:\Asp.net Projects\File_Sharing\File_Sharing\Views\Uploads\Results.cshtml"
           Write(Html.DisplayFor(modelItem => item.FileName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 40 "D:\Asp.net Projects\File_Sharing\File_Sharing\Views\Uploads\Results.cshtml"
           Write(Html.DisplayFor(modelItem => item.ContentType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 43 "D:\Asp.net Projects\File_Sharing\File_Sharing\Views\Uploads\Results.cshtml"
           Write(Html.DisplayFor(modelItem => item.Size));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 46 "D:\Asp.net Projects\File_Sharing\File_Sharing\Views\Uploads\Results.cshtml"
           Write(Html.DisplayFor(modelItem => item.CreationDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 49 "D:\Asp.net Projects\File_Sharing\File_Sharing\Views\Uploads\Results.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<UploadViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
