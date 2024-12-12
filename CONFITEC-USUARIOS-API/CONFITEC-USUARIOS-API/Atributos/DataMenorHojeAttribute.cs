using System.ComponentModel.DataAnnotations;

namespace CONFITEC_USUARIOS_API.Atributos
{
    public class DataMenorHojeAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is DateTime data && data > DateTime.Now)
            {
                return new ValidationResult("A data de nascimento não pode ser maior que a data atual.");
            }

            return ValidationResult.Success;
        }
    }
}
