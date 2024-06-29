namespace Academic.Application.DTOs.Branch
{
    public class BranchDTO
    {
        public int? Id { get; set; }
        public string? BranchName { get; set; }
        public string? Phone { get; set; }
        public string? Telephone { get; set; }
        public int? SupervisorId { get; set; }
        public string? SupervisorName { get; set; }
    }
}
