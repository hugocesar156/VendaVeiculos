using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VendaVeiculos.Shared;
using VendaVeiculos.Validations;

namespace VendaVeiculos.Models.Veiculo
{
    [Table("veiculo")]
    public class Veiculo
    {
        [Column("idVeiculo"), Key]
        public int IdVeiculo { get; set; }

        [Column("fabricante")]
        [Required(ErrorMessage = Global.MensagemCampo.CAMPO_OBRIGATORIO)]
        public string Fabricante { get; set; }

        [Column("modelo")]
        [Required(ErrorMessage = Global.MensagemCampo.CAMPO_OBRIGATORIO)]
        public string Modelo { get; set; }

        [Column("anoModelo")]
        [Required(ErrorMessage = Global.MensagemCampo.CAMPO_OBRIGATORIO)]
        public string AnoModelo { get; set; }

        [Column("anoFabricacao"), AnoFabricacao]
        [Required(ErrorMessage = Global.MensagemCampo.CAMPO_OBRIGATORIO)]
        public string AnoFabricacao { get; set; }

        [Column("cor")]
        [Required(ErrorMessage = Global.MensagemCampo.CAMPO_OBRIGATORIO)]
        public string Cor { get; set; }

        [Column("chassi")]
        [Required(ErrorMessage = Global.MensagemCampo.CAMPO_OBRIGATORIO)]
        public string Chassi { get; set; }

        [Column("renavam")]
        [Required(ErrorMessage = Global.MensagemCampo.CAMPO_OBRIGATORIO)]
        public string Renavam { get; set; }

        [Column("codigoFipe")]
        [Required(ErrorMessage = Global.MensagemCampo.CAMPO_OBRIGATORIO)]
        public string CodigoFipe { get; set; }

        [Column("valorFipe")]
        [Required(ErrorMessage = Global.MensagemCampo.CAMPO_OBRIGATORIO)]
        public string ValorFipe { get; set; }

        [Column("valorMercado")]
        [Required(ErrorMessage = Global.MensagemCampo.CAMPO_OBRIGATORIO)]
        public string ValorMercado { get; set; }

        [Column("placa"), SeminovoUsado(nameof(Placa))]
        public string Placa { get; set; }

        [Column("quilometragem"), SeminovoUsado(nameof(Odometro)), Odometro]
        public string Odometro { get; set; }

        [Column("idTipo")]
        [Required(ErrorMessage = Global.MensagemCampo.CAMPO_OBRIGATORIO)]
        public int? IdTipo { get; set; }

        [Column("idCombustivel")]
        [Required(ErrorMessage = Global.MensagemCampo.CAMPO_OBRIGATORIO)]
        public int? IdCombustivel { get; set; }

        [Column("idSituacao")]
        [Required(ErrorMessage = Global.MensagemCampo.CAMPO_OBRIGATORIO)]
        public int IdSituacao { get; set; }

        [Column("IdConcessionaria")]
        [Required(ErrorMessage = Global.MensagemCampo.CAMPO_OBRIGATORIO)]
        public int? IdConcessionaria { get; set; }

        [ForeignKey("IdConcessionaria")]
        public Concessionaria.Concessionaria Concessionaria { get; set; }

        [NotMapped]
        public List<Foto> Foto { get; set; }
    }
}
