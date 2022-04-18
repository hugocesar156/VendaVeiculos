using Microsoft.AspNetCore.Mvc;
using VendaVeiculos.Models.Veiculo;
using VendaVeiculos.Repositories;

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
    }
}
