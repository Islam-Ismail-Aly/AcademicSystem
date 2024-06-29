using Academic.Application.DTOs.Supervisor;
using Academic.Application.Interfaces;
using Academic.Application.Utilities;
using Academic.Core.Entities;
using Academic.Core.Interfaces;
using AutoMapper;

namespace Academic.Application.Services
{
    public class SupervisorService : ISupervisorService
    {
        private readonly IUnitOfWork<Supervisor> _unitOfWork;
        private readonly IMapper _mapper;

        public SupervisorService(IUnitOfWork<Supervisor> unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<APIResponseResult<IEnumerable<SupervisorDTO>>> GetAllSupervisorsAsync()
        {
            var supervisors = _unitOfWork.Entity.GetAllIncluding(s => s.ApplicationUser.Branch).ToList();
            var supervisorDtos = _mapper.Map<IEnumerable<SupervisorDTO>>(supervisors);
            return new APIResponseResult<IEnumerable<SupervisorDTO>>(supervisorDtos, "All Supervisors Retrieved Successfully");
        }

        public async Task<APIResponseResult<SupervisorDTO>> GetSupervisorByIdAsync(int id)
        {
            var supervisor = _unitOfWork.Entity.GetAllIncluding(s => s.ApplicationUser.Branch).FirstOrDefault(s => s.Id == id);
            if (supervisor == null)
            {
                return new APIResponseResult<SupervisorDTO>(404, "Supervisor not found");
            }
            var supervisorDto = _mapper.Map<SupervisorDTO>(supervisor);
            return new APIResponseResult<SupervisorDTO>(supervisorDto);
        }

        public async Task<APIResponseResult<bool>> AddSupervisorAsync(SupervisorDTO supervisorDto)
        {
            var supervisor = _mapper.Map<Supervisor>(supervisorDto);
            await _unitOfWork.Entity.InsertAsync(supervisor);
            await _unitOfWork.SaveAsync();
            return new APIResponseResult<bool>(true, "Supervisor added successfully");
        }

        public async Task<APIResponseResult<bool>> UpdateSupervisorAsync(SupervisorDTO supervisorDto)
        {
            var supervisor = _mapper.Map<Supervisor>(supervisorDto);
            await _unitOfWork.Entity.UpdateAsync(supervisor);
            await _unitOfWork.SaveAsync();
            return new APIResponseResult<bool>(true, "Supervisor updated successfully");
        }

        public async Task<APIResponseResult<bool>> DeleteSupervisorAsync(int id)
        {
            var supervisor = await _unitOfWork.Entity.GetByIdAsync(id);
            if (supervisor == null)
            {
                return new APIResponseResult<bool>(404, "Supervisor not found");
            }
            await _unitOfWork.Entity.DeleteAsync(id);
            await _unitOfWork.SaveAsync();
            return new APIResponseResult<bool>(true, "Supervisor deleted successfully");
        }
    }
}
