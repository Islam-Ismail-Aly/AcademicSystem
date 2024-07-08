using Academic.Core.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.Application.DTOs.PaymentDTOs
{
    public class AddPaymentDTO
    {
        public decimal MoneyPaid { get; set; }
        public decimal RestOfMoney { get; set; }
        public State? State { get; set; }
        public string? NominatingAuthority { get; set; }
        public string? Notes { get; set; }
    }
}
