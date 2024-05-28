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
        public int Rate { get; set; }
         public int EarnPoint { get; set; }
        public string Description { get; set; }
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
        public string Description { get; set; }
        public int Conter { get; set; }
        public DateTime ProductAddTime { get; set; } = DateTime.Now;
        public List<string> ImageUrl { get; set; }
        public ICollection<ColorDTO> Colors { get; set; }
       public ICollection<SizeDTO> Sizes { get; set; }
        public ICollection<GetReviewDTO> Reviews { get; set; }
       

    }
    public class GetDashProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int? OfferPercent { get; set; }
        public int Rate { get; set; }
        public int EarnPoint { get; set; }
        public string Description { get; set; }
        public ShoppingCategoryDTO ShoppingCategoryy { get; set; }
        public DateTime ProductAddTime { get; set; } = DateTime.Now;
        public List<string> ImageUrl { get; set; }
        public ICollection<ColorDTO> Colors { get; set; }
        public ICollection<SizeDTO> Sizes { get; set; }
        public ICollection<GetReviewDTO> Reviews { get; set; }


    }
    public class GetProductSizeColor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int? OfferPercent { get; set; }
        public int Rate { get; set; }
        public int EarnPoint { get; set; }
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
        public string Description { get; set; }
        public int Counter { get; set; } 
        public DateTime ProductAddTime { get; set; } = DateTime.Now;
        public List<string> ImageUrl { get; set; }
        public ICollection<ColorDTO> Colors { get; set; }
        public ICollection<SizeDTO> Sizes { get; set; }
        public ICollection<GetReviewDTO> Reviews { get; set; }
        public GetCenterDTO Centers { get; set; }
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
        public ShoppingCategoryDTO ShoppingCategoryy { get; set; }
        public DateTime ProductAddTime { get; set; } = DateTime.Now;
        public List<string> ImageUrl { get; set; }
        public ICollection<ColorDTO> Colors { get; set; }
        public ICollection<SizeDTO> Sizes { get; set; }
        public ICollection<GetReviewDTO> Reviews { get; set; }
        public GetCenterDTO Centers { get; set; }
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
        public int? ColorId { get; set; }
        public int? SizeId { get; set; }
        public int ProductId { get; set; }
        public int CenterId { get; set; }
        public int Count { get; set; }
      }
    public class GetProductColorDTO
    {
        
        public ColorDTO Color { get; set; }
     }
    
    public class GetProductSizeDTO
    {
        
        public SizeDTO Size { get; set; }
     }
}
