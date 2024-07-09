using Academic.Application.DTOs.Account;
using Academic.Application.Interfaces;
using Academic.Application.Pagination;
using Academic.Application.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Academic.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [SwaggerTag("Authentication Management")]
    [ApiExplorerSettings(GroupName = "AcademicSystemAPIv1")]
    //[Authorize(Roles = "Users")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("Register")]
        public async Task<ApiResponse> Register(ApplicationUserDTO dto)
        {
            return await _accountService.Add(dto);
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<AccountResponseLoginDTO> Login(AccountLoginDTO dto)
        {
            return await _accountService.Login(dto);
        }

        [HttpPost("SignOut")]
        public async Task<ApiResponse> SignOut()
        {
            return await _accountService.SignOut();
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<ApplicationUserDTO>> GetAll()
        {
            return await _accountService.GetAll();
        }

        [HttpPost("GetById")]
        public async Task<ApplicationUserDTO> GetById([FromBody] UserIdRequestDTO request)
        {
            return await _accountService.GetById(request.UserId, null);
        }

        [HttpPost("DeleteById")]
        public async Task<ApiResponse> DeleteById([FromBody] UserIdRequestDTO request)
        {
            return await _accountService.Delete(request.UserId);
        }

        [HttpPut("Update")]
        public async Task<ApiResponse> Update(ApplicationUserDTO dto)
        {
            return await _accountService.Update(dto);
        }

    }
}
