﻿using Academic.Core.Abstraction;

namespace Academic.Core.Entities
{
    public class Permission : BaseEntity
    {
        public ICollection<GroupPermission> GroupPermissions { get; private set; } = new HashSet<GroupPermission>();
    }
}
