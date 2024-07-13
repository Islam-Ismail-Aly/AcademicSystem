using Academic.Application.DTOs.PaymentDTOs;
using Academic.Application.Interfaces;
using Academic.Application.Utilities;
using Academic.Core.Entities;
using Academic.Core.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Academic.Application.Services
{
    public class NewPaymentService : INewPaymentService
    {
        private readonly IUnitOfWork<Payment> _paymentUnitOfWork;

        public NewPaymentService(IUnitOfWork<Payment> paymentUnitOfWork)
        {
            _paymentUnitOfWork = paymentUnitOfWork;
        }
        public async Task<APIResponseResult<Payment>> AddPaymentAsync(AddPaymentDTO dto)
        {
            Payment paymentInDb = new Payment();
            if (dto != null)
            {


                paymentInDb.MoneyPaid = dto.MoneyPaid;
                paymentInDb.NominatingAuthority = dto.NominatingAuthority;
                 paymentInDb.Notes = dto.Notes;
                paymentInDb.RestOfMoney = dto.RestOfMoney;
                paymentInDb.State = dto.State;
                }

                await _paymentUnitOfWork.Entity.InsertAsync(paymentInDb);
                await _paymentUnitOfWork.SaveAsync();
            
            return new APIResponseResult<Payment>(paymentInDb, "Payment Added Successfully") { Success = true };
        }

        public async Task<APIResponseResult<bool>> DeletePaymentAsync(int id)
        {
            var payment = await _paymentUnitOfWork.Entity.GetByIdAsync(id);

            if (payment is null)
                return new APIResponseResult<bool>(404, "Payment not found");

            await _paymentUnitOfWork.Entity.DeleteAsync(id);
            await _paymentUnitOfWork.SaveAsync();

            return new APIResponseResult<bool>(true, "Payment deleted successfully");
        }

        public async Task<IEnumerable<PaymentDTO>> GetAllPaymentsAsync()
        {
            List<PaymentDTO> paymentDTO = new();

            var result = await _paymentUnitOfWork.Entity.GetAllAsync();

            foreach (var item in result)
            {
                paymentDTO.Add(new PaymentDTO
                {
                    Id = item.Id,
                    MoneyPaid = item.MoneyPaid,
                    NominatingAuthority = item.NominatingAuthority,
                    Notes = item.Notes,
                    RestOfMoney = item.RestOfMoney,
                    State = item.State
                });
            }

            return paymentDTO;
        }

        public async Task<APIResponseResult<PaymentDTO>> GetPaymentByIdAsync(int id)
        {
            var payment = _paymentUnitOfWork.Entity.GetByIdAsync(id);

            if (payment.Result is null)
                return new APIResponseResult<PaymentDTO>(404, "Payment not found");

            var payDto = new PaymentDTO
            {
                Id = payment.Result.Id,
                MoneyPaid = payment.Result.MoneyPaid,
                NominatingAuthority = payment.Result.NominatingAuthority,
                Notes = payment.Result.Notes,
                RestOfMoney = payment.Result.RestOfMoney,
                State = payment.Result.State
            };

            return new APIResponseResult<PaymentDTO>(payDto, "Payment Retrieved Successfully");
        }

        public async Task<APIResponseResult<bool>> UpdatePaymentAsync(PaymentDTO dto)
        {
            var paymentAddDb = new Payment()
            {
                //Id = dto.Id,
                MoneyPaid = dto.MoneyPaid,
                NominatingAuthority = dto.NominatingAuthority,
                RestOfMoney = dto.RestOfMoney,
                State = dto.State,
                Notes = dto.Notes
            };

            await _paymentUnitOfWork.Entity.UpdateAsync(paymentAddDb);
            await _paymentUnitOfWork.SaveAsync();

            return new APIResponseResult<bool>(true, "Payment updated successfully");
        }

    }
}
