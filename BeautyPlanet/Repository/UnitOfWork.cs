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
        private IGenericRepository<User> _user;
        private IGenericRepository<Specialist> _specialist;
        public UnitOfWork(BeautyDbContext context)
        {
            _context = context;
        }

        public IGenericRepository<Center> Center => _center ??= new GenericRepository<Center>(_context);
        public IGenericRepository<Category> Category => _category ??= new GenericRepository<Category>(_context);
        public IGenericRepository<Service> Service => _service ??= new GenericRepository<Service>(_context);

        public IGenericRepository<User> User =>_user ??=new GenericRepository<User>(_context);

        public IGenericRepository<Specialist> Specialist =>_specialist ??=new GenericRepository<Specialist>(_context);

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
