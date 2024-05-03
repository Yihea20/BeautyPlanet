using BeautyPlanet.Models;
using System.ComponentModel.DataAnnotations;

namespace BeautyPlanet.DTOs
{
    public class ShoppingCategoryDTO
    {
       
        public string Name { get; set; }
       }
    public class GetShoppingCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<GetProduct> Products { get; set; }
    }
    public class ShoppingCategoryFile
    {

        public ShoppingCategoryDTO Categories { get; set; }
        public IFormFile Files { get; set; }
    }
    public class GetShoppingCategoryDTO: ShoppingCategoryDTO
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
    }
}
