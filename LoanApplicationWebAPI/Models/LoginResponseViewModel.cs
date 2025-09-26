namespace LoanApplicationWebAPI.Models
{
    public class LoginResponseViewModel
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
        public string Token { get; set; } // JWT token
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
