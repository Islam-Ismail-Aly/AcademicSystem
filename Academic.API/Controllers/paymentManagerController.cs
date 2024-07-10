using Academic.Application.DTOs.PaymentDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Academic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentManagerController : ControllerBase
    {
        private readonly IPaymentManager _paymentManager;

        public PaymentManagerController(IPaymentManager paymentManager )
        {
            _paymentManager = paymentManager;
        }
        // POST api/<PaymentManagerController>
        [HttpPost]
        public async Task<APIResponseResult<getStudentAudits>> Post([FromBody] paymentManagerAdd value)
        {
            return await _paymentManager.AddPaymentAsync(value);
        }

        // DELETE api/<PaymentManagerController>/5
        [HttpDelete("{id}")]
        public async Task<APIResponseResult<bool>> Delete(int id)
        {
            return await _paymentManager.DeletePaymentAsync(id);
        }
    }
}
