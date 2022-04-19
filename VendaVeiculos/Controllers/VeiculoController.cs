using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using VendaVeiculos.Models.Concessionaria;
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
