using Academic.Application.DTOs.Dashboard;
using Academic.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Academic.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiExplorerSettings(GroupName = "AcademicSystemAPIv1")]
    [Authorize(Roles = "Users")]
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
