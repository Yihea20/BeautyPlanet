using BeautyPlanet.DataAccess;
using BeautyPlanet.IRepository;
using BeautyPlanet.Models;

namespace BeautyPlanet.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly BeautyDbContext _context;
        private IGenericRepository<Center> _center;
        private IGenericRepository<Category> _category;
        private IGenericRepository<Service> _service;
        public UnitOfWork(BeautyDbContext context)
        {
            _context = context;
        }

        public IGenericRepository<Center> Center => _center ??= new GenericRepository<Center>(_context);
        public IGenericRepository<Category> Category => _category ??= new GenericRepository<Category>(_context);
        public IGenericRepository<Service> Service => _service ??= new GenericRepository<Service>(_context);
        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
