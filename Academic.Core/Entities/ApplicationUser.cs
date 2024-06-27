using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academic.Core.Entities
{
    public class ApplicationUser : IdentityUser
    {
        [Required, MaxLength(200)]
        public string FullName { get; set; }

        [Required, MaxLength(50)]
        public string Language { get; set; }

        [ForeignKey("Branch")]
        public int BranchId { get; set; }
        public Branch Branch { get; set; }

        [ForeignKey("Group")]
        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}
