#pragma checksum "D:\Projetos\Venda veículos\plataforma\VendaVeiculos\VendaVeiculos\Views\Concessionaria\Detalhamento.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1a1c24c1b8525468f78f1f64ed1416c3ae3a353b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Concessionaria_Detalhamento), @"mvc.1.0.view", @"/Views/Concessionaria/Detalhamento.cshtml")]
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
#line 1 "D:\Projetos\Venda veículos\plataforma\VendaVeiculos\VendaVeiculos\Views\_ViewImports.cshtml"
using VendaVeiculos;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Projetos\Venda veículos\plataforma\VendaVeiculos\VendaVeiculos\Views\_ViewImports.cshtml"
using VendaVeiculos.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Projetos\Venda veículos\plataforma\VendaVeiculos\VendaVeiculos\Views\_ViewImports.cshtml"
using X.PagedList;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Projetos\Venda veículos\plataforma\VendaVeiculos\VendaVeiculos\Views\_ViewImports.cshtml"
using X.PagedList.Mvc.Core;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Projetos\Venda veículos\plataforma\VendaVeiculos\VendaVeiculos\Views\_ViewImports.cshtml"
using X.PagedList.Web.Common;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\Projetos\Venda veículos\plataforma\VendaVeiculos\VendaVeiculos\Views\Concessionaria\Detalhamento.cshtml"
using VendaVeiculos.Models.Concessionaria;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1a1c24c1b8525468f78f1f64ed1416c3ae3a353b", @"/Views/Concessionaria/Detalhamento.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a231f6a96de3755b9dfbc7ba97dd07eb34430754", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Concessionaria_Detalhamento : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Concessionaria>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/shared/global.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div class=""modal fade"" id=""modal-detalhamento"" tabindex=""-1"" role=""dialog"" aria-hidden=""true"">
    <div class=""modal-dialog modal-dialog-centered modal-md"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"">Registro de concessionária</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                <div class=""card"">
                    <div class=""card-header text-center"">
                        <h5>");
#nullable restore
#line 16 "D:\Projetos\Venda veículos\plataforma\VendaVeiculos\VendaVeiculos\Views\Concessionaria\Detalhamento.cshtml"
                       Write(Model.RazaoSocial);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h5>
                    </div>
                    <div class=""card-body"">
                        <h5 class=""mb-3"">Dados gerais</h5>
                        <ul class=""list-group list-group-flush"">
                            <li class=""list-group-item mb-n2"">
                                <strong>Nome Fantasia: </strong>
                                <label class=""text-capitalize"">");
#nullable restore
#line 23 "D:\Projetos\Venda veículos\plataforma\VendaVeiculos\VendaVeiculos\Views\Concessionaria\Detalhamento.cshtml"
                                                          Write(Model.NomeFantasia);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n                            </li>\r\n                            <li class=\"list-group-item mb-n2\">\r\n                                <strong>CNPJ: </strong>\r\n                                <label class=\"cnpj\">");
#nullable restore
#line 27 "D:\Projetos\Venda veículos\plataforma\VendaVeiculos\VendaVeiculos\Views\Concessionaria\Detalhamento.cshtml"
                                               Write(Model.Cnpj);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</label>
                            </li>
                        </ul>
                        <h5 class=""mb-3"">Contato</h5>
                        <ul class=""list-group list-group-flush"">
                            <li class=""list-group-item mb-n2"">
                                <strong>Email: </strong>
                                <label>");
#nullable restore
#line 34 "D:\Projetos\Venda veículos\plataforma\VendaVeiculos\VendaVeiculos\Views\Concessionaria\Detalhamento.cshtml"
                                  Write(Model.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n                            </li>\r\n                            <li class=\"list-group-item mb-n2\">\r\n                                <strong>Telefone: </strong>\r\n                                <label class=\"telefone\">");
#nullable restore
#line 38 "D:\Projetos\Venda veículos\plataforma\VendaVeiculos\VendaVeiculos\Views\Concessionaria\Detalhamento.cshtml"
                                                   Write(Model.Telefone);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</label>
                            </li>
                        </ul>
                        <h5 class=""mb-3"">Endereço</h5>
                        <ul class=""list-group list-group-flush"">
                            <li class=""list-group-item mb-n2"">
                                <label class=""text-capitalize"">");
#nullable restore
#line 44 "D:\Projetos\Venda veículos\plataforma\VendaVeiculos\VendaVeiculos\Views\Concessionaria\Detalhamento.cshtml"
                                                          Write(Model.Logradouro);

#line default
#line hidden
#nullable disable
            WriteLiteral(", ");
#nullable restore
#line 44 "D:\Projetos\Venda veículos\plataforma\VendaVeiculos\VendaVeiculos\Views\Concessionaria\Detalhamento.cshtml"
                                                                             Write(Model.Bairro);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 44 "D:\Projetos\Venda veículos\plataforma\VendaVeiculos\VendaVeiculos\Views\Concessionaria\Detalhamento.cshtml"
                                                                                             Write(Model.Numero);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n                                <br /><label class=\"text-capitalize\">");
#nullable restore
#line 45 "D:\Projetos\Venda veículos\plataforma\VendaVeiculos\VendaVeiculos\Views\Concessionaria\Detalhamento.cshtml"
                                                                Write(Model.Cidade);

#line default
#line hidden
#nullable disable
            WriteLiteral(", ");
#nullable restore
#line 45 "D:\Projetos\Venda veículos\plataforma\VendaVeiculos\VendaVeiculos\Views\Concessionaria\Detalhamento.cshtml"
                                                                               Write(Model.Uf);

#line default
#line hidden
#nullable disable
            WriteLiteral(" | ");
#nullable restore
#line 45 "D:\Projetos\Venda veículos\plataforma\VendaVeiculos\VendaVeiculos\Views\Concessionaria\Detalhamento.cshtml"
                                                                                           Write(Model.Cep);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</label>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-primary"" data-dismiss=""modal"">Fechar</button>
            </div>
        </div>
    </div>
</div>

");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1a1c24c1b8525468f78f1f64ed1416c3ae3a353b10535", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Concessionaria> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
