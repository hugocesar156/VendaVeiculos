using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using VendaVeiculos.Models.Veiculo;
using VendaVeiculos.Repositories;
using VendaVeiculos.Shared;

namespace VendaVeiculos.Controllers
{
    public class VeiculoController : Controller
    {
        private readonly ConcessionariaR _reposConcessionaria;
        private readonly VeiculoR _reposVeiculo;

        public VeiculoController(ConcessionariaR reposConcessionaria, VeiculoR reposVeiculo)
        {
            _reposConcessionaria = reposConcessionaria;
            _reposVeiculo = reposVeiculo;
        }

        [HttpGet]
        public IActionResult Cadastro()
        {
            ViewBag.Concessionarias = _reposConcessionaria.Listar();

            return View(new Veiculo());
        }

        [HttpGet("/Veiculo/Edicao/{idVeiculo}")]
        public IActionResult Edicao(int idVeiculo)
        {
            try
            {
                var veiculo = _reposVeiculo.Buscar(idVeiculo);
                TempData["idVeiculo"] = veiculo.IdVeiculo;

                ViewBag.Concessionarias = _reposConcessionaria.Listar();

                return View(veiculo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public PartialViewResult Detalhamento(int idVeiculo)
        {
            try
            {
                return PartialView(_reposVeiculo.Buscar(idVeiculo));
            }
            catch (Exception)
            {
                return PartialView("Detalhamento");
            }
        }

        [HttpGet]
        public IActionResult Lista()
        {
            ViewBag.Titulo = "Lista de veículos";

            try
            {
                var lista = _reposVeiculo.ListarPaginado();
                return View("_Lista", _reposVeiculo.ListarPaginado());
            }
            catch (Exception)
            {
                return View("_Lista");
            }
        }

        [HttpGet]
        public PartialViewResult PaginacaoLista(int pagina, int tamanhoPagina, string pesquisa)
        {
            try
            {
                ViewBag.TamanhoPagina = tamanhoPagina;
                ViewBag.Pesquisa = pesquisa;

                var lista = _reposVeiculo.ListarPaginado(pagina, tamanhoPagina, pesquisa?.Trim()?.ToLower() ?? "");
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
                if (_reposVeiculo.Remover(idObjeto))
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
                return PartialView("Tabela", _reposVeiculo.ListarPaginado());
            }
            catch (Exception)
            {
                return PartialView("Tabela");
            }
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public PartialViewResult ValidarCadastro(Veiculo veiculo, string idFabricante, string idModelo, string idAnoModelo)
        {
            try
            {
                ViewBag.Concessionarias = _reposConcessionaria.Listar();

                if (ModelState.IsValid)
                {
                    if (_reposVeiculo.Salvar(veiculo))
                    {
                        ModelState.Clear();

                        ViewBag.Notificacao = new Dictionary<string, dynamic>
                        {
                            {"tipo", Global.Notificacao.Tipo.Sucesso},
                            {"mensagem", Global.Notificacao.SUCESSO_CADASTRO}
                        };

                        return PartialView(nameof(Cadastro), new Veiculo());
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
                AddModelError(ex.Message, veiculo);
            }

            ViewBag.Fabricante = idFabricante;
            ViewBag.Modelo = idModelo;
            ViewBag.AnoModelo = idAnoModelo;

            return PartialView(nameof(Cadastro), veiculo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult ValidarEdicao(Veiculo veiculo, string idFabricante, string idModelo, string idAnoModelo)
        {
            try
            {
                veiculo.IdVeiculo = int.Parse(TempData["idVeiculo"].ToString());
                TempData["idVeiculo"] = veiculo.IdVeiculo;

                if (ModelState.IsValid)
                {
                    ViewBag.Notificacao = _reposVeiculo.Atualizar(veiculo) ?
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
                AddModelError(ex.Message, veiculo);
            }

            ViewBag.Concessionarias = _reposConcessionaria.Listar();

            ViewBag.Fabricante = idFabricante;
            ViewBag.Modelo = idModelo;
            ViewBag.AnoModelo = idAnoModelo;

            return PartialView(nameof(Edicao), veiculo);
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
