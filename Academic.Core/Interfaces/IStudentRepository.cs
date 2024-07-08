using Academic.Core.Entities;

namespace Academic.Core.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllStudentsPerBranchAsync(int branchId);
    }
}
