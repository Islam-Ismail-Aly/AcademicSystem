using Academic.Application.DTOs.PaymentDTOs;
using Academic.Application.Utilities;

namespace Academic.Application.Interfaces
{
    public interface INewPaymentAuditService
    {
        Task<IEnumerable<PaymenAuditDTO>> GetAllPaymentAuditsAsync();
        Task<APIResponseResult<PaymenAuditDTO>> GetPaymentAuditByIdAsync(int id);
        Task<APIResponseResult<bool>> AddPaymentAuditAsync(AddPaymenAuditDTO dto);
        Task<APIResponseResult<bool>> UpdatePaymentAuditAsync(AddPaymenAuditDTO dto);
        Task<APIResponseResult<bool>> DeletePaymentAuditAsync(int id);
    }
}
