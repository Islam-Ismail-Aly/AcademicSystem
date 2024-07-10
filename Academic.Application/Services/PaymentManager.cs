using Academic.Application.DTOs.Course;
using Academic.Application.DTOs.PaymentDTOs;
using Academic.Application.DTOs.Student;
using Academic.Application.Interfaces;
using Academic.Application.Utilities;
using Academic.Core.Entities;
using Academic.Core.Enumerations;
using Academic.Core.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Academic.Application.Services
{
    public class PaymentManager : IPaymentManager
    {
        private readonly IUnitOfWork<Payment> _paymentUnitOfWork;
        private readonly IUnitOfWork<PaymentAudit> _paymentAuditUnitOfWork;
        private readonly IUnitOfWork<Student> _studentUnitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUnitOfWork<Course> _courseUnitOfWork;
        private readonly INewPaymentService _newPaymentService;
        private readonly INewPaymentAuditService _newPaymentAuditService;
        private readonly IStudentService _studentService;
        private readonly IService<CourseDTO> _courseService;

        public PaymentManager(IUnitOfWork<Payment> paymentUnitOfWork,
            IUnitOfWork<PaymentAudit> paymentAuditUnitOfWork, IUnitOfWork<Student> studentUnitOfWork,
            UserManager<ApplicationUser> userManager, IUnitOfWork<Course> courseUnitOfWork,
            INewPaymentService newPaymentService,
            INewPaymentAuditService newPaymentAuditService,
            IStudentService studentService,
            IService<CourseDTO> courseService
            )
        {
            _paymentUnitOfWork = paymentUnitOfWork;
            _paymentAuditUnitOfWork = paymentAuditUnitOfWork;
            _studentUnitOfWork = studentUnitOfWork;
            _userManager = userManager;
            _courseUnitOfWork = courseUnitOfWork;
            _newPaymentService = newPaymentService;
            _newPaymentAuditService = newPaymentAuditService;
            _studentService = studentService;
            _courseService = courseService;
        }

        public async Task<APIResponseResult<getStudentAudits>> AddPaymentAsync(paymentManagerAdd dto)
        {
            if (dto != null)
            {
                Student theStudent = await _studentUnitOfWork.Entity.GetByIdAsync(dto.studentId);
                Course course = await _courseUnitOfWork.Entity.GetByIdAsync(theStudent.CourseId);
                var user = await _userManager.FindByEmailAsync(dto.transactionUserEmail);
                Payment payment = await _paymentUnitOfWork.Entity.GetByIdAsync(theStudent.PaymentId);
                var addAuditResult = await _newPaymentAuditService.AddPaymentAuditAsync(new AddPaymenAuditDTO
                {
                    Amount = dto.amount,
                    ApplicationUserId = user.Id,
                    CourseId = course.Id,
                    PaymentId = theStudent.PaymentId,
                    TransactionDate = DateTime.Now
                });

                if (addAuditResult.Success)
                {
                    try
                    {
                        payment.MoneyPaid = payment.MoneyPaid + dto.amount;
                        payment.NominatingAuthority = payment.NominatingAuthority;
                        payment.RestOfMoney = payment.RestOfMoney - dto.amount;
                        payment.Notes = dto.notes;
                        payment.State = payment.RestOfMoney - dto.amount == 0 ? State.FeesPaid : State.FeesUnPaid;

                        await _paymentUnitOfWork.SaveAsync();
                    }
                    catch (Exception)
                    {
                        return new APIResponseResult<getStudentAudits>(new getStudentAudits(), "Failed to update Payment") { Success = false };
                    }

                    var studentDtoResult = await _studentService.GetStudentByIdAsync(theStudent.Id);
                        StudentDTO studentDto = studentDtoResult.Data;
                        var paymentDtoResult = await _newPaymentService.GetPaymentByIdAsync((int)theStudent.PaymentId);
                        PaymentDTO paymentDto = paymentDtoResult.Data;
                        IEnumerable<PaymentAudit> studentPaymentAuditsResult = await _paymentAuditUnitOfWork.Entity.GetAllAsync();
                        IEnumerable<PaymentAudit> paymentAudits = studentPaymentAuditsResult.Where(p => p.PaymentId == theStudent.PaymentId);
                        getStudentAudits studentAudits = new getStudentAudits()
                        {
                            student = studentDto,
                            mainPayment = paymentDto,
                            paymentAudits = paymentAudits

                        };
                        return new APIResponseResult<getStudentAudits>(studentAudits, "Payment Audit Added Successfully") { Success = true };

                    }


            }
                return new APIResponseResult<getStudentAudits>(new getStudentAudits(), "Failed to Add Payment Audit") { Success = false };
        }

        public async Task<APIResponseResult<bool>> DeletePaymentAsync(int auditId)
        {
            if (auditId != null)
            {
                PaymentAudit paymentAudit = await _paymentAuditUnitOfWork.Entity.GetByIdAsync(auditId);
                Payment payment = await _paymentUnitOfWork.Entity.GetByIdAsync(paymentAudit.PaymentId);
                try
                {
                    payment.Id = payment.Id;
                    payment.MoneyPaid = payment.MoneyPaid - paymentAudit.Amount;
                    payment.RestOfMoney = payment.RestOfMoney + paymentAudit.Amount;
                    payment.State = payment.RestOfMoney + paymentAudit.Amount == 0 ? State.FeesPaid : State.FeesUnPaid;

                    await _paymentUnitOfWork.SaveAsync();
                }
                catch (Exception)
                {
                    return new APIResponseResult<bool>(false, "Failed to update Payment") { Success = false };
                }

                    try
                    {
                        await _paymentAuditUnitOfWork.Entity.DeleteAsync(paymentAudit.Id);
                        await _paymentAuditUnitOfWork.SaveAsync();

                        return new APIResponseResult<bool>(true, "Payment Audit deleted Successfully") { Success = true };
                    }
                    catch
                    {
                        return new APIResponseResult<bool>(false, "Failed to delete Payment Audit") { Success = false };
                    }
                
            }
            return new APIResponseResult<bool>(false, "Failed to delete Payment Audit") { Success = false };
        }

    }
}
