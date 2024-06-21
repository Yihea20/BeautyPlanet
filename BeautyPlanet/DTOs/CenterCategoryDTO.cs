using BeautyPlanet.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BeautyPlanet.DTOs
{
    public class CenterCategoryDTO
    {
        public int CenterId { get; set; }
        public int CategoryId { get; set; }
    }
    public class GetCenterCategory
    {
        public int Id { get; set; }
        public Center Center { get; set; }
        public Category Category { get; set; }
    }
}
