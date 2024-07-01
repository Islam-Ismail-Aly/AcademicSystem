using Academic.Application.Authentication;
using Academic.Application.DTOs.Account;
using Academic.Application.Interfaces;
using Academic.Application.Utilities;
using Academic.Core.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Academic.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IMapper _mapper;
        private readonly JwtOptions _jwtService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountService(UserManager<ApplicationUser> userManager, IMapper mapper
            ,IOptions<JwtOptions> options, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _jwtService = options.Value;
            _signInManager = signInManager;
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

        public async Task<ApiResponse> SignOut()
        {
            await _signInManager.SignOutAsync();
            return new ApiResponse(StatusCodes.Status201Created, "Signed Out");
        }



        public async Task Delete(object Id)
        {
            
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
            var Response = new AccountResponseLoginDTO();

            var user = await _userManager.FindByEmailAsync(dto.Email);

            if (user == null || !await _userManager.CheckPasswordAsync(user, dto.Password))
            {
                Response.Message = "Invalid Email or Password!";
                return Response;
            }

            var jwtSecurityToken = await CreateJwtToken(user);
            var roles = await _userManager.GetRolesAsync(user);

            Response.IsAuthenticated = true;
          
            
            Response.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            
            Response.Email = user.Email;
            Response.UserName = user.UserName;
            Response.ExpiresOn = jwtSecurityToken.ValidTo;
            Response.Roles = roles.ToList();

            return Response;

        }



        private async Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();
            foreach (var role in roles)
            {
                roleClaims.Add(new Claim("roles", role));
            }

            var claims = new[]
            {
           new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
           new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
           new Claim(JwtRegisteredClaimNames.Email, user.Email),
           new Claim("uid", user.Id)
      }
            .Union(userClaims)
            .Union(roleClaims);

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtService.Key));
            var securityCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            
            var jwtSecurityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(_jwtService.DurationInDays),
                signingCredentials: securityCredentials);

            return jwtSecurityToken;
        }



        public async Task Update(ApplicationUserDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
