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

        [HttpPost]
        public async Task<ApiResponse> Register(ApplicationUserDTO dto)
        {
            return await _accountService.Add(dto);
        }
    }
}
