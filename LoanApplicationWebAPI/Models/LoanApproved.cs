using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanApplicationWebAPI.Models
{
    public class LoanApproved
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int LoanApplicationId { get; set; }
        public LoanApplication? LoanApplication { get; set; }

        public int NoOfPayments { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Installment { get; set; }

        public bool IsNPA { get; set; }=false;

        public DateTime StartDate { get; set; }
        public ICollection<Repayment>? Repayments { get; set; } = new List<Repayment>();    
    }
}
