using Academic.Application.DTOs.PaymentDTOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Academic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class paymentManagerController : ControllerBase
    {
        private readonly PaymentManager _paymentManager;

        public paymentManagerController(PaymentManager paymentManager )
        {
            _paymentManager = paymentManager;
        }
        // POST api/<paymentManagerController>
        [HttpPost]
        public async Task<APIResponseResult<getStudentAudits>> Post([FromBody] paymentManagerAdd value)
        {
            return await _paymentManager.AddPaymentAsync(value);
        }

        // DELETE api/<paymentManagerController>/5
        [HttpDelete("{id}")]
        public async Task<APIResponseResult<bool>> Delete(int id)
        {
            return await _paymentManager.DeletePaymentAsync(id);
        }
    }
}
