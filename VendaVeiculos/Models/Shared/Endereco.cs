using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VendaVeiculos.Shared;

namespace VendaVeiculos.Models.Shared
{
    public abstract class Endereco
    {
        private string _cep;

        [Column("cep")]
        [Required(ErrorMessage = Global.MensagemCampo.CAMPO_OBRIGATORIO)]
        public string Cep 
        {
            get => _cep; 
            set => _cep = value?.Replace("-", ""); 
        }

        [Column("logradouro")]
        [Required(ErrorMessage = Global.MensagemCampo.CAMPO_OBRIGATORIO)]
        public string Logradouro { get; set; }

        [Column("numero")]
        [Required(ErrorMessage = Global.MensagemCampo.CAMPO_OBRIGATORIO)]
        public string Numero { get; set; }

        [Column("bairro")]
        [Required(ErrorMessage = Global.MensagemCampo.CAMPO_OBRIGATORIO)]
        public string Bairro { get; set; }

        [Column("cidade")]
        [Required(ErrorMessage = Global.MensagemCampo.CAMPO_OBRIGATORIO)]
        public string Cidade { get; set; }

        [Column("uf")]
        [Required(ErrorMessage = Global.MensagemCampo.CAMPO_OBRIGATORIO)]
        public string Uf { get; set; }
    }
}
