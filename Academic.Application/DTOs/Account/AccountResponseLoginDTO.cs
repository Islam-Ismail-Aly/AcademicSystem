namespace Academic.Application.DTOs.Account
{
    public class AccountResponseLoginDTO
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public string Group { get; set; }
        public List<string> Permissions { get; set; } = new List<string>();
        public List<string> Roles { get; set; } = new List<string>();
        public bool IsAuthenticated { get; set; }
        public DateTime ExpiresOn { get; set; }
        public string Message { get; set; }
    }
}
