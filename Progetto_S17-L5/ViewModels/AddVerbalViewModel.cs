using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Progetto_S17_L5.Models;
using Progetto_S17_L5.ValidationAttributes;

namespace Progetto_S17_L5.ViewModels
{
    public class AddVerbalViewModel
    {
        [Required]
        [Display(Name = "Verbal date")]
        public DateTime VerbalDate { get; set; }

        [Display(Name = "Verbal trascription date")]
        public DateTime VerbalTranscriptionDate { get; set; }

        [Required]
        [StringLength(
            200,
            ErrorMessage = "Address must contains from 3 to 200 chars",
            MinimumLength = 3
        )]
        [Display(Name = "Verbal address")]
        public string? VerbalAddress { get; set; }

        [Required]
        [StringLength(
            100,
            ErrorMessage = "Officier name must contains from 3 to 100 chars",
            MinimumLength = 3
        )]
        [Display(Name = "Officier name")]
        public string? OfficerName { get; set; }

        [Required]
        [Range(0.01, 1000000)]
        [Display(Name = "Amount")]
        public decimal? Amount { get; set; }

        [Required]
        [Range(0, 30)]
        [Display(Name = "Points deduction")]
        public int? PointsDeduction { get; set; }

        [Display(Name = "Trasgressor")]
        public Guid RegisterId { get; set; }

        [Display(Name = "Violation")]
        [MinItems(1, ErrorMessage = "Devi selezionare almeno un elemento.")]
        public List<Guid> ViolationId { get; set; }

        // navigazione
        [ForeignKey("RegisterId")]
        public Register? Register { get; set; }

        public ICollection<VerbalViolation>? VerbalViolations { get; set; }
    }
}
