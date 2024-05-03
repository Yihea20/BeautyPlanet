using BeautyPlanet.Models;
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
        public int? ColorId { get; set; }
        public int? SizeId { get; set; }
        public int CompanyId { get; set; }
      

    }
    public class GetProduct:ProductDTO
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public GetShoppingCategoryDTO ShoppingCategoryy { get; set; }
        public GetProductCompanyDTO Companyy { get; set; }
        public Colors Color { get; set; }
        public Sizes Sizess { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
        public ICollection<GetCenterDTO> Centers { get; set; }
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
        public Colors? Color { get; set; }
        public Sizes? Sizess { get; set; }
        public string ImageUrl { get; set; }
    }
}
