using System;
using System.ComponentModel.DataAnnotations;

namespace MovieLibraryApi.Dtos;

public class NotInFutureAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not DateTime dt)
            return new ValidationResult("ReleaseDate is required.");

        if (dt > DateTime.UtcNow)
            return new ValidationResult("ReleaseDate cannot be in the future.");

        return ValidationResult.Success;
    }
}