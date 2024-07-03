using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.Application.DTOs.PaymentDTOs
{
    public class StudentCoursesPaymentDetailsDTO
    {
        public int StudentId { get; set; }
        public string CourseName { get; set; }
        public DateTime Date { get; set; }
        public string State { get; set; }
        public string Notes { get; set; }
        public Decimal Price { get; set; }

        //
    }
}
