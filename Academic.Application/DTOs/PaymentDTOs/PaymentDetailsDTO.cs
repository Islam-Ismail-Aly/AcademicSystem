using Academic.Core.Entities;
using Academic.Core.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.Application.DTOs.PaymentDetailsDTO
{
    public class PaymentDetailsDTO
    {
        public int Id { get; set; }
        public decimal MoneyPaid { get; set; }
        public decimal RestOfMoney { get; set; }
        public string ? State { get; set; }
        public string? NominatingAuthority { get; set; }
        public string? Notes { get; set; }
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
        public string userName { get; set; }

    }
}
