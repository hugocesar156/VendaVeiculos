using System.ComponentModel.DataAnnotations;
using VendaVeiculos.Shared;

namespace VendaVeiculos.Validations
{
    public class SeminovoUsadoAttribute : ValidationAttribute
    {
        private readonly string _nome;
        public SeminovoUsadoAttribute(string nome) => _nome = nome;
        
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            var propriedade = context.ObjectType.GetProperty(_nome);
            var valor = propriedade.GetValue(context.ObjectInstance);

            var idSituacao = (int)context.ObjectType
                .GetProperty("IdSituacao").GetValue(context.ObjectInstance);

            if (idSituacao == (int)Global.SituacaoVeiculo.Novo && valor != null)
                return new ValidationResult("Valor inválido para o campo");

            if (idSituacao != (int)Global.SituacaoVeiculo.Novo && valor == null)
                return new ValidationResult("Campo obrigatório");

            return ValidationResult.Success;
        }
    }
}
