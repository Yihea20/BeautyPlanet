using BeautyPlanet.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyPlanet.DTOs
{
    public class ProductDTO
    {

        public string Name { get; set; }
        public int Price { get; set; }
        public int? OfferPercent { get; set; }
        public string? Type { get; set; }
        public int Rate { get; set; }
        public int Conter { get; set; } = 0;
        public int EarnPoint { get; set; }
        public string Description { get; set; }
        public int? ColorId { get; set; }
        public int? SizeId { get; set; }
        public int StoreId { get; set; }
        public int? Count { get; set; }
        public DateTime ProductAddTime { get; set; } = DateTime.Now;
        public int ShoppingCategoryId { get; set; }

    }
    public class GetProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int? OfferPercent { get; set; }
        public int Rate { get; set; }
        public int EarnPoint { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public int Conter { get; set; }
        public int? Count { get; set; }
        public GetProductStoreDTO Store { get; set; }
        public DateTime ProductAddTime { get; set; } = DateTime.Now;
        public List<string> ImageUrl { get; set; }
        public ColorDTO Color { get; set; }
       public SizeDTO Size { get; set; }
        public IList<GetReviewDTO> Reviews { get; set; }
   
    }
    public class GetDashProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int? OfferPercent { get; set; }
        public int Rate { get; set; }
        public int EarnPoint { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public int? Count { get; set; }
        public ShoppingCategoryDTO ShoppingCategoryy { get; set; }
        public DateTime ProductAddTime { get; set; } = DateTime.Now;
        public List<string> ImageUrl { get; set; }
        public ColorDTO Colors { get; set; }
        public SizeDTO Sizes { get; set; }
        public GetReviewDTO Reviews { get; set; }


    }
    public class GetProductSizeColor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int? OfferPercent { get; set; }
        public int Rate { get; set; }
        public int EarnPoint { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime ProductAddTime { get; set; } = DateTime.Now;
        public List<string> ImageUrl { get; set; }
    
        //public GetReviewDTO Reviews { get; set; }
    }
    public class HomeProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int? OfferPercent { get; set; }
        public int Rate { get; set; }
        public int EarnPoint { get; set; }
       // public string Type { get; set; }
        public string Description { get; set; }
        public int Counter { get; set; } 
        public DateTime ProductAddTime { get; set; } = DateTime.Now;
        public List<string> ImageUrl { get; set; }
        public ColorDTO Colors { get; set; }
        public SizeDTO Sizes { get; set; }
        public GetReviewDTO Reviews { get; set; }
        public GetStorDTO Store { get; set; }
        public int? Count { get; set; }

    }
    public class HomeDashProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int? OfferPercent { get; set; }
        public int Rate { get; set; }
        public int EarnPoint { get; set; }
        public string Description { get; set; }
        public ShoppingCategoryDTO ShoppingCategory { get; set; }
        public DateTime ProductAddTime { get; set; } = DateTime.Now;
        public List<string> ImageUrl { get; set; }
        public ColorDTO Color { get; set; }
        public SizeDTO Size { get; set; }
        public GetReviewDTO Reviews { get; set; }
        public GetStorDTO Store { get; set; }
        public int? Count { get; set; }
    }
    public class ProductFile
    {
        

        public ProductDTO Products { get; set; }
        public IList<IFormFile> Files { get; set; }
    }
    public class AppProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public ICollection<Colors> Colors { get; set; }
        public ICollection<Sizes> Sizes { get; set; }
        public string ImageUrl { get; set; }
    }
    
    public class ProductSizeColorDTO
    {
        public int Id { get; set; }
        //public IList<string> ImageUrl { get; set; } = new List<string>();
        public string Name { get; set; }
        public int Price { get; set; }
        public int? OfferPercent { get; set; }
        public string? Type { get; set; }
        public int Rate { get; set; }
        public int Conter { get; set; } = 0;
        public int EarnPoint { get; set; }
        public string Description { get; set; }
        public int? ColorId { get; set; }
        public int? SizeId { get; set; }
        public int StoreId { get; set; }
        public int? Count { get; set; }
        public DateTime ProductAddTime { get; set; } = DateTime.Now;
        public int ShoppingCategoryId { get; set; }

    }
    public class GetProductColorDTO
    {
        
        public ColorDTO Color { get; set; }
     }
    
    public class GetProductSizeDTO
    {
        
        public SizeDTO Sizes { get; set; }
     }
}
