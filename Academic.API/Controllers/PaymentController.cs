using Academic.Application.DTOs.Branch;
using Academic.Application.DTOs.PaymentDetailsDTO;
using Academic.Application.DTOs.PaymentDTOs;
using Academic.Application.DTOs.StudentDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Academic.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [SwaggerTag("Payment Management")]
    [ApiExplorerSettings(GroupName = "AcademicSystemAPIv1")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentStudentSevices _paymentStudentSevices;

        public PaymentController(IPaymentStudentSevices paymentStudentSevices)
        {
            _paymentStudentSevices = paymentStudentSevices;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<APIResponseResult<PaymentDetailsDTO>>> GetPayment(int id)
        {
            var result = await _paymentStudentSevices.GetPaymentByIdAsync(id);

            if (!result.Success)
                return StatusCode(result.StatusCode, result);

            return Ok(result);
        }

        [HttpGet("StudentsNamesPerBranch")]
        public async Task<ActionResult<APIResponseResult<IEnumerable<StudentNamesPaymentDTO>>>> GetStudentNamesPerBranch(int branchId)
        {
            var result = await _paymentStudentSevices.GetStudentNamesPerBranchAsync(branchId);
            if (!result.Success)
                return StatusCode(result.StatusCode, result);

            return Ok(result);
        }

        [HttpPost("Add")]
        public async Task<ActionResult<APIResponseResult<bool>>> AddPayment(PaymentDTO paymentDetailsDTO)
        {
            var result = await _paymentStudentSevices.AddPaymentAsync(paymentDetailsDTO);

            if (!result.Success)
                return StatusCode(result.StatusCode, result);

            return CreatedAtAction(nameof(GetPayment), new { id = paymentDetailsDTO.Id }, result);
        }


        [HttpGet("StudentPaymentDetails")]
        public async Task<ActionResult<APIResponseResult<PaymentDetailsDTO>>> GetStudentPaymentDetails(int studentId)
        {
            var result = await _paymentStudentSevices.GetStudentPaymentDetails(studentId);

            if (!result.Success)
                return StatusCode(result.StatusCode, result);

            // Need To get student details to fill this 

            result.Data.EnglishName = "";
            result.Data.ArabicName = "";
            result.Data.userName = "";

            return Ok(result);
        }

        [HttpGet("StudentCoursesPaymentDetails")]
        public async Task<ActionResult<APIResponseResult<PaymentDetailsDTO>>> GetStudentCoursesPaymentDetails(int studentId)
        {
            var result = await _paymentStudentSevices.StudentCoursesPaymentDetails(studentId);

            result.Data.Date = DateTime.Now;

            if (!result.Success)
                return StatusCode(result.StatusCode, result);

            return Ok(result);
        }

        [HttpGet("DeleteStudentPaymentDetails")]
        public async Task<ActionResult<APIResponseResult<bool>>> DeleteStudentPaymentDetails(int studentId)
        {
            var result = await _paymentStudentSevices.DeleteStudentPaymentDetails(studentId);

            if (!result.Success)
                return StatusCode(result.StatusCode, result);

            return Ok(result);
        }
    }
}
