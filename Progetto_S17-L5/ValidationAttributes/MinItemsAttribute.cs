using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Progetto_S17_L5.ValidationAttributes
{
    public class MinItemsAttribute : ValidationAttribute
    {
        private readonly int _minItems;

        public MinItemsAttribute(int minItems)
        {
            _minItems = minItems;
            ErrorMessage = $"La lista deve contenere almeno {_minItems} elemento/i.";
        }

        protected override ValidationResult IsValid(
            object value,
            ValidationContext validationContext
        )
        {
            if (value is ICollection collection && collection.Count >= _minItems)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(ErrorMessage);
        }
    }
}
