using System.ComponentModel.DataAnnotations;
using Progetto_S17_L5.Models;

namespace Progetto_S17_L5.ViewModels
{
    public class AddRegisterViewModel
    {
        [Required]
        [StringLength(
            50,
            ErrorMessage = "Name must contains from 2 to 50 chars",
            MinimumLength = 2
        )]
        [Display(Name = "Name")]
        public required string? Name { get; set; }

        [Required]
        [StringLength(
            50,
            ErrorMessage = "Surname must contains from 2 to 50 chars",
            MinimumLength = 2
        )]
        [Display(Name = "Surname")]
        public required string? Surname { get; set; }

        [Required]
        [StringLength(
            200,
            ErrorMessage = "Address must contains from 3 to 200 chars",
            MinimumLength = 3
        )]
        [Display(Name = "Address")]
        public required string? Address { get; set; }

        [Required]
        [StringLength(
            50,
            ErrorMessage = "City must contains from 2 to 50 chars",
            MinimumLength = 2
        )]
        [Display(Name = "City")]
        public required string? City { get; set; }

        [Required]
        [StringLength(5, ErrorMessage = "CAP must contains 5 chars", MinimumLength = 5)]
        [Display(Name = "CAP")]
        public required string? CAP { get; set; }

        [Required]
        [StringLength(
            17,
            ErrorMessage = "Fiscal code must contains from 16 to 17 chars",
            MinimumLength = 16
        )]
        [Display(Name = "Fiscal code")]
        public required string? FiscalCode { get; set; }

        [Display(Name = "Picture")]
        public IFormFile? Picture { get; set; }

        // navigazione
        public ICollection<Verbal>? Verbals { get; set; }
    }
}
