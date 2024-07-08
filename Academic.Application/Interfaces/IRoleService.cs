using Academic.Application.DTOs.Role;
using Academic.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.Application.Interfaces
{
    public interface IRoleService : IService<RoleDTO>
    {
        public Task<IEnumerable<string>> GetGroupRoles(int id);
        public Task<IEnumerable<string>> SetGroupRoles(int id, List<string> roleIds);
    }
}
