using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FctTestTask.Domain.Validation
{
    public class HttpsUrlAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var url = value as string;
            if (string.IsNullOrEmpty(url))
            {
                return new ValidationResult("URL не должен быть пустым");
            }
            if(!(url.StartsWith("https://") || url.StartsWith("http://")))
            {
                return new ValidationResult("URL должен начинаться с https:// или http://");
            }
            int index = url.IndexOf("//");
            if (!(index >= 0 && url.Length > index + 2))
            {
                return new ValidationResult("Не корректный URL");
            }
            return ValidationResult.Success;
        }
    }
}
