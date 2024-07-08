using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.Core.Entities
{
    public class GroupRole
    {
        [ForeignKey("Group")]
        public int? GroupId { get; set; }
        public Group Group { get; set; }

        [ForeignKey("Permission")]
        public string? RoleId { get; set; }
        public IdentityRole Role { get; set; }
    }
}
