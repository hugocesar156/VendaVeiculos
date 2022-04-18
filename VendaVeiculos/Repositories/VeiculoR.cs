namespace VendaVeiculos.Repositories
{
    public class VeiculoR
    {
        private readonly Data.DatabaseContext _banco;

        public VeiculoR(Data.DatabaseContext banco) => _banco = banco;
    }
}
