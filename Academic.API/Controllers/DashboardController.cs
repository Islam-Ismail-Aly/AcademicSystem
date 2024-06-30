using Academic.Application.DTOs.Dashboard;

namespace Academic.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiExplorerSettings(GroupName = "AcademicSystemAPIv1")]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _service;
        public DashboardController(IDashboardService service)
        {
            _service = service;
        }

        [HttpGet("GetDashboardData")]
        public async Task<ActionResult<DashboardDTO>> GetDashboardData()
        {
            var result = await _service.GetDashboardDataAsync();
            return Ok(result);
        }
    }
}
