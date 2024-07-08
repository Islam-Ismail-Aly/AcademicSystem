using Academic.Application.DTOs.Branch;
using Academic.Application.Interfaces;
using Academic.Application.Utilities;
using Academic.Core.Entities;
using Academic.Core.Interfaces;
using AutoMapper;

namespace Academic.Application.Services
{
    public class BranchService : IBranchService
    {
        private readonly IUnitOfWork<Branch> _unitOfWork;
        private readonly IMapper _mapper;

        public BranchService(IUnitOfWork<Branch> unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<APIResponseResult<IEnumerable<BranchDTO>>> GetAllBranchesAsync()
        {
            var branches = _unitOfWork.Entity.GetAllIncluding(s => s.Supervisor);

            if (branches is null)
                return new APIResponseResult<IEnumerable<BranchDTO>>(404, "Branches not found");

            var branchDtos = _mapper.Map<IEnumerable<BranchDTO>>(branches);
            return new APIResponseResult<IEnumerable<BranchDTO>>(branchDtos, "All Branches Retrieved Successfully");
        }

        public async Task<APIResponseResult<IEnumerable<BranchNamesDTO>>> GetBrancheNamesAsync()
        {
            var branches = await _unitOfWork.Entity.GetAllAsync();

            if (branches is null)
                return new APIResponseResult<IEnumerable<BranchNamesDTO>>(404, "Branches not found");

            var branchDtos = _mapper.Map<IEnumerable<BranchNamesDTO>>(branches);
            return new APIResponseResult<IEnumerable<BranchNamesDTO>>(branchDtos, "Branch Names Retrieved Successfully");
        }

        public async Task<APIResponseResult<BranchNamesDTO>> GetBrancheNamesAsync(int id)
        {
            var branch = await _unitOfWork.Entity.GetByIdAsync(id);

            if (branch is null)
                return new APIResponseResult<BranchNamesDTO>(404, "Branches not found");

            var branchDtos = _mapper.Map<BranchNamesDTO>(branch);
            return new APIResponseResult<BranchNamesDTO>(branchDtos, "Branch Retrieved Successfully");
        }

        public async Task<APIResponseResult<BranchDTO>> GetBranchByIdAsync(int id)
        {
            var branch = _unitOfWork.Entity.GetAllIncluding(s => s.Supervisor).FirstOrDefault(s => s.Id == id);

            if (branch is null)
                return new APIResponseResult<BranchDTO>(404, "Branches not found");
            
            var branchDto = _mapper.Map<BranchDTO>(branch);
            return new APIResponseResult<BranchDTO>(branchDto, "Branche Retrieved Successfully");
        }

        public async Task<APIResponseResult<bool>> AddBranchAsync(BranchDTO branchDto)
        {
            var branch = _mapper.Map<Branch>(branchDto);
            await _unitOfWork.Entity.InsertAsync(branch);
            await _unitOfWork.SaveAsync();

            return new APIResponseResult<bool>(true, "Branches added successfully");
        }

        public async Task<APIResponseResult<bool>> UpdateBranchAsync(BranchDTO branchDto)
        {
            var branch = _mapper.Map<Branch>(branchDto);
            await _unitOfWork.Entity.UpdateAsync(branch);
            await _unitOfWork.SaveAsync();
            return new APIResponseResult<bool>(true, "Branches updated successfully");
        }

        public async Task<APIResponseResult<bool>> DeleteBranchAsync(int id)
        {
            var branch = await _unitOfWork.Entity.GetByIdAsync(id);

            if (branch is null)
                return new APIResponseResult<bool>(404, "Branches not found");

            await _unitOfWork.Entity.DeleteAsync(id);
            await _unitOfWork.SaveAsync();

            return new APIResponseResult<bool>(true, "Branches deleted successfully");
        }
    }
}
