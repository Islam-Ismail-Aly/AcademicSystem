using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.Application.DTOs.PaymentDTOs
{
    public class paymentManagerAdd
    {
        public int studentId { get; set; }
        public string transactionUserEmail { get; set; }
        public decimal amount { get; set; }
        public string notes { get; set; }
    }
}
