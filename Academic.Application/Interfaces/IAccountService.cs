using Academic.Application.DTOs.Account;
using Academic.Application.Pagination;
using Academic.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.Application.Interfaces
{
    public interface IAccountService :IService <ApplicationUserDTO> 
    {
        public Task<AccountResponseLoginDTO> Login(AccountLoginDTO dto);
        public Task<ApiResponse> SignOut();
        public Task<PaginatedList<ApplicationUserDTO>> GetPagination();
    }
}
