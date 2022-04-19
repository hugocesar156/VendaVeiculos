using System.ComponentModel.DataAnnotations;

namespace VendaVeiculos.Validations
{
    public class OdometroAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            var propriedade = context.ObjectType.GetProperty("Odometro");
            var odometro = int.Parse(propriedade.GetValue(context.ObjectInstance)?.ToString() ?? "0");

            var anoFabricacao = int.Parse(context.ObjectType
                .GetProperty("AnoFabricacao").GetValue(context.ObjectInstance)?.ToString() ?? "0");

            var semiNovo = (int)context.ObjectType
                .GetProperty("IdSituacao").GetValue(context.ObjectInstance) == 2;

            var anoAtual = System.DateTime.Now.Year;
            var anosRodados = anoAtual - anoFabricacao;

            if (anoFabricacao > 0 && semiNovo && (anosRodados > 1 ? odometro / anosRodados > 20000 : odometro > 20000))
                return new ValidationResult("Quilometragem muito alta para um semi-novo");

            return ValidationResult.Success;
        }
    }
}
