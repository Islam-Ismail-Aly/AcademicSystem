using Academic.Core.Enumerations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academic.Core.Entities
{
    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public decimal MoneyPaid { get; set; }
        public decimal RestOfMoney { get; set; }
        public State State { get; set; }
        public string NominatingAuthority { get; set; }
        public string Notes { get; set; }
        public ICollection<PaymentAudit> PaymentAudits { get; private set; } = new HashSet<PaymentAudit>();
    }
}
