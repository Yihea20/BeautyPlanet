using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyPlanet.Models
{
    public class UserTimeModel
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public User Userr { get; set; }
        [ForeignKey(nameof(TimeModel))]
        public int TimeModelId { get; set; }
        public TimeModel TimeModell { get; set; }

    }
}
