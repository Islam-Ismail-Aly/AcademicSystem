using Academic.Application.DTOs.Account;
using Academic.Application.Interfaces;
using Academic.Application.Utilities;
using Academic.Core.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Academic.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountService(UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<ApiResponse> Add(ApplicationUserDTO dto)
        {

            if (await _userManager.FindByEmailAsync(dto.Email) != null)
            {
                return new ApiResponse(StatusCodes.Status400BadRequest, "Email is already registered");
            }

            if (await _userManager.FindByEmailAsync(dto.UserName) != null)
            {
                return new ApiResponse(StatusCodes.Status400BadRequest, "Username is already registered");
            }
            ApplicationUser user = _mapper.Map<ApplicationUser>(dto);

            var result = await _userManager.CreateAsync(user, dto.Password);
            if (result.Succeeded)
            {
                return new ApiResponse(StatusCodes.Status201Created, "User has been created");
            }
            else
            {
                return new ApiResponse(StatusCodes.Status500InternalServerError, "Somthing went wrong");

            }

        }

        public async Task Delete(object Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ApplicationUserDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<ApplicationUserDTO> GetById(object Id, string? include)
        {
            throw new NotImplementedException();
        }

        public async Task<AccountResponseLoginDTO> Login(AccountLoginDTO dto)
        {
            throw new NotImplementedException();
        }

        public async Task Update(ApplicationUserDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
