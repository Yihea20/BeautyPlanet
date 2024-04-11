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
        public IGenericRepository<Offer> Offer { get; }
        public IGenericRepository<ServiceCenter> ServiceCenter { get; }
        public IGenericRepository<Image> Image { get; }
        public IGenericRepository<Gallery> Gallery { get; }
        Task Save();
    }
}
