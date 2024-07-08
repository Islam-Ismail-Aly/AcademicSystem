using Academic.Application.DTOs.PaymentDTOs;

namespace Academic.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [SwaggerTag("Payment Audit Management")]
    [ApiExplorerSettings(GroupName = "AcademicSystemAPIv1")]
    public class NewPaymentAuditController : ControllerBase
    {
        private readonly INewPaymentAuditService _newPaymentAuditService;

        public NewPaymentAuditController(INewPaymentAuditService newPaymentAuditService)
        {
            _newPaymentAuditService = newPaymentAuditService;
        }

        [HttpGet("GetAllPaymentAudits")]
        [SwaggerOperation(Summary = "Get all payment audits", Description = "Retrieves all payment audits")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<PaymenAuditDTO>> GetAll()
        {
            return await _newPaymentAuditService.GetAllPaymentAuditsAsync();
        }

        [HttpGet("GetPaymentAuditById/{id}")]
        [SwaggerOperation(Summary = "Get payment audit by ID", Description = "Retrieves a payment audit by its ID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponseResult<PaymenAuditDTO>>> GetPaymentAuditById(int id)
        {
            var result = await _newPaymentAuditService.GetPaymentAuditByIdAsync(id);
            if (!result.Success)
                return NotFound(result);
            return Ok(result);
        }

        [HttpPost("AddPaymentAudit")]
        [SwaggerOperation(Summary = "Add a new payment audit", Description = "Adds a new payment audit to the system")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponseResult<bool>>> AddPaymentAudit(AddPaymenAuditDTO dto)
        {
            var result = await _newPaymentAuditService.AddPaymentAuditAsync(dto);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpDelete("DeletePaymentAudit/{id}")]
        [SwaggerOperation(Summary = "Delete a payment audit", Description = "Deletes a payment audit by its ID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponseResult<bool>>> DeletePaymentAudit(int id)
        {
            var result = await _newPaymentAuditService.DeletePaymentAuditAsync(id);
            if (!result.Success)
                return NotFound(result);
            return Ok(result);
        }

        [HttpPut("UpdatePaymentAudit")]
        [SwaggerOperation(Summary = "Update a payment audit", Description = "Updates an existing payment audit")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponseResult<bool>>> UpdatePaymentAudit(AddPaymenAuditDTO dto)
        {
            var result = await _newPaymentAuditService.UpdatePaymentAuditAsync(dto);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
    }
}
