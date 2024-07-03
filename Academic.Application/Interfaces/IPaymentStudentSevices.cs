using Academic.Application.DTOs.Account;
using Academic.Application.DTOs.Branch;
using Academic.Application.DTOs.PaymentDetailsDTO;
using Academic.Application.DTOs.PaymentDTOs;
using Academic.Application.DTOs.StudentDTOs;
using Academic.Application.Utilities;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.Application.Interfaces
{
    public interface IPaymentStudentSevices
    {
        //Should be in Student Service
        Task<APIResponseResult<IEnumerable<StudentNamesPaymentDTO>>> GetStudentNamesPerBranchAsync(int branchId);
        Task<APIResponseResult<bool>> AddPaymentAsync(PaymentDTO paymentDetailsDTO);
        Task<APIResponseResult<PaymentDetailsDTO>> GetPaymentByIdAsync(int id);
        Task<APIResponseResult<PaymentDetailsDTO>> GetStudentPaymentDetails(int id);
        Task<APIResponseResult<StudentCoursesPaymentDetailsDTO>> StudentCoursesPaymentDetails(int studentId);
        Task<APIResponseResult<bool>> DeleteStudentPaymentDetails(int studentId);


    }
}
