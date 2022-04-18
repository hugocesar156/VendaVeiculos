using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VendaVeiculos.Models.Veiculo
{
    [Table("veiculo")]
    public class Veiculo
    {
        [Column("idVeiculo"), Key]
        public int IdVeiculo { get; set; }

        [Column("placa"),]
        public string Placa { get; set; }

        [Column("modelo")]
        public string Modelo { get; set; }

        [Column("fabricante")]
        public string Fabricante { get; set; }

        [Column("carroceria")]
        public string Carroceria { get; set; }

        [Column("cor")]
        public string Cor { get; set; }

        [Column("anoModelo")]
        public string AnoModelo { get; set; }

        [Column("anoFabricacao")]
        public string AnoFabricacao { get; set; }

        [Column("renavam")]
        public string Renavam { get; set; }

        [Column("codigoFipe")]
        public string CodigoFipe { get; set; }

        [Column("valorFipe")]
        public string ValorFipe { get; set; }

        [Column("quilometragem")]
        public string Quilometagem { get; set; }

        [Column("idTipo")]
        public int IdTipo { get; set; }

        [Column("IdConcessionaria")]
        public int IdConcessionaria { get; set; }

        [ForeignKey("IdTipo")]
        public Tipo Tipo { get; set; }

        [ForeignKey("IdConcessionaria")]
        public Concessionaria.Concessionaria Concessionaria { get; set; }

        [NotMapped]
        public List<Foto> Foto { get; set; }
    }
}
