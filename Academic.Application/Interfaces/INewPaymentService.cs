﻿using Academic.Application.DTOs.PaymentDTOs;
using Academic.Application.Utilities;
using Academic.Core.Entities;

namespace Academic.Application.Interfaces
{
    public interface INewPaymentService
    {
        Task<IEnumerable<PaymentDTO>> GetAllPaymentsAsync();
        Task<APIResponseResult<PaymentDTO>> GetPaymentByIdAsync(int id);
        Task<APIResponseResult<Payment>> AddPaymentAsync(AddPaymentDTO dto);
        Task<APIResponseResult<bool>> UpdatePaymentAsync(PaymentDTO dto);
        Task<APIResponseResult<bool>> DeletePaymentAsync(int id);
    }
}
