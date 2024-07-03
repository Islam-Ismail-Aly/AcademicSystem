using Academic.Core.Interfaces;
using Academic.Infrastructure.Data;
using Academic.Infrastructure.Repository;

namespace Academic.Infrastructure.UnitOfWork
{
    public class UnitOfWork<T> : IDisposable, IUnitOfWork<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private IGenericRepository<T> _entity;
        private IStudentRepository _studentRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IGenericRepository<T> Entity
        {
            get
            {
                return _entity ?? (_entity = new GenericRepository<T>(_context));
            }
        }

        public IStudentRepository StudentRepository
        {
            get
            {
                return _studentRepository ?? (_studentRepository = new StudentRepository(_context));
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
