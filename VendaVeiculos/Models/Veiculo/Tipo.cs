using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VendaVeiculos.Models.Veiculo
{
    [Table("veiculo_tipo")]
    public class Tipo
    {
        [Column("idTipo"), Key]
        public int IdTipo { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; }
    }
}
