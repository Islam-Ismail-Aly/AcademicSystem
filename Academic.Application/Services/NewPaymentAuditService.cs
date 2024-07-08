using Academic.Application.DTOs.PaymentDTOs;
using Academic.Application.Interfaces;
using Academic.Application.Utilities;
using Academic.Core.Entities;
using Academic.Core.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Academic.Application.Services
{
    public class NewPaymentAuditService : INewPaymentAuditService
    {
        private readonly IUnitOfWork<PaymentAudit> _paymentAuditUnitOfWork;

        public NewPaymentAuditService(IUnitOfWork<PaymentAudit> paymentAuditUnitOfWork)
        {
            _paymentAuditUnitOfWork = paymentAuditUnitOfWork;
        }

        public async Task<APIResponseResult<bool>> AddPaymentAuditAsync(AddPaymenAuditDTO dto)
        {
            if (dto != null)
            {
                PaymentAudit paymentAuditInDb = new PaymentAudit
                {
                    TransactionDate = dto.TransactionDate,
                    Amount = dto.Amount,
                    PaymentId = dto.PaymentId,
                    CourseId = dto.CourseId,
                    ApplicationUserId = dto.ApplicationUserId,
                };

                await _paymentAuditUnitOfWork.Entity.InsertAsync(paymentAuditInDb);
                await _paymentAuditUnitOfWork.SaveAsync();
            }

            return new APIResponseResult<bool>(StatusCodes.Status201Created, "Payment Audit Added Successfully") { Success = true };
        }

        public async Task<APIResponseResult<bool>> DeletePaymentAuditAsync(int id)
        {
            var paymentAudit = await _paymentAuditUnitOfWork.Entity.GetByIdAsync(id);

            if (paymentAudit is null)
                return new APIResponseResult<bool>(404, "Payment Audit not found");

            await _paymentAuditUnitOfWork.Entity.DeleteAsync(id);
            await _paymentAuditUnitOfWork.SaveAsync();

            return new APIResponseResult<bool>(true, "Payment Audit deleted successfully");
        }

        public async Task<IEnumerable<PaymenAuditDTO>> GetAllPaymentAuditsAsync()
        {
            List<PaymenAuditDTO> paymentAuditDTOs = new();

            var result = await _paymentAuditUnitOfWork.Entity.GetAllAsync();

            foreach (var item in result)
            {
                paymentAuditDTOs.Add(new PaymenAuditDTO
                {
                    CourseName = item.Course?.Name,
                    TransactionDate = item.TransactionDate,
                    Amount = item.Amount,
                    UserName = item.ApplicationUser?.UserName,
                    Status = item.Payment.State.Value.ToString(),
                });
            }

            return paymentAuditDTOs;
        }

        public async Task<APIResponseResult<PaymenAuditDTO>> GetPaymentAuditByIdAsync(int id)
        {
            var paymentAudit = await _paymentAuditUnitOfWork.Entity.GetByIdAsync(id);

            if (paymentAudit is null)
                return new APIResponseResult<PaymenAuditDTO>(404, "Payment Audit not found");

            var paymentAuditDTO = new PaymenAuditDTO
            {
                CourseName = paymentAudit.Course?.Name,
                TransactionDate = paymentAudit.TransactionDate,
                Amount = paymentAudit.Amount,
                UserName = paymentAudit.ApplicationUser?.UserName,
                Status = paymentAudit.Payment.State.Value.ToString(),
            };

            return new APIResponseResult<PaymenAuditDTO>(paymentAuditDTO, "Payment Audit Retrieved Successfully");
        }

        public async Task<APIResponseResult<bool>> UpdatePaymentAuditAsync(AddPaymenAuditDTO dto)
        {
            var paymentAuditInDb = new PaymentAudit
            {
                TransactionDate = dto.TransactionDate,
                Amount = dto.Amount,
                PaymentId = dto.PaymentId,
                CourseId = dto.CourseId,
                ApplicationUserId = dto.ApplicationUserId,
            };

            await _paymentAuditUnitOfWork.Entity.UpdateAsync(paymentAuditInDb);
            await _paymentAuditUnitOfWork.SaveAsync();

            return new APIResponseResult<bool>(true, "Payment Audit updated successfully");
        }
    }
}
