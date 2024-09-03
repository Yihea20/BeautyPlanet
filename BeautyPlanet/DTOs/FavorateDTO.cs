using BeautyPlanet.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyPlanet.DTOs
{
    public class FavorateDTO
    {
        public int CenterId { get; set; }
        public string UserId { get; set; }
    }
    public class GetFavorate
    {
        public int Id { get; set; }


        public GetCenterDTO Center { get; set; }


    }
}
