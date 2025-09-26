using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LoanApplicationWebAPI.Models
{
    public class Customer : User
    {
        [StringLength(12, MinimumLength = 12)]
        public string AadharId { get; set; }

        [StringLength(10, MinimumLength = 10)]
        public string PanId { get; set; }

        [Required]
        [Phone]
        public string ContactNumber { get; set; }

        public DateTime DateOfBirth { get; set; }
        public string City { get; set; }

        [JsonIgnore]
        public ICollection<LoanApplication>? LoanApplications { get; set; }
    }
}
