using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Academic.Core.Entities
{
    public class PaymentAudit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }

        [ForeignKey("Payment")]
        public int? PaymentId { get; set; }
        public Payment Payment { get; set; }

        [ForeignKey("ApplicationUser")]
        public string? ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
