using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using VendaVeiculos.Models.Veiculo;
using VendaVeiculos.Shared;
using X.PagedList;

namespace VendaVeiculos.Repositories
{
    public class VeiculoR
    {
        private readonly Data.DatabaseContext _banco;

        public VeiculoR(Data.DatabaseContext banco) => _banco = banco;

        public bool Atualizar(Veiculo veiculo)
        {
            try
            {
                _banco.Update(veiculo);
                return _banco.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message.Contains("Duplicate entry"))
                    throw ex.InnerException;

                return false;
            }
        }

        public Veiculo Buscar(int idVeiculo)
        {
            try
            {
                return _banco.Veiculo.FirstOrDefault(v => v.IdVeiculo == idVeiculo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IPagedList<Veiculo> ListarPaginado(int pagina = 1, int tamanhoPagina = 25, string pesquisa = "")
        {
            try
            {
                var situacoes = new List<int>();

                foreach (var item in Global.ListarSituacaoVeiculo())
                {
                    if (item.Value.ToLower().Contains(pesquisa))
                        situacoes.Add(item.Key);
                }

                return _banco.Veiculo.Include(v => v.Concessionaria).Select(v => new Veiculo()
                {
                    IdVeiculo = v.IdVeiculo,
                    Fabricante = v.Fabricante,
                    Modelo = v.Modelo,
                    AnoModelo = v.AnoModelo,
                    Cor = v.Cor,
                    ValorMercado = v.ValorMercado,
                    IdSituacao = v.IdSituacao,
                    Concessionaria = new Models.Concessionaria.Concessionaria
                    {
                        IdConcessionaria = v.Concessionaria.IdConcessionaria,
                        NomeFantasia = v.Concessionaria.NomeFantasia
                    }
                }).Where(v =>
                v.Fabricante.ToLower().Contains(pesquisa) ||
                v.Modelo.ToLower().Contains(pesquisa) ||
                v.AnoModelo.ToString().ToLower().Contains(pesquisa) ||
                v.Cor.ToLower().Contains(pesquisa) ||
                v.ValorMercado.ToString().ToLower().Contains(pesquisa) ||
                situacoes.Contains(v.IdSituacao) ||
                v.Concessionaria.NomeFantasia.ToLower().Contains(pesquisa))
                .OrderBy(v => v.Fabricante).ThenBy(v => v.Modelo).ToPagedList(pagina, tamanhoPagina);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Remover(int idVeiculo)
        {
            try
            {
                _banco.Remove(new Veiculo { IdVeiculo = idVeiculo });
                return _banco.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Salvar(Veiculo veiculo)
        {
            try
            {
                _banco.Add(veiculo);
                return _banco.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message.Contains("Duplicate entry"))
                    throw ex.InnerException;

                return false;
            }
        }
    }
}
