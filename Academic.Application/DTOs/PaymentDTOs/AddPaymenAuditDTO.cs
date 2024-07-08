namespace Academic.Application.DTOs.PaymentDTOs
{
    public class AddPaymenAuditDTO
    {
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public int? PaymentId { get; set; }
        public int? CourseId { get; set; }
        public string? ApplicationUserId { get; set; }
    }
}
