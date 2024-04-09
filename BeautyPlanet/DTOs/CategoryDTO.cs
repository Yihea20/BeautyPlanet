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
        
        public ICollection<GetServiceDTO> Services { get; set; }
    }
    public class GetCategoryWithIdDTO:GetCategoryDTO
    {
        public int Id { get; set; }
    }

}
