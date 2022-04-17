using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VendaVeiculos.Models.Shared;
using VendaVeiculos.Shared;

namespace VendaVeiculos.Models.Concessionaria
{
    [Table("concessionaria")]
    public class Concessionaria : Endereco
    {
        private string _cnpj;
        private string _telefone;

        [Column("idConcessionaria"), Key]
        public int IdConcessionaria { get; set; }

        [Column("cnpj")]
        [Required(ErrorMessage = Global.MensagemCampo.CAMPO_OBRIGATORIO)]
        public string Cnpj 
        { 
            get => _cnpj;
            set => _cnpj = value?.Replace(".", "")
                .Replace("/", "").Replace("-", ""); 
        }

        [Column("razaoSocial")]
        [Required(ErrorMessage = Global.MensagemCampo.CAMPO_OBRIGATORIO)]
        public string RazaoSocial { get; set; }

        [Column("nomeFantasia")]
        [Required(ErrorMessage = Global.MensagemCampo.CAMPO_OBRIGATORIO)]
        public string NomeFantasia { get; set; }

        [Column("email")]
        [Required(ErrorMessage = Global.MensagemCampo.CAMPO_OBRIGATORIO)]
        [EmailAddress(ErrorMessage = Global.MensagemCampo.EMAIL_INVALIDO)]
        public string Email { get; set; }

        [Column("telefone")]
        [Required(ErrorMessage = Global.MensagemCampo.CAMPO_OBRIGATORIO)]
        public string Telefone 
        { 
            get => _telefone; 
            set => _telefone = value?.Replace(" ", ""); 
        }
    }
}
