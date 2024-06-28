using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.Application.Interfaces
{
    internal interface IService<T,T2> where T : class where T2 : class
    {
        public List<T> GetAll();
        public List<T> GetById(string Id, string? include);
        public void Delete(T2 dTO);
        public void Add(T2 dTO);
        public void Update(T2 dTO);
    }
}
