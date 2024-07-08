using Academic.Application.Authentication;
using Academic.Application.DTOs.Role;
using Academic.Application.Interfaces;
using Academic.Application.Utilities;
using Academic.Core.Entities;
using Academic.Core.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.Application.Services
{

    
    public class RoleService : IRoleService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUnitOfWork<GroupRole> _groupRole;

        public RoleService(RoleManager<IdentityRole> roleManager, IUnitOfWork<GroupRole> groupRole)
        {
            _roleManager = roleManager;
            _groupRole = groupRole;
        }

        public async Task<ApiResponse> Add(RoleDTO dto)
        {
            IdentityRole role = new IdentityRole();
            role.Name = dto.Name;

            IdentityResult result= await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                return new ApiResponse(StatusCodes.Status201Created, "role has been created");
            }
            else
            {
                return new ApiResponse(StatusCodes.Status500InternalServerError, "Somthing went wrong");
            }
        }

        public async Task<IEnumerable<string>> GetGroupRoles(int id)
        {
            var AllRoles = await _groupRole.Entity.GetAllAsync();
            IEnumerable<string> roleIds = AllRoles.Where(r => r.GroupId == id).Select(r => r.RoleId).ToList();
            List<string> roleNames = [];
            foreach (var roleId in roleIds)
            {
                roleNames.Add(_roleManager.Roles.FirstOrDefault(r=>r.Id==roleId).Name);
            }
            return roleNames;
        }

        public async Task<IEnumerable<string>> SetGroupRoles(int id,List<string> roleIds )
        {
            foreach (var roleId in roleIds) 
            {
             await _groupRole.Entity.InsertAsync(new GroupRole { GroupId = id, RoleId = roleId });
             await _groupRole.SaveAsync();
            }
            return await this.GetGroupRoles(id);
        }


        public Task<ApiResponse> Delete(object Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<RoleDTO>> GetAll()
        {
            return _roleManager.Roles.Select(r=> new RoleDTO { Id=r.Id, Name=r.Name }).ToList();
        }

        public Task<RoleDTO> GetById(object Id, string? include)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> Update(RoleDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
