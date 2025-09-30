using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LoanApplicationWebAPI.Models
{
    public class LoanOfficer : User
    {
        public string OfficerId { get; set; }
        public string Branch { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [JsonIgnore]
        public ICollection<LoanApplication>? AssignedApplications { get; set; }
    }
}
