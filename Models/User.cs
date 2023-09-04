#pragma warning disable CS8618
using System. ComponentModel.DataAnnotations;
namespace FormSubmit.Models;

public class User
{
    [Required]
    [MinLength(2, ErrorMessage ="Name must be at least 2 characters.")]
    public string Name {get;set;}

    [Required]
    [EmailAddress]
    [Display(Name="Email Address")]
    public string Email {get;set;}

    [Required]
    [DataType(DataType.Date)]
    [PastDate]
    public DateTime DoB {get;set;}

    [Required]
    [MinLength(8, ErrorMessage ="Password must be at least 8 characters long.")]
    public string Password {get;set;}

    [Required]
    [Display(Name="Favorite Odd Number")]
    [OddNumber]
    public int FavOddNum {get;set;}
}


//validation: DOB must be in the past
public class PastDateAttribute: ValidationAttribute
{
    protected override ValidationResult IsValid (object value, ValidationContext validationContext)
    {
        if (((DateTime)value) > DateTime.Now)
        {
            return new ValidationResult ("Date must be in the past");
        } else{
            return ValidationResult.Success;
        }
    }
}


//validation favorite must be a whole odd number
public class OddNumberAttribute: ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if ((int)value %2 == 0)
        {
        return new ValidationResult("Favorite Number Must Be Odd");
        } else {
            return ValidationResult.Success;
        }

    }
}