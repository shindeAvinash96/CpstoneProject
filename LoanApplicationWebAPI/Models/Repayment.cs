using System.ComponentModel.DataAnnotations.Schema;

namespace LoanApplicationWebAPI.Models
{
    public class Repayment
    {
        public int Id { get; set; }

        public int ApprovedLoanId { get; set; }
        public LoanApproved? ApprovedLoan { get; set; }

        public int InstallmentNumber { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        public DateTime DueDate { get; set; }
        public bool IsPaid { get; set; }
        public DateTime? PaidDate { get; set; }
    }
}
