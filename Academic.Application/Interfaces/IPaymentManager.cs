using Academic.Application.DTOs.PaymentDTOs;
using Academic.Application.Utilities;

namespace Academic.Application.Interfaces
{
    public interface IPaymentManager
    {
        Task<APIResponseResult<getStudentAudits>> AddPaymentAsync(paymentManagerAdd dto);
        Task<APIResponseResult<bool>> DeletePaymentAsync(int auditId);
    }
}
