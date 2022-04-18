using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using VendaVeiculos.Models.Concessionaria;
using X.PagedList;

namespace VendaVeiculos.Repositories
{
    public class ConcessionariaR
    {
        private readonly Data.DatabaseContext _banco;

        public ConcessionariaR(Data.DatabaseContext banco) => _banco = banco;

        public bool Atualizar(Concessionaria concessionaria)
        {
            try
            {
                _banco.Update(concessionaria);
                return _banco.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message.Contains("Duplicate entry"))
                    throw ex.InnerException;

                return false;
            }
        }

        public Concessionaria Buscar(int idConcessionaria)
        {
            try
            {
                return _banco.Concessionaria
                    .FirstOrDefault(c => c.IdConcessionaria == idConcessionaria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Concessionaria> Listar()
        {
            try
            {
                return _banco.Concessionaria.Select(c => new Concessionaria()
                {
                    IdConcessionaria = c.IdConcessionaria,
                    NomeFantasia = c.NomeFantasia,
                    Cnpj = c.Cnpj
                }).OrderBy(c => c.NomeFantasia).ToList();
            }
            catch (Exception)
            {
                return new List<Concessionaria>();
            }
        }

        public IPagedList<Concessionaria> ListarPaginado(int pagina = 1, int tamanhoPagina = 25, string pesquisa = "")
        {
            try
            {
                return _banco.Concessionaria.Select(c => new Concessionaria() 
                {
                    IdConcessionaria = c.IdConcessionaria,
                    RazaoSocial = c.RazaoSocial,
                    NomeFantasia = c.NomeFantasia,
                    Cnpj = c.Cnpj
                }).Where(c => 
                c.RazaoSocial.ToLower().Contains(pesquisa) ||
                c.NomeFantasia.ToLower().Contains(pesquisa) ||
                c.Cnpj.ToLower().Contains(pesquisa))
                .OrderBy(c => c.RazaoSocial).ToPagedList(pagina, tamanhoPagina);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Remover(int idConcessionaria)
        {
            try
            {
                _banco.Remove(new Concessionaria { IdConcessionaria = idConcessionaria });
                return _banco.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Salvar(Concessionaria concessionaria)
        {
            try
            {
                _banco.Add(concessionaria);
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
