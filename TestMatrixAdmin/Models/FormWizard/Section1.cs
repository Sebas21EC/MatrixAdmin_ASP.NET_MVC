using System.ComponentModel.DataAnnotations;

namespace TestMatrixAdmin.Models
{
    public class Section1
    {
        [Required(ErrorMessage = "Please enter your ID number")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Please enter a valid ID number")]
        public string? IdNumber { get; set; }

        [Required(ErrorMessage = "Please enter select one option")]
        public bool? ContactOption { get; set; }

        [Required(ErrorMessage = "Please enter your figer print code")]
        public string? FingerprintCode { get; set; }

        [Required(ErrorMessage = "Please enter your phone number")]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter your email address")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Please confirm your email address")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string? EmailConfirm { get; set; }
    }
}
