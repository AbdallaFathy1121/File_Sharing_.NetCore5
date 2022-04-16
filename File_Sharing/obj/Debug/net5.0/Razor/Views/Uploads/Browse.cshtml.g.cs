#pragma checksum "D:\Asp.net Projects\File_Sharing\File_Sharing\Views\Uploads\Browse.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b14f96aecd1bcee71ce8ab4bc675089ed24939eb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Uploads_Browse), @"mvc.1.0.view", @"/Views/Uploads/Browse.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b14f96aecd1bcee71ce8ab4bc675089ed24939eb", @"/Views/Uploads/Browse.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c96e1a8c33b6374280f73d199495dea0719a507f", @"/Views/_ViewImports.cshtml")]
    public class Views_Uploads_Browse : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<UploadViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Uploads", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Download", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Asp.net Projects\File_Sharing\File_Sharing\Views\Uploads\Browse.cshtml"
  
    ViewData["Title"] = "Browse";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Browse Uploads</h1>\r\n<hr />\r\n<div class=\"container\">\r\n    <div class=\"row\">\r\n");
#nullable restore
#line 11 "D:\Asp.net Projects\File_Sharing\File_Sharing\Views\Uploads\Browse.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"card mb-3 col-12 pl-0\">\r\n                <div class=\"row no-gutters\">\r\n                    <div class=\"col-md-2\">\r\n");
#nullable restore
#line 16 "D:\Asp.net Projects\File_Sharing\File_Sharing\Views\Uploads\Browse.cshtml"
                         if (item.ContentType.ToLower().StartsWith("image"))
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <img class=\"w-100 h-100\"");
            BeginWriteAttribute("src", " src=\"", 509, "\"", 538, 2);
            WriteAttributeValue("", 515, "/Uploads/", 515, 9, true);
#nullable restore
#line 18 "D:\Asp.net Projects\File_Sharing\File_Sharing\Views\Uploads\Browse.cshtml"
WriteAttributeValue("", 524, item.FileName, 524, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"...\">\r\n");
#nullable restore
#line 19 "D:\Asp.net Projects\File_Sharing\File_Sharing\Views\Uploads\Browse.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </div>
                    <div class=""col-md-10"">
                        <div class=""card-body"">
                            <div class=""row"">
                                <div class=""col-6"">
                                    <h5 class=""card-title"">");
#nullable restore
#line 25 "D:\Asp.net Projects\File_Sharing\File_Sharing\Views\Uploads\Browse.cshtml"
                                                      Write(item.OriginalFileName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                                </div>\r\n                                <div class=\"col-3\">\r\n                                    <strong>Size: </strong>\r\n");
#nullable restore
#line 29 "D:\Asp.net Projects\File_Sharing\File_Sharing\Views\Uploads\Browse.cshtml"
                                      
                                        var size = item.Size / 1024; //KB
                                        if (size < 1024)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <span>");
#nullable restore
#line 33 "D:\Asp.net Projects\File_Sharing\File_Sharing\Views\Uploads\Browse.cshtml"
                                             Write(Math.Floor(size));

#line default
#line hidden
#nullable disable
            WriteLiteral(" Kb</span>\r\n");
#nullable restore
#line 34 "D:\Asp.net Projects\File_Sharing\File_Sharing\Views\Uploads\Browse.cshtml"
                                        }
                                        else
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <span>");
#nullable restore
#line 37 "D:\Asp.net Projects\File_Sharing\File_Sharing\Views\Uploads\Browse.cshtml"
                                              Write(Math.Floor(size / 1024));

#line default
#line hidden
#nullable disable
            WriteLiteral(" Mb</span>\r\n");
#nullable restore
#line 38 "D:\Asp.net Projects\File_Sharing\File_Sharing\Views\Uploads\Browse.cshtml"
                                        }
                                    

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </div>\r\n                                <div class=\"col-3\">\r\n                                    <strong>Downloads: ");
#nullable restore
#line 42 "D:\Asp.net Projects\File_Sharing\File_Sharing\Views\Uploads\Browse.cshtml"
                                                  Write(item.DownloadCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>\r\n                                </div>\r\n                            </div>\r\n                            <p class=\"card-text\"><small class=\"text-muted\">");
#nullable restore
#line 45 "D:\Asp.net Projects\File_Sharing\File_Sharing\Views\Uploads\Browse.cshtml"
                                                                      Write(item.CreationDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</small></p>\r\n                            <br />\r\n\r\n                            <div class=\"text-right\">\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b14f96aecd1bcee71ce8ab4bc675089ed24939eb9335", async() => {
                WriteLiteral("Download");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 49 "D:\Asp.net Projects\File_Sharing\File_Sharing\Views\Uploads\Browse.cshtml"
                                                                                    WriteLiteral(item.FileName);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 55 "D:\Asp.net Projects\File_Sharing\File_Sharing\Views\Uploads\Browse.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>\r\n");
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
