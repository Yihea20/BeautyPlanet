using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyPlanet.Models
{
    public class CenterCategory
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Center))]
        public int CenterId { get; set; }
        public Center Center { get; set; }
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
