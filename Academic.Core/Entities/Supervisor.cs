using Academic.Core.Abstraction;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academic.Core.Entities
{
    public class Supervisor : BaseEntity
    {
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
