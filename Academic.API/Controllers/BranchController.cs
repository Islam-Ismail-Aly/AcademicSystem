namespace Academic.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [SwaggerTag("Branches Management")]
    [ApiExplorerSettings(GroupName = "AcademicSystemAPIv1")]
    public class BranchController : ControllerBase
    {
        private readonly IBranchService _branchService;

        public BranchController(IBranchService branchService)
        {
            _branchService = branchService;
        }

        [HttpGet("GetAllBranches")]
        [SwaggerOperation(Summary = BranchControllerSwaggerAttributes.GetAllBranchesSummary)]
        [SwaggerResponse(200, BranchControllerSwaggerAttributes.GetAllBranchesResponse200, typeof(APIResponseResult<IEnumerable<BranchDTO>>))]
        [SwaggerResponse(404, BranchControllerSwaggerAttributes.GetAllBranchesResponse404)]
        public async Task<ActionResult<APIResponseResult<IEnumerable<BranchDTO>>>> GetAllBranches()
        {
            var result = await _branchService.GetAllBranchesAsync();

            if (!result.Success)
                return StatusCode(result.StatusCode, result);

            return Ok(result);
        }

        [HttpGet("GetBranchesNames")]
        [SwaggerOperation(Summary = BranchControllerSwaggerAttributes.GetBranchNamesSummary)]
        [SwaggerResponse(200, BranchControllerSwaggerAttributes.GetBranchNamesResponse200, typeof(APIResponseResult<IEnumerable<BranchNamesDTO>>))]
        [SwaggerResponse(404, BranchControllerSwaggerAttributes.GetBranchNamesResponse404)]
        public async Task<ActionResult<APIResponseResult<IEnumerable<BranchNamesDTO>>>> GetBranchesNames()
        {
            var result = await _branchService.GetBrancheNamesAsync();

            if (!result.Success)
                return StatusCode(result.StatusCode, result);

            return Ok(result);
        }

        [HttpGet("GetBranchesNames/{id:int}")]
        [SwaggerOperation(Summary = BranchControllerSwaggerAttributes.GetBranchNamesByIdSummary)]
        [SwaggerResponse(200, BranchControllerSwaggerAttributes.GetBranchNamesByIdResponse200, typeof(APIResponseResult<BranchNamesDTO>))]
        [SwaggerResponse(404, BranchControllerSwaggerAttributes.GetBranchNamesByIdResponse404)]
        public async Task<ActionResult<APIResponseResult<BranchNamesDTO>>> GetBrancheName(int id)
        {
            var result = await _branchService.GetBrancheNamesAsync(id);

            if (!result.Success)
                return StatusCode(result.StatusCode, result);

            return Ok(result);
        }

        [HttpGet("GetBranch/{id:int}")]
        [SwaggerOperation(Summary = BranchControllerSwaggerAttributes.GetBranchByIdSummary)]
        [SwaggerResponse(200, BranchControllerSwaggerAttributes.GetBranchByIdResponse200, typeof(APIResponseResult<BranchDTO>))]
        [SwaggerResponse(404, BranchControllerSwaggerAttributes.GetBranchByIdResponse404)]
        public async Task<ActionResult<APIResponseResult<BranchDTO>>> GetBranch(int id)
        {
            var result = await _branchService.GetBranchByIdAsync(id);

            if (!result.Success)
                return StatusCode(result.StatusCode, result);

            return Ok(result);
        }

        [HttpPost("CreateBranch")]
        [SwaggerOperation(Summary = BranchControllerSwaggerAttributes.AddBranchSummary)]
        [SwaggerResponse(201, BranchControllerSwaggerAttributes.AddBranchResponse201, typeof(APIResponseResult<bool>))]
        [SwaggerResponse(400, BranchControllerSwaggerAttributes.AddBranchResponse400)]
        public async Task<ActionResult<APIResponseResult<bool>>> CreateBranch([FromBody] BranchDTO branchDto)
        {
            var result = await _branchService.AddBranchAsync(branchDto);

            if (!result.Success)
                return StatusCode(result.StatusCode, result);

            return CreatedAtAction(nameof(GetBranch), new { id = branchDto.Id }, result);
        }

        [HttpPut("UpdateBranch/{id:int}")]
        [SwaggerOperation(Summary = BranchControllerSwaggerAttributes.UpdateBranchSummary)]
        [SwaggerResponse(204, BranchControllerSwaggerAttributes.UpdateBranchResponse204)]
        [SwaggerResponse(400, BranchControllerSwaggerAttributes.UpdateBranchResponse400)]
        [SwaggerResponse(404, BranchControllerSwaggerAttributes.UpdateBranchResponse404)]
        public async Task<ActionResult<APIResponseResult<bool>>> UpdateBranch(int id, [FromBody] BranchDTO branchDto)
        {
            if (id != branchDto.Id)
                return BadRequest(new APIResponseResult<bool>(400, "Invalid ID"));

            var result = await _branchService.UpdateBranchAsync(branchDto);

            if (!result.Success)
                return StatusCode(result.StatusCode, result);

            return NoContent();
        }

        [HttpDelete("DeleteBranch/{id:int}")]
        [SwaggerOperation(Summary = BranchControllerSwaggerAttributes.DeleteBranchSummary)]
        [SwaggerResponse(204, BranchControllerSwaggerAttributes.DeleteBranchResponse204)]
        [SwaggerResponse(404, BranchControllerSwaggerAttributes.DeleteBranchResponse404)]
        public async Task<ActionResult<APIResponseResult<bool>>> DeleteBranch(int id)
        {
            var result = await _branchService.DeleteBranchAsync(id);

            if (!result.Success)
                return StatusCode(result.StatusCode, result);

            return NoContent();
        }
    }
}
