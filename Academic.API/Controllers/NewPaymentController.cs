using Academic.Application.DTOs.PaymentDTOs;

namespace Academic.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [SwaggerTag("Payment Management")]
    [ApiExplorerSettings(GroupName = "AcademicSystemAPIv1")]
    //[Authorize(Roles = "Payments")]
    public class NewPaymentController : ControllerBase
    {
        private readonly INewPaymentService _newPaymentService;

        public NewPaymentController(INewPaymentService newPaymentService)
        {
            _newPaymentService = newPaymentService;
        }

        [HttpGet("GetAllPayments")]
        [SwaggerOperation(Summary = "Get all payments", Description = "Retrieves all payments")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<PaymentDTO>> GetAll()
        {
            return await _newPaymentService.GetAllPaymentsAsync();
        }

        [HttpGet("GetPaymentById/{id}")]
        [SwaggerOperation(Summary = "Get payment by ID", Description = "Retrieves a payment by its ID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponseResult<PaymentDTO>>> GetPaymentById(int id)
        {
            var result = await _newPaymentService.GetPaymentByIdAsync(id);
            if (!result.Success)
                return NotFound(result);
            return Ok(result);
        }

        [HttpPost("AddPayment")]
        [SwaggerOperation(Summary = "Add a new payment", Description = "Adds a new payment to the system")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponseResult<bool>>> AddPayment(AddPaymentDTO dto)
        {
            var result = await _newPaymentService.AddPaymentAsync(dto);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpDelete("DeletePayment/{id}")]
        [SwaggerOperation(Summary = "Delete a payment", Description = "Deletes a payment by its ID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponseResult<bool>>> DeletePayment(int id)
        {
            var result = await _newPaymentService.DeletePaymentAsync(id);
            if (!result.Success)
                return NotFound(result);
            return Ok(result);
        }

        [HttpPut("UpdatePayment")]
        [SwaggerOperation(Summary = "Update a payment", Description = "Updates an existing payment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponseResult<bool>>> UpdatePayment(PaymentDTO dto)
        {
            var result = await _newPaymentService.UpdatePaymentAsync(dto);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
    }
}
