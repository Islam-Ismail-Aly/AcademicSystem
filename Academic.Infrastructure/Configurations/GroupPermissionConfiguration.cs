using Academic.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Academic.Infrastructure.Configurations
{
    public class GroupPermissionConfiguration : IEntityTypeConfiguration<GroupPermission>
    {
        public void Configure(EntityTypeBuilder<GroupPermission> builder)
        {
            builder.HasKey(table => new { table.GroupId, table.PermissionId });
        }
    }
}
