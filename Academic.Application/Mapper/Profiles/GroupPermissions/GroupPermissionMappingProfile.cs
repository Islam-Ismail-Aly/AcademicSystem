using Academic.Application.DTOs.GroupPermission;
using Academic.Core.Entities;
using AutoMapper;

namespace Academic.Application.Mapper.Profiles.GroupPermissions
{
    public class GroupPermissionMappingProfile : Profile
    {
        public GroupPermissionMappingProfile()
        {
            CreateMap<Group, GroupDTO>().ReverseMap();
            CreateMap<Permission, PermissionDTO>().ReverseMap();
        }
    }
}
