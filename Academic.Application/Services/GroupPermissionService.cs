using Academic.Application.DTOs.GroupPermission;
using Academic.Application.Interfaces;
using Academic.Application.Utilities;
using Academic.Core.Entities;
using Academic.Core.Interfaces;
using AutoMapper;
namespace Academic.Application.Services
{
    public class GroupPermissionService : IGroupPermissionService
    {
        private readonly IUnitOfWork<Group> _groupUnitOfWork;
        private readonly IUnitOfWork<Permission> _permissionUnitOfWork;
        private readonly IUnitOfWork<GroupPermission> _groupPermissionUnitOfWork;
        private readonly IMapper _mapper;

        public GroupPermissionService(IUnitOfWork<Group> groupUnitOfWork,
                IUnitOfWork<Permission> permissionUnitOfWork,
                IUnitOfWork<GroupPermission> groupPermissionUnitOfWork,
                IMapper mapper)
        {
            _groupUnitOfWork = groupUnitOfWork;
            _permissionUnitOfWork = permissionUnitOfWork;
            _groupPermissionUnitOfWork = groupPermissionUnitOfWork;
            _mapper = mapper;
        }

        // Group operations
        public async Task<APIResponseResult<IEnumerable<GroupDTO>>> GetAllGroupsAsync()
        {
            var groups = await _groupUnitOfWork.Entity.GetAllAsync();
            var groupDtos = _mapper.Map<IEnumerable<GroupDTO>>(groups);
            return new APIResponseResult<IEnumerable<GroupDTO>>(groupDtos, "All Groups Retrieved Successfully");
        }

        public async Task<APIResponseResult<GroupDTO>> GetGroupByIdAsync(int id)
        {
            var group = await _groupUnitOfWork.Entity.GetByIdAsync(id);

            if (group == null)
                return new APIResponseResult<GroupDTO>(404, "Group not found");

            var groupDto = _mapper.Map<GroupDTO>(group);
            return new APIResponseResult<GroupDTO>(groupDto, "Group Retrieved Successfully");
        }

        public async Task<APIResponseResult<bool>> AddGroupAsync(GroupDTO groupDto)
        {
            var group = _mapper.Map<Group>(groupDto);
            await _groupUnitOfWork.Entity.InsertAsync(group);
            await _groupUnitOfWork.SaveAsync();

            return new APIResponseResult<bool>(true, "Group added successfully");
        }

        public async Task<APIResponseResult<bool>> UpdateGroupAsync(GroupDTO groupDto)
        {
            var group = _mapper.Map<Group>(groupDto);
            await _groupUnitOfWork.Entity.UpdateAsync(group);
            await _groupUnitOfWork.SaveAsync();

            return new APIResponseResult<bool>(true, "Group updated successfully");
        }

        public async Task<APIResponseResult<bool>> DeleteGroupAsync(int id)
        {
            var group = await _groupUnitOfWork.Entity.GetByIdAsync(id);

            if (group == null)
                return new APIResponseResult<bool>(404, "Group not found");

            await _groupUnitOfWork.Entity.DeleteAsync(id);
            await _groupUnitOfWork.SaveAsync();

            return new APIResponseResult<bool>(true, "Group deleted successfully");
        }

        // Permission operations
        public async Task<APIResponseResult<IEnumerable<PermissionDTO>>> GetAllPermissionsAsync()
        {
            var permissions = await _permissionUnitOfWork.Entity.GetAllAsync();
            var permissionDtos = _mapper.Map<IEnumerable<PermissionDTO>>(permissions);
            return new APIResponseResult<IEnumerable<PermissionDTO>>(permissionDtos, "All Permissions Retrieved Successfully");
        }

        public async Task<APIResponseResult<PermissionDTO>> GetPermissionByIdAsync(int id)
        {
            var permission = await _permissionUnitOfWork.Entity.GetByIdAsync(id);

            if (permission == null)
                return new APIResponseResult<PermissionDTO>(404, "Permission not found");

            var permissionDto = _mapper.Map<PermissionDTO>(permission);
            return new APIResponseResult<PermissionDTO>(permissionDto, "Permission Retrieved Successfully");
        }

