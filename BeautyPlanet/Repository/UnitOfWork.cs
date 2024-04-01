using BeautyPlanet.DataAccess;
using BeautyPlanet.IRepository;

namespace BeautyPlanet.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly BeautyDbContext _context;
        public UnitOfWork(BeautyDbContext context)
        {
            _context = context;
        }
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
