namespace Academic.Application.DTOs.PaymentDTOs
{
    public class PaymenAuditDTO
    {
        public int Id { get; set; }
        public string? CourseName { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public string UserName { get; set; }
        public string Status { get; set; }
    }
}
