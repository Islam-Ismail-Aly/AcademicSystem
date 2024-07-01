namespace Academic.Application.DTOs.Account
{
    public class ApplicationUserDTO
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Language { get; set; }
        public int BranchId { get; set; }
        public int GroupId { get; set; }
        public string Message { get; set; }
    }
}
