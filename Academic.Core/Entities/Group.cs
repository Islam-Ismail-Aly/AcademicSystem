using Academic.Core.Abstraction;

namespace Academic.Core.Entities
{
    public class Group : BaseEntity
    {
        public ICollection<ApplicationUser> ApplicationUsers { get; private set; } = new HashSet<ApplicationUser>();
        public ICollection<GroupPermission> GroupPermissions { get; private set; } = new HashSet<GroupPermission>();
    }
}
