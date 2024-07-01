using Academic.Core.Entities;
using Academic.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.Application.Authorization
{
    public class PermissionHandler : AuthorizationHandler<PermissionRequirement>
    {
        private UserManager<ApplicationUser> _userManager;
        private ApplicationDbContext _dbContext;

        public PermissionHandler(UserManager<ApplicationUser> userManager, ApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _dbContext = dbContext;
        }
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            var user = await _userManager.GetUserAsync(context.User);
            if (user == null)
            {
                return;
            }
            var userGroups = await _dbContext.Groups
            .Where(g => g.ApplicationUsers.Any(u => u.Id == user.Id))
            .Include(g => g.GroupPermissions)
            //.ThenInclude(gp => gp.Permission)
            .ToListAsync();
            //if (userGroups.Any(g => g.GroupPermissions.Any(gp => gp.Permission.Name == requirement.Permission)))
            //{
            //    context.Succeed(requirement);
            //}
        }
    }
}
