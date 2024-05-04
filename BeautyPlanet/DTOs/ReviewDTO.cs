using BeautyPlanet.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyPlanet.DTOs
{
    public class ReviewDTO
    {
        public string UserId { get; set; }
        public int rate { get; set; }
        public int ProductId { get; set; }
        public string Desc { get; set; }
       
    }
    public class GetReviewDTO
    {
        public int Id { get; set; }

        public UserReviews Userr { get; set; }
        public int rate { get; set; }
        public string Desc { get; set; }
        public DateTime DateTime { get; set; }

    }
}
