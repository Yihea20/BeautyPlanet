using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyPlanet.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public User Userr { get; set; }
        public int rate { get; set; }
        [ForeignKey(nameof(ProductCenterColorSize))]
        public int ProductId { get; set; }
        public ProductCenterColorSize Productt { get; set; }
        public string Desc { get; set; }
        public DateTime ReviewAddTime { get; set; } = DateTime.Now;
    }
}
