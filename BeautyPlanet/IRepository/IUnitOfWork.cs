namespace BeautyPlanet.IRepository
{
    public interface IUnitOfWork:IDisposable
    {
        Task Save();
    }
}
