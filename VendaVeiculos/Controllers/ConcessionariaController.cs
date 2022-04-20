using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using VendaVeiculos.Models.Concessionaria;
using VendaVeiculos.Repositories;
using VendaVeiculos.Shared;

namespace VendaVeiculos.Controllers
{
    public class ConcessionariaController : Controller
    {
        private readonly ConcessionariaR _reposConcessionaria;

        public ConcessionariaController(ConcessionariaR reposConcessionaria)
        {
            _reposConcessionaria = reposConcessionaria;
        }

        [HttpGet]
        public IActionResult Cadastro()
        {
            return View(new Concessionaria());
        }

        [HttpGet]
        public IActionResult Edicao(int idConcessionaria)
        {
            try
            {
                var concessionaria = _reposConcessionaria.Buscar(idConcessionaria);
                TempData["idConcessionaria"] = concessionaria.IdConcessionaria;

                return View(concessionaria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public IActionResult Lista()
        {
            ViewBag.Titulo = "Lista de concessionárias";

            try
            {
                return View("_Lista", _reposConcessionaria.ListarPaginado());
            }
            catch (Exception)
            {
                return View("_Lista");
            }
        }

        [HttpGet]
        public PartialViewResult Detalhamento(int idConcessionaria)
        {
            try
            {
                return PartialView(_reposConcessionaria.Buscar(idConcessionaria));
            }
            catch (Exception)
            {
                return PartialView("Detalhamento");
            }
        }

        [HttpGet]
        public PartialViewResult PaginacaoLista(int pagina, int tamanhoPagina, string pesquisa)
        {
            try
            {
                ViewBag.TamanhoPagina = tamanhoPagina;
                ViewBag.Pesquisa = pesquisa;

                var lista = _reposConcessionaria.ListarPaginado(pagina, tamanhoPagina, pesquisa?.Trim()?.ToLower() ?? "");
                return PartialView("Tabela", lista);
            }
            catch (Exception)
            {
                return PartialView("Tabela");
            }
        }

        [HttpGet]
        public PartialViewResult RemoverRegistro(int idObjeto)
        {
            try
            {
                if (_reposConcessionaria.Remover(idObjeto))
                {
                    ViewBag.Notificacao = new Dictionary<string, dynamic>
                    {
                        {"tipo", Global.Notificacao.Tipo.Sucesso},
                        {"mensagem", Global.Notificacao.SUCESSO_REMOCAO}
                    };
                }  
            }
            catch (Exception)
            {
                ViewBag.Notificacao = new Dictionary<string, dynamic>
                {
                    {"tipo", Global.Notificacao.Tipo.Falha},
                    {"mensagem", Global.Notificacao.ERRO_REMOCAO}
                };
            }

            try
            {
                return PartialView("Tabela", _reposConcessionaria.ListarPaginado());
            }
            catch (Exception)
            {
                return PartialView("Tabela");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult ValidarCadastro(Concessionaria concessionaria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (_reposConcessionaria.Salvar(concessionaria))
                    {
                        ModelState.Clear();

                        ViewBag.Notificacao = new Dictionary<string, dynamic>
                        {
                            {"tipo", Global.Notificacao.Tipo.Sucesso},
                            {"mensagem", Global.Notificacao.SUCESSO_CADASTRO}
                        };

                        return PartialView(nameof(Cadastro), new Concessionaria());
                    }

                    ViewBag.Notificacao = new Dictionary<string, dynamic>
                    {
                        {"tipo", Global.Notificacao.Tipo.Falha},
                        {"mensagem", Global.Notificacao.ERRO_CADASTRO}
                    };
                }
            }
            catch (Exception ex)
            {
                AddModelError(ex.Message, concessionaria);
            }

            return PartialView(nameof(Cadastro), concessionaria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult ValidarEdicao(Concessionaria concessionaria)
        {
            try
            {
                concessionaria.IdConcessionaria = int.Parse(TempData["idConcessionaria"].ToString());
                TempData["idConcessionaria"] = concessionaria.IdConcessionaria;

                if (ModelState.IsValid)
                {
                    ViewBag.Notificacao = _reposConcessionaria.Atualizar(concessionaria) ?
                        new Dictionary<string, dynamic>
                        {
                            {"tipo", Global.Notificacao.Tipo.Sucesso},
                            {"mensagem", Global.Notificacao.SUCESSO_EDICAO}
                        } : 
                        new Dictionary<string, dynamic>
                        {
                            {"tipo", Global.Notificacao.Tipo.Falha},
                            {"mensagem", Global.Notificacao.ERRO_EDICAO}
                        };
                }
            }
            catch (Exception ex)
            {
                AddModelError(ex.Message, concessionaria);
            }

            return PartialView(nameof(Edicao), concessionaria);
        }

        private void AddModelError(string mensagemErro, dynamic obj)
        {
            foreach (var propriedade in obj.GetType().GetProperties())
            {
                if (mensagemErro.ToLower().Contains(propriedade.Name.ToLower()))
                    ModelState.AddModelError(propriedade.Name, Global.MensagemCampo.CAMPO_DUPLICADO);
            }
        }
    }
}
