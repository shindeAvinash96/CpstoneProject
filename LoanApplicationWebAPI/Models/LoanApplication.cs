using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LoanApplicationWebAPI.Models
{
    public class LoanApplication
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LoanApplicationId { get; set; }

        [Required]
        public LoanType LoanType { get; set; }

        [Required]
        [Range(1000, double.MaxValue)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal LoanAmount { get; set; }

        //[Required]
        //[Column(TypeName = "decimal(5,2)")]
        //public decimal InterestRate { get; set; } = 0;

        public ApplicationStatus Status { get; set; }= ApplicationStatus.Pending;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Foreign Keys
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }

        public int LoanOfficerId { get; set; }
        public LoanOfficer? LoanOfficer { get; set; }

        public int LoanSchemeId { get; set; }
        public LoanScheme? LoanScheme { get; set; }

        [JsonIgnore]
        public LoanApproved? LoanApproved { get; set; }
    }
}
