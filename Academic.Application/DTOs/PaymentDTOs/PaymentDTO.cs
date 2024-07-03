using Academic.Core.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.Application.DTOs.PaymentDTOs
{
    public class PaymentDTO
    {
        public int Id {  get; set; }

        //public int? StudentId {  get; set; }
        public string? ApplicationUserId {  get; set; }
        public decimal? MoneyPaid { get; set; }
        public decimal? RestOfMoney { get; set; }

        public byte? State { get; set; }
        public string? NominatingAuthority { get; set; }
        public string? Notes { get; set; }
    }
}
