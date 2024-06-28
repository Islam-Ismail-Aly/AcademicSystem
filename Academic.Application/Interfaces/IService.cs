using Academic.Application.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.Application.Interfaces
{
    public interface IService<T> where T : class 
    {
        public Task<IEnumerable<T>> GetAll();
        public Task<T> GetById(object Id, string? include);
        public Task Delete(object Id);
        public Task<ApiResponse> Add(T dto);
        public Task Update(T dto);
    }
}
