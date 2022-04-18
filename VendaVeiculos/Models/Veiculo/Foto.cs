namespace VendaVeiculos.Models.Veiculo
{
    public class Foto
    {
        public int IdFoto { get; set; }
        public string Caminho { get; set; }
        public int IdVeiculo { get; set; }
        public Veiculo Veiculo { get; set; }
    }
}
