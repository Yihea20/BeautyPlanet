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
       // public IGenericRepository<Product> Product { get; }
       // public IGenericRepository<ProductCenter> ProductCenter { get; }
        public IGenericRepository<ShoppingCategory> ShoppingCategory { get; }
        public IGenericRepository<ShoppingCart> ShoppingCart { get; }
        public IGenericRepository<Store> Store { get; }
        public IGenericRepository<ProductCenterColorSize> ProductCenterColorSize { get; }
     //   public IGenericRepository<> ProductColor { get; }
        public IGenericRepository<Review> Review { get; }
        public IGenericRepository<ProductShopCart> ProductShopCart { get; }
        public IGenericRepository<ListImage> ListImage { get; }
        public IGenericRepository<Rating> Reting { get; }
        public IGenericRepository<Notification> Notification { get; }
        public IGenericRepository<Favorate> Favorate { get; }
        public IGenericRepository<Post>Post { get; }
        public IGenericRepository<CenterCategory>CenterCategory { get; }
        public IGenericRepository<TimeSlot>TimeSlot { get; }
        public IGenericRepository<Code> Code { get; }
        public IGenericRepository<Comment>Comment { get; }
        public IGenericRepository<Rate>Rate { get; }
        public IGenericRepository<Distance> Distance { get;  }
        public IGenericRepository<UserPost> UserPost { get; }
        public IGenericRepository<UserComment> UserComment { get; }
        public IGenericRepository<UserSavedPost> UserSavedPost { get; }
        public IGenericRepository<Admin> Admin { get; }
        public IGenericRepository<StoreShopCategory> StoreShoppCategory { get; }
        public IGenericRepository<HomeImage> HomeImage { get; }
        Task Save();
        Task<int> CompleteAsync();
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}
