﻿using BeautyPlanet.Controllers;
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
       // private IGenericRepository<ProductCenter> _productCenter;
      //  private IGenericRepository<Product> _product;
        private IGenericRepository<ShoppingCategory> _shoppingCategory;
        private IGenericRepository<ShoppingCart> _shoppingCart;
        private IGenericRepository<Store> _store;
       // private IGenericRepository<ProductColor> _productColor;
        private IGenericRepository<ProductCenterColorSize> _productCenterColorSize;
        private IGenericRepository<Review> _review;
        private IGenericRepository<ListImage> _listImage;
        private IGenericRepository<ProductShopCart> _prodShopCart;
        private IGenericRepository<Rating> _rating;
        private IGenericRepository<Notification> _notification;
        private IGenericRepository<Favorate> _favorate;
        private IGenericRepository<Post> _post;
        private IGenericRepository<CenterCategory> _centerCategory;
        private IGenericRepository<TimeSlot> _timeSlot;
        private IGenericRepository<Code> _code;
        private IGenericRepository<Comment> _comment;
        private IGenericRepository<Rate> _rate;
        private IGenericRepository<Distance> _distance;
        private IGenericRepository<UserPost> _userPost;
        private IGenericRepository<UserComment> _userComment;
        private IGenericRepository<UserSavedPost> _userSavedPost;
        private IGenericRepository<Admin> _admin;
        private IGenericRepository<StoreShopCategory> _storeShoppCategory;
        private IGenericRepository<HomeImage> _homeImage;
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

       // public IGenericRepository<Product> Product => _product ??=new GenericRepository<Product>(_context);

       // public IGenericRepository<ProductCenter> ProductCenter => _productCenter ??=new GenericRepository<ProductCenter>(_context);

        public IGenericRepository<ShoppingCategory> ShoppingCategory => _shoppingCategory ??=new GenericRepository<ShoppingCategory>(_context);

        public IGenericRepository<ShoppingCart> ShoppingCart => _shoppingCart ??=new GenericRepository<ShoppingCart>(_context);

        public IGenericRepository<Store> Store => _store ??=new GenericRepository<Store>(_context);

        
        public IGenericRepository<Review> Review => _review ??=new GenericRepository<Review>(_context);

        public IGenericRepository<ListImage> ListImage => _listImage ??=new GenericRepository<ListImage>(_context);

        public IGenericRepository<ProductCenterColorSize> ProductCenterColorSize => _productCenterColorSize ??=new GenericRepository<ProductCenterColorSize>(_context);

        public IGenericRepository<ProductShopCart> ProductShopCart => _prodShopCart ??=new GenericRepository<ProductShopCart>(_context);

        public IGenericRepository<Rating> Reting => _rating ??=new GenericRepository<Rating>(_context);

        public IGenericRepository<Notification> Notification => _notification ??=new GenericRepository<Notification>(_context);

        public IGenericRepository<Favorate> Favorate => _favorate ??=new GenericRepository<Favorate>(_context);

        public IGenericRepository<Post> Post => _post ??=new GenericRepository<Post>(_context);

        public IGenericRepository<CenterCategory> CenterCategory => _centerCategory ??=new GenericRepository<CenterCategory>(_context);

        public IGenericRepository<TimeSlot> TimeSlot => _timeSlot= new GenericRepository<TimeSlot>(_context);

        public IGenericRepository<Code> Code => _code ??=new GenericRepository<Code>(_context);

        public IGenericRepository<Comment> Comment => _comment ??=new GenericRepository<Comment>(_context);

        public IGenericRepository<Rate> Rate => _rate ??=new GenericRepository<Rate>(_context);

        public IGenericRepository<Distance> Distance => _distance ??=new GenericRepository<Distance>(_context);

        public IGenericRepository<UserPost> UserPost => _userPost ??=new GenericRepository<UserPost>(_context);

        public IGenericRepository<UserComment> UserComment => _userComment ??=new GenericRepository<UserComment>(_context);

        public IGenericRepository<UserSavedPost> UserSavedPost => _userSavedPost ??=new GenericRepository<UserSavedPost>(_context);

        public IGenericRepository<Admin> Admin => _admin ??=new GenericRepository<Admin>(_context);



        public IGenericRepository<StoreShopCategory> StoreShoppCategory =>_storeShoppCategory ??=new GenericRepository<StoreShopCategory>(_context);

        public IGenericRepository<HomeImage> HomeImage => _homeImage ??=new GenericRepository<HomeImage>(_context);

        public Task BeginTransactionAsync()
        {
            throw new NotImplementedException();
        }

        public Task CommitTransactionAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> CompleteAsync()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public Task RollbackTransactionAsync()
        {
            throw new NotImplementedException();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
