using Academic.Core.Enumerations;

namespace Academic.Application.DTOs.PaymentDTOs
{
    public class PaymentDTO
    {
        public int Id { get; set; }
        public decimal MoneyPaid { get; set; }
        public decimal RestOfMoney { get; set; }
        public State? State { get; set; }
        public string? NominatingAuthority { get; set; }
        public string? Notes { get; set; }
    }
}
