using Academic.Application.DTOs.Account;
using Academic.Application.Interfaces;
using Academic.Application.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Academic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "AcademicSystemAPIv1")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        public async Task<ApiResponse>  Register(ApplicationUserDTO dto)
        {
            return await _accountService.Add(dto);
        }
    }
}
