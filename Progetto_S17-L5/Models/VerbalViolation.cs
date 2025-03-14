using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Progetto_S17_L5.Models
{
    public class VerbalViolation
    {
        [Key]
        public Guid VerbalViolationId { get; set; }

        public Guid VerbalId { get; set; }

        public Guid ViolationId { get; set; }

        // navigazione
        [ForeignKey("VerbalId")]
        public Verbal? Verbal { get; set; }

        [ForeignKey("ViolationId")]
        public Violation? Violation { get; set; }
    }
}
