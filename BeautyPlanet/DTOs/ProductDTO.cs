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
        public string ImageUrl { get; set; }
        public ICollection<ColorDTO> Colors { get; set; }
       public ICollection<SizeDTO> Sizes { get; set; }
        public ICollection<GetCenterDTO> Centers { get; set; }
        public ICollection<GetReviewDTO> Reviews { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
    }
    public class ProductFile
    {
        

        public ProductDTO Products { get; set; }
        public IFormFile Files { get; set; }
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
    public class ProductColorDTO
    {
        public int ColorId { get; set; }
        public int ProductId { get; set; }
      }
    public class GetProductColorDTO
    {
        public int ColorId { get; set; }
        public Colors Color { get; set; }
          }
    public class ProductSizeDTO
    {
        public int SizeId { get; set; }
        public int ProductId { get; set; }
    }
    public class GetProductSizeDTO
    {
        public int SizeId { get; set; }
        public Sizes Size { get; set; }
           }
}
