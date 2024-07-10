using Academic.Application.DTOs.Student;
using Academic.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.Application.DTOs.PaymentDTOs
{
    public class getStudentAudits
    {
        public StudentDTO? student {  get; set; }
        public PaymentDTO? mainPayment {  get; set; }
        public IEnumerable<PaymentAudit>? paymentAudits {  get; set; }
    }
}
