using Academic.Application.DTOs.Branch;
using Academic.Application.DTOs.PaymentDetailsDTO;
using Academic.Application.DTOs.PaymentDTOs;
using Academic.Application.DTOs.StudentDTOs;
using Academic.Application.Interfaces;
using Academic.Application.Utilities;
using Academic.Core.Entities;
using Academic.Core.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.Application.Services
{
    public class PaymentStudentService : IPaymentStudentSevices
    {
        private readonly IUnitOfWork<Payment> _unitOfWork;
        private readonly IUnitOfWork<PaymentAudit> _unitOfWork2;
        private readonly IMapper _mapper;
        public PaymentStudentService(IUnitOfWork<Payment> unitOfWork, IMapper mapper, IUnitOfWork<PaymentAudit> unitOfWork2)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _unitOfWork2 = unitOfWork2;
        }

        public async Task<APIResponseResult<PaymentDetailsDTO>> GetPaymentByIdAsync(int id)
        {
            var payment =  await _unitOfWork.Entity.GetByIdAsync(id);

            if (payment is null)
                return new APIResponseResult<PaymentDetailsDTO>(404, "Payment not found");

            var paymentDto = _mapper.Map<PaymentDetailsDTO>(payment);
            return new APIResponseResult<PaymentDetailsDTO>(paymentDto, "Payment Retrieved Successfully");
        }

        //should be in student
        public async Task<APIResponseResult<IEnumerable<StudentNamesPaymentDTO>>> GetStudentNamesPerBranchAsync(int branchId)
        {
            var studentsPerBranch = await _unitOfWork.StudentRepository.GetAllStudentsPerBranchAsync(branchId);

            if (studentsPerBranch is null)
                return new APIResponseResult<IEnumerable<StudentNamesPaymentDTO>>(404, "Students not found");

            var studentsPerBranchDtos = _mapper.Map<IEnumerable <StudentNamesPaymentDTO>>(studentsPerBranch);
            return new APIResponseResult<IEnumerable<StudentNamesPaymentDTO>>(studentsPerBranchDtos, "All Students Retrieved Successfully");

        }


        // add Student payment details
        public async Task<APIResponseResult<bool>> AddPaymentAsync(PaymentDTO paymentDetailsDTO)
        {

            var payment = _mapper.Map<Payment>(paymentDetailsDTO);

            payment.State = Core.Enumerations.State.FeesPaid; ////////

            await _unitOfWork.Entity.InsertAsync(payment);
            await _unitOfWork.SaveAsync();

            PaymentAudit paymentAudit = new PaymentAudit{ Amount = 850,
                ApplicationUserId = paymentDetailsDTO.ApplicationUserId, PaymentId = payment.Id};

            await _unitOfWork2.Entity.InsertAsync(paymentAudit);
            await _unitOfWork2.SaveAsync();

            return new APIResponseResult<bool>(true, "Payment added successfully");
        }

        public async Task<APIResponseResult<PaymentDetailsDTO>> GetStudentPaymentDetails(int id)
        {
            var studentPayment = await _unitOfWork.Entity.GetByIdAsync(id);

            if (studentPayment is null)
                return new APIResponseResult<PaymentDetailsDTO>(404, "student Payment not found");

            var studentPaymentDtos = _mapper.Map<PaymentDetailsDTO>(studentPayment);
            return new APIResponseResult<PaymentDetailsDTO>(studentPaymentDtos, "Student Payment Retrieved Successfully");

        }

        public async Task<APIResponseResult<StudentCoursesPaymentDetailsDTO>> StudentCoursesPaymentDetails(int studentId)
        {
            Student student = await _unitOfWork.StudentRepository.GetByIdAsync(studentId);

            if (student is null)
                return new APIResponseResult<StudentCoursesPaymentDetailsDTO>(404, "Student courses payment details not found");

            var studentCoursesPaymentDetailsDTO = _mapper.Map<StudentCoursesPaymentDetailsDTO>(student);

            return new APIResponseResult<StudentCoursesPaymentDetailsDTO>(studentCoursesPaymentDetailsDTO, "Student courses payment details Retrieved Successfully");
        }

        public async Task<APIResponseResult<bool>> DeleteStudentPaymentDetails(int studentId)
        {
            Student student = await _unitOfWork.StudentRepository.GetByIdAsync(studentId);

            if (student is null)
                return new APIResponseResult<bool>(404, "Student not found");

            var paymentAudits = student.Payment.PaymentAudits.Where(PaymentAudits => PaymentAudits.PaymentId == student.PaymentId);

            if (paymentAudits is null)
                return new APIResponseResult<bool>(404, "Payment Audits not found");

            foreach(var paymentAudit in paymentAudits)
            {
                await _unitOfWork2.Entity.DeleteAsync(paymentAudit.Id);
            }

            await _unitOfWork.Entity.DeleteAsync(student.PaymentId);

            return new APIResponseResult<bool>(true, "Student courses payment details Deleted Successfully");
        }
    }
}
