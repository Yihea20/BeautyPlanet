using BeautyPlanet.Controllers;
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
        private IGenericRepository<Offer> _offer;
        private IGenericRepository<ServiceCenter> _serviceCenter;
        private IGenericRepository<Image> _image;
        private IGenericRepository<Gallery> _gallery;
        private IGenericRepository<Appointment> _appointement;
        private IGenericRepository<ServiceSpecialist> _serviceSpecialist;
        private IGenericRepository<ProductCenter> _productCenter;
        private IGenericRepository<Product> _product;
        private IGenericRepository<ShoppingCategory> _shoppingCategory;
        private IGenericRepository<ShoppingCart> _shoppingCart;
        private IGenericRepository<Company> _company;
       // private IGenericRepository<ProductColor> _productColor;
        private IGenericRepository<ProductColorSize> _productColorSize;
        private IGenericRepository<Review> _review;
        private IGenericRepository<ListImage> _listImage;
        public UnitOfWork(BeautyDbContext context)
        {
            _context = context;
        }

        public IGenericRepository<Center> Center => _center ??= new GenericRepository<Center>(_context);
        public IGenericRepository<Category> Category => _category ??= new GenericRepository<Category>(_context);
        public IGenericRepository<Service> Service => _service ??= new GenericRepository<Service>(_context);

        public IGenericRepository<User> User =>_user ??=new GenericRepository<User>(_context);

        public IGenericRepository<Specialist> Specialist =>_specialist ??=new GenericRepository<Specialist>(_context);

        public IGenericRepository<Offer> Offer => _offer ??=new GenericRepository<Offer>(_context);

        public IGenericRepository<ServiceCenter> ServiceCenter => _serviceCenter ??=new GenericRepository<ServiceCenter>(_context);

        public IGenericRepository<Image> Image => _image ??=new GenericRepository<Image>(_context);

        public IGenericRepository<Gallery> Gallery => _gallery ??=new GenericRepository<Gallery>(_context);

        public IGenericRepository<Appointment> Appointment =>_appointement ??= new GenericRepository<Appointment>(_context);

        public IGenericRepository<ServiceSpecialist> ServiceSpecialist => _serviceSpecialist ??=new GenericRepository<ServiceSpecialist>(_context);

        public IGenericRepository<Product> Product => _product ??=new GenericRepository<Product>(_context);

        public IGenericRepository<ProductCenter> ProductCenter => _productCenter ??=new GenericRepository<ProductCenter>(_context);

        public IGenericRepository<ShoppingCategory> ShoppingCategory => _shoppingCategory ??=new GenericRepository<ShoppingCategory>(_context);

        public IGenericRepository<ShoppingCart> ShoppingCart => _shoppingCart ??=new GenericRepository<ShoppingCart>(_context);

        public IGenericRepository<Company> Company => _company ??=new GenericRepository<Company>(_context);

        
        public IGenericRepository<Review> Review => _review ??=new GenericRepository<Review>(_context);

        public IGenericRepository<ListImage> ListImage => _listImage ??=new GenericRepository<ListImage>(_context);

        public IGenericRepository<ProductColorSize> ProductColorSize => _productColorSize ??=new GenericRepository<ProductColorSize>(_context);

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
