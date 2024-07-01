using System.ComponentModel.DataAnnotations.Schema;

namespace Academic.Core.Entities
{
    public class GroupPermission
    {
        [ForeignKey("Group")]
        public int? GroupId { get; set; }
        public Group Group { get; set; }

        [ForeignKey("Permission")]
        public int? PermissionId { get; set; }
        public Permission Permission { get; set; }
    }
}
