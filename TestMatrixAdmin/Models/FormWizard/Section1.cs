using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;


namespace TestMatrixAdmin.Models
{
    public class Section1 : IValidatableObject
    {
        [Required(ErrorMessage = "Please enter your ID number!")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Please enter a valid ID number")]
        public string? IdNumber { get; set; }

        [Required(ErrorMessage = "Please enter select one option")]
        public string? ContactOption { get; set; }

        //[Required(ErrorMessage = "Please enter your figer print code!")]
        //[RegularExpression(@"^[a-zA-Z0-9]{10}$", ErrorMessage = "Please enter a valid figer print code")]
        public string? FingerprintCode { get; set; }

        public bool IsRegisteredUser { get; set; }


        //[Required(ErrorMessage = "Please enter your phone number")
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Please enter a valid phone number")]
        public string? PhoneNumber { get; set; } 

        //[Required(ErrorMessage = "Please enter your email address")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string? Email { get; set; }

        //[Required(ErrorMessage = "Please confirm your email address")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string? EmailConfirm { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ContactOption == "phone")
            {
                if (string.IsNullOrEmpty(PhoneNumber))
                {
                    yield return new ValidationResult("Please enter your phone number.", new[] { nameof(PhoneNumber) });
                }
            }
            else if (ContactOption == "email")
            {
                if (string.IsNullOrEmpty(Email))
                {
                    yield return new ValidationResult("Please enter your email address.", new[] { nameof(Email) });
                }
                if (Email != EmailConfirm)
                {
                    yield return new ValidationResult("The email and confirmation email do not match.", new[] { nameof(EmailConfirm) });
                }
            }
            else
            {
                yield return new ValidationResult("Please select a contact option.", new[] { nameof(ContactOption) });
            }

            if (!IsRegisteredUser)
            {
                if (string.IsNullOrWhiteSpace(FingerprintCode))
                {
                    yield return new ValidationResult("Please enter your fingerprint code!", new[] { nameof(FingerprintCode) });
                }
                else if (!Regex.IsMatch(FingerprintCode, @"^[a-zA-Z0-9]{10}$"))
                {
                    yield return new ValidationResult("Please enter a valid fingerprint code", new[] { nameof(FingerprintCode) });
                }
            }


        }

    }
}
