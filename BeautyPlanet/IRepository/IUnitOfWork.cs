using BeautyPlanet.Models;

namespace BeautyPlanet.IRepository
{
    public interface IUnitOfWork:IDisposable
    {
        public IGenericRepository<Center> Center { get; }
        Task Save();
    }
}
