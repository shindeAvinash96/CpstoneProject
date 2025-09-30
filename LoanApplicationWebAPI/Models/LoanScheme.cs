using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LoanApplicationWebAPI.Models
{
    public class LoanScheme
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LoanSchemeId { get; set; }

        [Required]
        [StringLength(255)]
        public string SchemeName { get; set; }

        [Required]
        public LoanType SchemeType { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal InterestRate { get; set; }

        public string Description { get; set; }
        public int TenureInMonths { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [JsonIgnore]
        public ICollection<LoanApplication>? LoanApplications { get; set; }
    }
}
