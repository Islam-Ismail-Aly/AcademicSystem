using Academic.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.Core.Interfaces
{
    public interface IStudentRepository: IGenericRepository<Student>
    {
        Task<IEnumerable<Student>> GetAllStudentsPerBranchAsync(int branchId);
    }
}
