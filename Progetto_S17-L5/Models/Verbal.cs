using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Progetto_S17_L5.Models
{
    public class Verbal
    {
        [Key]
        public Guid VerbalId { get; set; }

        [Required]
        public DateTime VerbalDate { get; set; }

        [Required]
        public DateTime VerbalTranscriptionDate { get; set; }

        [Required]
        [MaxLength(200)]
        public string? VerbalAddress { get; set; }

        [Required]
        [MaxLength(100)]
        public string? OfficerName { get; set; }

        [Required]
        [Range(0.01, 1000000)]
        public decimal? Amount { get; set; }

        [Required]
        [Range(0, 30)]
        public int? PointsDeduction { get; set; }

        public Guid RegisterId { get; set; }

        // navigazione
        [ForeignKey("RegisterId")]
        public Register? Register { get; set; }

        public ICollection<VerbalViolation>? VerbalViolations { get; set; }
    }
}
