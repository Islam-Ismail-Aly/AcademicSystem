using Academic.Core.Abstraction;

namespace Academic.Core.Entities
{
    public class Group : BaseEntity
    {
        public ICollection<ApplicationUser> ApplicationUsers { get; set; } = new List<ApplicationUser>();
        public ICollection<GroupPermission> GroupPermissions { get; set; } = new List<GroupPermission>();
    }
}
