using System.ComponentModel.DataAnnotations;

namespace Progetto_S17_L5.Models
{
    public class Register
    {
        [Key]
        public Guid RegisterId { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Surname { get; set; }

        [Required]
        [MaxLength(200)]
        public string? Address { get; set; }

        [Required]
        [MaxLength(50)]
        public string? City { get; set; }

        [Required]
        [MaxLength(6)]
        public string? CAP { get; set; }

        [Required]
        [MaxLength(17)]
        public string? FiscalCode { get; set; }

        public string? Picture { get; set; }

        // navigazione
        public ICollection<Verbal>? Verbals { get; set; }

        internal async Task ToListAsync()
        {
            throw new NotImplementedException();
        }
    }
}
