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
        public IGenericRepository<Appointment>Appointment { get; }
        public IGenericRepository<ServiceSpecialist> ServiceSpecialist { get; }
        public IGenericRepository<Product> Product { get; }
       // public IGenericRepository<ProductCenter> ProductCenter { get; }
        public IGenericRepository<ShoppingCategory> ShoppingCategory { get; }
        public IGenericRepository<ShoppingCart> ShoppingCart { get; }
        public IGenericRepository<Company> Company { get; }
        public IGenericRepository<ProductCenterColorSize> ProductCenterColorSize { get; }
     //   public IGenericRepository<> ProductColor { get; }
        public IGenericRepository<Review> Review { get; }
        public IGenericRepository<ProductShopCart> ProductShopCart { get; }
        public IGenericRepository<ListImage> ListImage { get; }
        public IGenericRepository<Rating> Reting { get; }
        public IGenericRepository<Notification> Notification { get; }
        public IGenericRepository<Favorate> Favorate { get; }
        Task Save();
        Task<int> CompleteAsync();
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}
