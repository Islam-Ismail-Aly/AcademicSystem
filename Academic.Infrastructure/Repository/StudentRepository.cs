using Academic.Core.Entities;
using Academic.Core.Interfaces;
using Academic.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Academic.Infrastructure.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;
        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Student>> GetAllStudentsPerBranchAsync(int branchId)
        {
            return await _context.Students.Include(s => s.ApplicationUser)
                   .Where(student => student.BranchId == branchId)
                   .AsNoTracking()
                   .ToListAsync();
        }
    }
}
