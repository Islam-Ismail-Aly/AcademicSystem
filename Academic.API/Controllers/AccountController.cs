using Academic.Application.DTOs.Account;
using Academic.Application.Interfaces;
using Academic.Application.Utilities;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Academic.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [SwaggerTag("Authentication Management")]
    [ApiExplorerSettings(GroupName = "AcademicSystemAPIv1")]
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
        public async Task<AccountResponseLoginDTO> Login(AccountLoginDTO dto)
        {
            return await _accountService.Login(dto);
        }

        [HttpPost("SignOut")]
        public async Task<ApiResponse> SignOut()
        {
            return await _accountService.SignOut();
        }






    }
}
