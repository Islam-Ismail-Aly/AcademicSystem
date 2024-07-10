using Academic.Application.DTOs.Branch;
using Academic.Application.DTOs.Student;
using Academic.Application.Utilities;

namespace Academic.Application.Interfaces
{
    public interface IBranchService
    {
        Task<APIResponseResult<IEnumerable<BranchDTO>>> GetAllBranchesAsync();
        Task<APIResponseResult<IEnumerable<BranchNamesDTO>>> GetBrancheNamesAsync();
        Task<APIResponseResult<BranchNamesDTO>> GetBrancheNamesAsync(int id);
        Task<APIResponseResult<BranchDTO>> GetBranchByIdAsync(int id);
        Task<APIResponseResult<bool>> AddBranchAsync(BranchDTO branchDto);
        Task<APIResponseResult<bool>> UpdateBranchAsync(BranchDTO branchDto);
        Task<APIResponseResult<bool>> DeleteBranchAsync(int id);
        Task<IEnumerable<StudentBranchesDTO>> GetStudentsByBranchId(int Id);
    }
}
