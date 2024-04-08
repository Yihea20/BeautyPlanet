using BeautyPlanet.Models;

namespace BeautyPlanet.IRepository
{
    public interface IUnitOfWork:IDisposable
    {
        public IGenericRepository<Center> Center { get; }
        public IGenericRepository<Category> Category { get;}
        public IGenericRepository<Service> Service { get; }
        Task Save();
    }
}
