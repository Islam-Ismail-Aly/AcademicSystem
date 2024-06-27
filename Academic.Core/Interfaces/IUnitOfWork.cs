using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.Core.Interfaces
{
    public interface IUnitOfWork<T> where T : class
    {
        IGenericRepository<T> Entity { get; }
        Task SaveAsync();
    }
}
