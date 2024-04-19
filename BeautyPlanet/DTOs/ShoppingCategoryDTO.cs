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
     }
}
