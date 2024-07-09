using Academic.Application.DTOs.GroupPermission;
using Microsoft.AspNetCore.Authorization;

namespace Academic.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [SwaggerTag("Group Permission Management")]
    [ApiExplorerSettings(GroupName = "AcademicSystemAPIv1")]
    //[Authorize(Roles = "Groups")]
    public class GroupPermissionController : ControllerBase
    {
        private readonly IGroupPermissionService _groupPermissionService;

        public GroupPermissionController(IGroupPermissionService groupPermissionService)
        {
            _groupPermissionService = groupPermissionService;
        }

        // Group operations
        [HttpGet("Groups")]
        [SwaggerOperation(Summary = GroupPermissionControllerSwaggerAttributes.GetAllGroupsSummary)]
        [SwaggerResponse(200, GroupPermissionControllerSwaggerAttributes.GetAllGroupsResponse200, typeof(APIResponseResult<IEnumerable<GroupDTO>>))]
        [SwaggerResponse(404, GroupPermissionControllerSwaggerAttributes.GetAllGroupsResponse404)]
        public async Task<ActionResult<APIResponseResult<IEnumerable<GroupDTO>>>> GetAllGroups()
        {
            var result = await _groupPermissionService.GetAllGroupsAsync();
            if (!result.Success)
                return StatusCode(result.StatusCode, result);
            return Ok(result);
        }

        [HttpGet("Groups/{id:int}")]
        [SwaggerOperation(Summary = GroupPermissionControllerSwaggerAttributes.GetGroupByIdSummary)]
        [SwaggerResponse(200, GroupPermissionControllerSwaggerAttributes.GetGroupByIdResponse200, typeof(APIResponseResult<GroupDTO>))]
        [SwaggerResponse(404, GroupPermissionControllerSwaggerAttributes.GetGroupByIdResponse404)]
        public async Task<ActionResult<APIResponseResult<GroupDTO>>> GetGroupById(int id)
        {
            var result = await _groupPermissionService.GetGroupByIdAsync(id);
            if (!result.Success)
                return StatusCode(result.StatusCode, result);
            return Ok(result);
        }

        [HttpPost("Groups")]
        [SwaggerOperation(Summary = GroupPermissionControllerSwaggerAttributes.AddGroupSummary)]
        [SwaggerResponse(201, GroupPermissionControllerSwaggerAttributes.AddGroupResponse201, typeof(APIResponseResult<bool>))]
        [SwaggerResponse(400, GroupPermissionControllerSwaggerAttributes.AddGroupResponse400)]
        public async Task<ActionResult<APIResponseResult<bool>>> AddGroup([FromBody] GroupDTO groupDto)
        {
            var result = await _groupPermissionService.AddGroupAsync(groupDto);
            if (!result.Success)
                return StatusCode(result.StatusCode, result);
            return CreatedAtAction(nameof(GetGroupById), new { id = groupDto.Id }, result);
        }

        [HttpPut("Groups/{id:int}")]
        [SwaggerOperation(Summary = GroupPermissionControllerSwaggerAttributes.UpdateGroupSummary)]
        [SwaggerResponse(204, GroupPermissionControllerSwaggerAttributes.UpdateGroupResponse204)]
        [SwaggerResponse(400, GroupPermissionControllerSwaggerAttributes.UpdateGroupResponse400)]
        [SwaggerResponse(404, GroupPermissionControllerSwaggerAttributes.UpdateGroupResponse404)]
        public async Task<ActionResult<APIResponseResult<bool>>> UpdateGroup(int id, [FromBody] GroupDTO groupDto)
        {
            if (id != groupDto.Id)
                return BadRequest(new APIResponseResult<bool>(400, "Invalid ID"));

            var result = await _groupPermissionService.UpdateGroupAsync(groupDto);
            if (!result.Success)
                return StatusCode(result.StatusCode, result);
            return NoContent();
        }

        [HttpDelete("Groups/{id:int}")]
        [SwaggerOperation(Summary = GroupPermissionControllerSwaggerAttributes.DeleteGroupSummary)]
        [SwaggerResponse(204, GroupPermissionControllerSwaggerAttributes.DeleteGroupResponse204)]
        [SwaggerResponse(404, GroupPermissionControllerSwaggerAttributes.DeleteGroupResponse404)]
        public async Task<ActionResult<APIResponseResult<bool>>> DeleteGroup(int id)
        {
            var result = await _groupPermissionService.DeleteGroupAsync(id);
            if (!result.Success)
                return StatusCode(result.StatusCode, result);
            return NoContent();
        }

        [HttpPost("Groups/GetGroupByName")]
        [SwaggerOperation(Summary = GroupPermissionControllerSwaggerAttributes.DeleteGroupSummary)]
        [SwaggerResponse(204, GroupPermissionControllerSwaggerAttributes.DeleteGroupResponse204)]
        [SwaggerResponse(404, GroupPermissionControllerSwaggerAttributes.DeleteGroupResponse404)]
        public async Task<ActionResult<APIResponseResult<GroupDTO>>> GetGroupByName(GroupName name)
        {
            var result = await _groupPermissionService.GetGroupByNameAsync(name.name);
            if (!result.Success)
                    return NoContent();
               return StatusCode(result.StatusCode, result);
        }

        // Permission operations
        [HttpGet("Permissions")]
        [SwaggerOperation(Summary = GroupPermissionControllerSwaggerAttributes.GetAllPermissionsSummary)]
        [SwaggerResponse(200, GroupPermissionControllerSwaggerAttributes.GetAllPermissionsResponse200, typeof(APIResponseResult<IEnumerable<PermissionDTO>>))]
        [SwaggerResponse(404, GroupPermissionControllerSwaggerAttributes.GetAllPermissionsResponse404)]
        public async Task<ActionResult<APIResponseResult<IEnumerable<PermissionDTO>>>> GetAllPermissions()
        {
            var result = await _groupPermissionService.GetAllPermissionsAsync();
            if (!result.Success)
                return StatusCode(result.StatusCode, result);
            return Ok(result);
        }

        [HttpGet("Permissions/{id:int}")]
        [SwaggerOperation(Summary = GroupPermissionControllerSwaggerAttributes.GetPermissionByIdSummary)]
        [SwaggerResponse(200, GroupPermissionControllerSwaggerAttributes.GetPermissionByIdResponse200, typeof(APIResponseResult<PermissionDTO>))]
        [SwaggerResponse(404, GroupPermissionControllerSwaggerAttributes.GetPermissionByIdResponse404)]
        public async Task<ActionResult<APIResponseResult<PermissionDTO>>> GetPermissionById(int id)
        {
            var result = await _groupPermissionService.GetPermissionByIdAsync(id);
            if (!result.Success)
                return StatusCode(result.StatusCode, result);
            return Ok(result);
        }

        [HttpPost("Permissions")]
        [SwaggerOperation(Summary = GroupPermissionControllerSwaggerAttributes.AddPermissionSummary)]
        [SwaggerResponse(201, GroupPermissionControllerSwaggerAttributes.AddPermissionResponse201, typeof(APIResponseResult<bool>))]
        [SwaggerResponse(400, GroupPermissionControllerSwaggerAttributes.AddPermissionResponse400)]
        public async Task<ActionResult<APIResponseResult<bool>>> AddPermission([FromBody] PermissionDTO permissionDto)
        {
            var result = await _groupPermissionService.AddPermissionAsync(permissionDto);
            if (!result.Success)
                return StatusCode(result.StatusCode, result);
            return CreatedAtAction(nameof(GetPermissionById), new { id = permissionDto.Id }, result);
        }

        [HttpPut("Permissions/{id:int}")]
        [SwaggerOperation(Summary = GroupPermissionControllerSwaggerAttributes.UpdatePermissionSummary)]
        [SwaggerResponse(204, GroupPermissionControllerSwaggerAttributes.UpdatePermissionResponse204)]
        [SwaggerResponse(400, GroupPermissionControllerSwaggerAttributes.UpdatePermissionResponse400)]
        [SwaggerResponse(404, GroupPermissionControllerSwaggerAttributes.UpdatePermissionResponse404)]
        public async Task<ActionResult<APIResponseResult<bool>>> UpdatePermission(int id, [FromBody] PermissionDTO permissionDto)
        {
            if (id != permissionDto.Id)
                return BadRequest(new APIResponseResult<bool>(400, "Invalid ID"));

            var result = await _groupPermissionService.UpdatePermissionAsync(permissionDto);
            if (!result.Success)
                return StatusCode(result.StatusCode, result);
            return NoContent();
        }

        [HttpDelete("Permissions/{id:int}")]
        [SwaggerOperation(Summary = GroupPermissionControllerSwaggerAttributes.DeletePermissionSummary)]
        [SwaggerResponse(204, GroupPermissionControllerSwaggerAttributes.DeletePermissionResponse204)]
        [SwaggerResponse(404, GroupPermissionControllerSwaggerAttributes.DeletePermissionResponse404)]
        public async Task<ActionResult<APIResponseResult<bool>>> DeletePermission(int id)
        {
            var result = await _groupPermissionService.DeletePermissionAsync(id);
            if (!result.Success)
                return StatusCode(result.StatusCode, result);
            return NoContent();
        }

        #region GroupPermission operations
        // GroupPermission operations
        //[HttpGet("GroupPermissions")]
        //[SwaggerOperation(Summary = GroupPermissionControllerSwaggerAttributes.GetAllGroupPermissionsSummary)]
        //[SwaggerResponse(200, GroupPermissionControllerSwaggerAttributes.GetAllGroupPermissionsResponse200, typeof(APIResponseResult<IEnumerable<GroupPermissionDTO>>))]
        //[SwaggerResponse(404, GroupPermissionControllerSwaggerAttributes.GetAllGroupPermissionsResponse404)]
        //public async Task<ActionResult<APIResponseResult<IEnumerable<GroupPermissionDTO>>>> GetAllGroupPermissions()
        //{
        //    var result = await _groupPermissionService.GetAllGroupPermissionsAsync();
        //    if (!result.Success)
        //        return StatusCode(result.StatusCode, result);
        //    return Ok(result);
        //}

        //[HttpGet("GroupPermissions/{groupId:int}/{permissionId:int}")]
        //[SwaggerOperation(Summary = GroupPermissionControllerSwaggerAttributes.GetGroupPermissionByIdSummary)]
        //[SwaggerResponse(200, GroupPermissionControllerSwaggerAttributes.GetGroupPermissionByIdResponse200, typeof(APIResponseResult<GroupPermissionDTO>))]
        //[SwaggerResponse(404, GroupPermissionControllerSwaggerAttributes.GetGroupPermissionByIdResponse404)]
        //public async Task<ActionResult<APIResponseResult<GroupPermissionDTO>>> GetGroupPermissionById(int groupId, int permissionId)
        //{
        //    var result = await _groupPermissionService.GetGroupPermissionByIdAsync(groupId, permissionId);
        //    if (!result.Success)
        //        return StatusCode(result.StatusCode, result);
        //    return Ok(result);
        //}

        //[HttpPost("GroupPermissions")]
        //[SwaggerOperation(Summary = GroupPermissionControllerSwaggerAttributes.AddGroupPermissionSummary)]
        //[SwaggerResponse(201, GroupPermissionControllerSwaggerAttributes.AddGroupPermissionResponse201, typeof(APIResponseResult<bool>))]
        //[SwaggerResponse(400, GroupPermissionControllerSwaggerAttributes.AddGroupPermissionResponse400)]
        //public async Task<ActionResult<APIResponseResult<bool>>> AddGroupPermission([FromBody] GroupPermissionDTO groupPermissionDto)
        //{
        //    var result = await _groupPermissionService.AddGroupPermissionAsync(groupPermissionDto);
        //    if (!result.Success)
        //        return StatusCode(result.StatusCode, result);
        //    return CreatedAtAction(nameof(GetGroupPermissionById), new { groupId = groupPermissionDto.GroupId, permissionId = groupPermissionDto.PermissionId }, result);
        //}

        //[HttpPut("GroupPermissions/{groupId:int}/{permissionId:int}")]
        //[SwaggerOperation(Summary = GroupPermissionControllerSwaggerAttributes.UpdateGroupPermissionSummary)]
        //[SwaggerResponse(204, GroupPermissionControllerSwaggerAttributes.UpdateGroupPermissionResponse204)]
        //[SwaggerResponse(400, GroupPermissionControllerSwaggerAttributes.UpdateGroupPermissionResponse400)]
        //[SwaggerResponse(404, GroupPermissionControllerSwaggerAttributes.UpdateGroupPermissionResponse404)]
        //public async Task<ActionResult<APIResponseResult<bool>>> UpdateGroupPermission(int groupId, int permissionId, [FromBody] GroupPermissionDTO groupPermissionDto)
        //{
        //    if (groupId != groupPermissionDto.GroupId || permissionId != groupPermissionDto.PermissionId)
        //        return BadRequest(new APIResponseResult<bool>(400, "Invalid ID"));

        //    var result = await _groupPermissionService.UpdateGroupPermissionAsync(groupPermissionDto);
        //    if (!result.Success)
        //        return StatusCode(result.StatusCode, result);
        //    return NoContent();
        //}

        //[HttpDelete("GroupPermissions/{groupId:int}/{permissionId:int}")]
        //[SwaggerOperation(Summary = GroupPermissionControllerSwaggerAttributes.DeleteGroupPermissionSummary)]
        //[SwaggerResponse(204, GroupPermissionControllerSwaggerAttributes.DeleteGroupPermissionResponse204)]
        //[SwaggerResponse(404, GroupPermissionControllerSwaggerAttributes.DeleteGroupPermissionResponse404)]
        //public async Task<ActionResult<APIResponseResult<bool>>> DeleteGroupPermission(int groupId, int permissionId)
        //{
        //    var result = await _groupPermissionService.DeleteGroupPermissionAsync(groupId, permissionId);
        //    if (!result.Success)
        //        return StatusCode(result.StatusCode, result);
        //    return NoContent();
        //}
        #endregion
    }
}
