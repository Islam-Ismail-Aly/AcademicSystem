namespace Academic.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [SwaggerTag("Branches Management")]
    [ApiExplorerSettings(GroupName = "AcademicSystemAPIv1")]
    public class SupervisorController : ControllerBase
    {
        private readonly ISupervisorService _supervisorService;

        public SupervisorController(ISupervisorService supervisorService)
        {
            _supervisorService = supervisorService;
        }

        [HttpGet("GetAllSupervisors")]
        [SwaggerOperation(Summary = SupervisorControllerSwaggerAttributes.GetAllSupervisorsSummary)]
        [SwaggerResponse(200, SupervisorControllerSwaggerAttributes.GetAllSupervisorsResponse200, typeof(APIResponseResult<IEnumerable<SupervisorDTO>>))]
        [SwaggerResponse(404, SupervisorControllerSwaggerAttributes.GetAllSupervisorsResponse404)]
        public async Task<ActionResult<APIResponseResult<IEnumerable<SupervisorDTO>>>> GetAllSupervisors()
        {
            var result = await _supervisorService.GetAllSupervisorsAsync();

            if (!result.Success)
                return StatusCode(result.StatusCode, result);

            return Ok(result);
        }

        [HttpGet("GetSupervisor/{id:int}")]
        [SwaggerOperation(Summary = SupervisorControllerSwaggerAttributes.GetSupervisorByIdSummary)]
        [SwaggerResponse(200, SupervisorControllerSwaggerAttributes.GetSupervisorByIdResponse200, typeof(APIResponseResult<SupervisorDTO>))]
        [SwaggerResponse(404, SupervisorControllerSwaggerAttributes.GetSupervisorByIdResponse404)]
        public async Task<ActionResult<APIResponseResult<SupervisorDTO>>> GetSupervisor(int id)
        {
            var result = await _supervisorService.GetSupervisorByIdAsync(id);

            if (!result.Success)
                return StatusCode(result.StatusCode, result);

            return Ok(result);
        }

        [HttpPost("CreateSupervisor")]
        [SwaggerOperation(Summary = SupervisorControllerSwaggerAttributes.AddSupervisorSummary)]
        [SwaggerResponse(201, SupervisorControllerSwaggerAttributes.AddSupervisorResponse201, typeof(APIResponseResult<bool>))]
        [SwaggerResponse(400, SupervisorControllerSwaggerAttributes.AddSupervisorResponse400)]
        public async Task<ActionResult<APIResponseResult<bool>>> CreateSupervisor([FromBody] SupervisorDTO supervisorDto)
        {
            var result = await _supervisorService.AddSupervisorAsync(supervisorDto);

            if (!result.Success)
                return StatusCode(result.StatusCode, result);

            return CreatedAtAction(nameof(GetSupervisor), new { id = supervisorDto.Id }, result);
        }

        [HttpPut("UpdateSupervisor/{id:int}")]
        [SwaggerOperation(Summary = SupervisorControllerSwaggerAttributes.UpdateSupervisorSummary)]
        [SwaggerResponse(204, SupervisorControllerSwaggerAttributes.UpdateSupervisorResponse204)]
        [SwaggerResponse(400, SupervisorControllerSwaggerAttributes.UpdateSupervisorResponse400)]
        [SwaggerResponse(404, SupervisorControllerSwaggerAttributes.UpdateSupervisorResponse404)]
        public async Task<ActionResult<APIResponseResult<bool>>> UpdateSupervisor(int id, [FromBody] SupervisorDTO supervisorDto)
        {
            if (id != supervisorDto.Id)
            {
                return BadRequest(new APIResponseResult<bool>(400, "Invalid ID"));
            }
            var result = await _supervisorService.UpdateSupervisorAsync(supervisorDto);

            if (!result.Success)
                return StatusCode(result.StatusCode, result);

            return NoContent();
        }

        [HttpDelete("DeleteSupervisor/{id:int}")]
        [SwaggerOperation(Summary = SupervisorControllerSwaggerAttributes.DeleteSupervisorSummary)]
        [SwaggerResponse(204, SupervisorControllerSwaggerAttributes.DeleteSupervisorResponse204)]
        [SwaggerResponse(404, SupervisorControllerSwaggerAttributes.DeleteSupervisorResponse404)]
        public async Task<ActionResult<APIResponseResult<bool>>> DeleteSupervisor(int id)
        {
            var result = await _supervisorService.DeleteSupervisorAsync(id);

            if (!result.Success)
                return StatusCode(result.StatusCode, result);

            return NoContent();
        }
    }
}
