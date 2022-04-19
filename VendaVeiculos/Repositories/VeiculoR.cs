using System;
using VendaVeiculos.Models.Veiculo;

namespace VendaVeiculos.Repositories
{
    public class VeiculoR
    {
        private readonly Data.DatabaseContext _banco;

        public VeiculoR(Data.DatabaseContext banco) => _banco = banco;

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