        public async Task<APIResponseResult<bool>> AddPermissionAsync(PermissionDTO permissionDto)
        {
            var permission = _mapper.Map<Permission>(permissionDto);
            await _permissionUnitOfWork.Entity.InsertAsync(permission);
            await _permissionUnitOfWork.SaveAsync();

            return new APIResponseResult<bool>(true, "Permission added successfully");
        }

        public async Task<APIResponseResult<bool>> UpdatePermissionAsync(PermissionDTO permissionDto)
        {
            var permission = _mapper.Map<Permission>(permissionDto);
            await _permissionUnitOfWork.Entity.UpdateAsync(permission);
            await _permissionUnitOfWork.SaveAsync();

            return new APIResponseResult<bool>(true, "Permission updated successfully");
        }

        public async Task<APIResponseResult<bool>> DeletePermissionAsync(int id)
        {
            var permission = await _permissionUnitOfWork.Entity.GetByIdAsync(id);

            if (permission == null)
                return new APIResponseResult<bool>(404, "Permission not found");

            await _permissionUnitOfWork.Entity.DeleteAsync(id);
            await _permissionUnitOfWork.SaveAsync();

            return new APIResponseResult<bool>(true, "Permission deleted successfully");
        }

        #region GroupPermission operations

        // GroupPermission operations
        //public async Task<APIResponseResult<IEnumerable<GroupPermissionDTO>>> GetAllGroupPermissionsAsync()
        //{
        //    var groupPermissions = await _groupPermissionUnitOfWork.Entity.GetAllAsync();
        //    var groupPermissionDtos = _mapper.Map<IEnumerable<GroupPermissionDTO>>(groupPermissions);
        //    return new APIResponseResult<IEnumerable<GroupPermissionDTO>>(groupPermissionDtos, "All Group Permissions Retrieved Successfully");
        //}

        //public async Task<APIResponseResult<GroupPermissionDTO>> GetGroupPermissionByIdAsync(int groupId, int permissionId)
        //{
        //    var groupPermission = await _groupPermissionUnitOfWork.Entity.FirstOrDefaultAsync(gp => gp.GroupId == groupId && gp.PermissionId == permissionId);

        //    if (groupPermission == null)
        //        return new APIResponseResult<GroupPermissionDTO>(404, "Group Permission not found");

        //    var groupPermissionDto = _mapper.Map<GroupPermissionDTO>(groupPermission);
        //    return new APIResponseResult<GroupPermissionDTO>(groupPermissionDto, "Group Permission Retrieved Successfully");
        //}

        //public async Task<APIResponseResult<bool>> AddGroupPermissionAsync(GroupPermissionDTO groupPermissionDto)
        //{
        //    var groupPermission = _mapper.Map<GroupPermission>(groupPermissionDto);
        //    await _groupPermissionUnitOfWork.Entity.InsertAsync(groupPermission);
        //    await _groupPermissionUnitOfWork.SaveAsync();

        //    return new APIResponseResult<bool>(true, "Group Permission added successfully");
        //}

        //public async Task<APIResponseResult<bool>> UpdateGroupPermissionAsync(GroupPermissionDTO groupPermissionDto)
        //{
        //    var groupPermission = _mapper.Map<GroupPermission>(groupPermissionDto);
        //    _groupPermissionUnitOfWork.Entity.Update(groupPermission);
        //    await _groupPermissionUnitOfWork.SaveAsync();

        //    return new APIResponseResult<bool>(true, "Group Permission updated successfully");
        //}

        //public async Task<APIResponseResult<bool>> DeleteGroupPermissionAsync(int groupId, int permissionId)
        //{
        //    var groupPermission = await _groupPermissionUnitOfWork.Entity.FirstOrDefaultAsync(gp => gp.GroupId == groupId && gp.PermissionId == permissionId);

        //    if (groupPermission == null)
        //        return new APIResponseResult<bool>(404, "Group Permission not found");

        //    await _groupPermissionUnitOfWork.Entity.DeleteAsync(groupPermission);
        //    await _groupPermissionUnitOfWork.SaveAsync();

        //    return new APIResponseResult<bool>(true, "Group Permission deleted successfully");
        //}

        #endregion

    }
}
