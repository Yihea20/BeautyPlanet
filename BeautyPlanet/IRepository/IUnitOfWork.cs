using BeautyPlanet.Models;

namespace BeautyPlanet.IRepository
{
    public interface IUnitOfWork:IDisposable
    {
        public IGenericRepository<Center> Center { get; }
        public IGenericRepository<Category> Category { get;}
        public IGenericRepository<Service> Service { get; }
        public IGenericRepository<User> User { get; }
        public IGenericRepository<Specialist> Specialist { get; }
        Task Save();
    }
}
