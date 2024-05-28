using BeautyPlanet.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BeautyPlanet.DTOs
{
    public class RatingProdDTO
    {
      
        public string? UserId { get; set; }
       
        public int? ProductId { get; set; }
        public int Rate { get; set; }
    }
}
