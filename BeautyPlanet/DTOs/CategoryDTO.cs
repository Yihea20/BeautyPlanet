using BeautyPlanet.Models;
using System.Text.Json.Serialization;

namespace BeautyPlanet.DTOs
{
    public class CategoryDTO
    {
        public string Name { get; set; }
        
    }

    public class GetCategoryDTO:CategoryDTO
    {
        public string ImageUrl { get; set; }
        public ICollection<GetServiceDTO> Services { get; set; }
    }
    public class GetCategoryWithIdDTO:GetCategoryDTO
    {
        public int Id { get; set; }
    }
    public class CategoryIdDTO:CategoryDTO
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
    }
    public class CategoryFile
    {

        public CategoryDTO Categories { get; set; }
        public IFormFile Files { get; set; }
    }

}
