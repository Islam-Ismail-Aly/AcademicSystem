using Academic.Core.Interfaces;
using Academic.Infrastructure.Data;
using Academic.Infrastructure.Repository;

namespace Academic.Infrastructure.UnitOfWork
{
    public class UnitOfWork<T> : IDisposable, IUnitOfWork<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private IGenericRepository<T> _entity;
        private IElementRepository<T> _elementRepository;
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

        public IElementRepository<T> Element
        {
            get
            {
                return _elementRepository?? (_elementRepository = new ElementRepository<T>(_context));
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
