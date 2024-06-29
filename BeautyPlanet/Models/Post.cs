using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyPlanet.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string subject { get; set; }
        public IList<string> ImageUrl { get; set; } = new List<string>();
        public int likes { get; set; }
        [ForeignKey(nameof(Center))]
        public int CenterId { get; set; }
        public Center Center { get; set; }
    }
}
