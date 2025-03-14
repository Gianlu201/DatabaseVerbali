using System.ComponentModel.DataAnnotations;

namespace Progetto_S17_L5.Models
{
    public class Violation
    {
        [Key]
        public Guid ViolationId { get; set; }

        [Required]
        [MaxLength(2000)]
        public string? Description { get; set; }

        // navigazione
        public ICollection<VerbalViolation>? VerbalViolations { get; set; }
    }
}
