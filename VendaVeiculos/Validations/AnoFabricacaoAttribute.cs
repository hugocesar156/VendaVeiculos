using System.ComponentModel.DataAnnotations;

namespace VendaVeiculos.Validations
{
    public class AnoFabricacaoAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            var propriedade = context.ObjectType.GetProperty("AnoFabricacao");
            var anoFabricacao = int.Parse(propriedade.GetValue(context.ObjectInstance)?.ToString() ?? "0");

            var anoModelo = int.Parse(context.ObjectType
                .GetProperty("AnoModelo").GetValue(context.ObjectInstance)?.ToString() ?? "0");

            if (anoModelo > 0 && (anoModelo - anoFabricacao > 1 || anoModelo < anoFabricacao))
                return new ValidationResult("Valor inválido para o campo");

            return ValidationResult.Success;
        }
    }
}
