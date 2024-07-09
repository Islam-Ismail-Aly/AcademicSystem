using Academic.Application.DTOs.Role;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Academic.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [SwaggerTag("Roles Management")]
    [Authorize(Roles = "Groups")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _service;

        public RoleController(IRoleService service)
        {
            _service = service;
        }

        // GET api/<RoleController>/5
        [HttpGet("GetGroupRoles/{id}")]
        public async Task<IEnumerable<string>> Get(int id)
        {
            return await _service.GetGroupRoles(id);
        }

        // POST api/<RoleController>
        [HttpPost("Add")]
        public async Task<ApiResponse> Post([FromBody] RoleDTO value)
        {
            return await _service.Add(value);
        }

        // POST api/<RoleController>
        [HttpPost("AddRolesToGroup/{id}")]
        public async Task<IEnumerable<string>> AddRolesToGroup( int id, [FromBody] List<string> roleIds)
        {
            return await _service.SetGroupRoles(id,roleIds);
        }

        // GET api/<RoleController>/5
        [HttpGet("GetAllRoles")]
        public async Task<IEnumerable<RoleDTO>> GetAll()
        {
            return await _service.GetAll();
             
        }


    }
}
