using Academic.Application.DTOs.GroupPermission;
using Academic.Application.Utilities;

namespace Academic.Application.Interfaces
{
    public interface IGroupPermissionService
    {
        // Group operations
        Task<APIResponseResult<IEnumerable<GroupDTO>>> GetAllGroupsAsync();
        Task<APIResponseResult<GroupDTO>> GetGroupByIdAsync(int id);
        Task<APIResponseResult<bool>> AddGroupAsync(GroupDTO groupDto);
        Task<APIResponseResult<bool>> UpdateGroupAsync(GroupDTO groupDto);
        Task<APIResponseResult<bool>> DeleteGroupAsync(int id);
        Task<APIResponseResult<GroupDTO>> GetGroupByNameAsync(string name);

        // Permission operations
        Task<APIResponseResult<IEnumerable<PermissionDTO>>> GetAllPermissionsAsync();
        Task<APIResponseResult<PermissionDTO>> GetPermissionByIdAsync(int id);
        Task<APIResponseResult<bool>> AddPermissionAsync(PermissionDTO permissionDto);
        Task<APIResponseResult<bool>> UpdatePermissionAsync(PermissionDTO permissionDto);
        Task<APIResponseResult<bool>> DeletePermissionAsync(int id);

        // GroupPermission operations
        //Task<APIResponseResult<IEnumerable<GroupPermissionDTO>>> GetAllGroupPermissionsAsync();
        //Task<APIResponseResult<GroupPermissionDTO>> GetGroupPermissionByIdAsync(int groupId, int permissionId);
        //Task<APIResponseResult<bool>> AddGroupPermissionAsync(GroupPermissionDTO groupPermissionDto);
        //Task<APIResponseResult<bool>> UpdateGroupPermissionAsync(GroupPermissionDTO groupPermissionDto);
        //Task<APIResponseResult<bool>> DeleteGroupPermissionAsync(int groupId, int permissionId);
    }
}
