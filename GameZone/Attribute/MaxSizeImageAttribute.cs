using System;
using System.ComponentModel.DataAnnotations;

namespace GameZone.Attribute
{
    public class MaxSizeImageAttribute : ValidationAttribute
    {
        protected readonly int _MaxSizeImage;
        public MaxSizeImageAttribute(int maxSizeImage)
        {
            _MaxSizeImage = maxSizeImage;   
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file is null)
            {
                return ValidationResult.Success; 
            }else if(file.Length > _MaxSizeImage)
            {
                return new ValidationResult($"The Max Image Size Is 1 MG");
            }
            return ValidationResult.Success;
        }
    }
}
