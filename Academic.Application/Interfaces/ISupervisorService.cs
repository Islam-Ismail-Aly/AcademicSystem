using Academic.Application.DTOs.Supervisor;
using Academic.Application.Utilities;

namespace Academic.Application.Interfaces
{
    public interface ISupervisorService
    {
        Task<APIResponseResult<IEnumerable<SupervisorDTO>>> GetAllSupervisorsAsync();
        Task<APIResponseResult<SupervisorDTO>> GetSupervisorByIdAsync(int id);
        Task<APIResponseResult<bool>> AddSupervisorAsync(SupervisorDTO supervisorDto);
        Task<APIResponseResult<bool>> UpdateSupervisorAsync(SupervisorDTO supervisorDto);
        Task<APIResponseResult<bool>> DeleteSupervisorAsync(int id);
    }
}
