namespace BeautyPlanet.Models
{
    public class TimeModel
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public ICollection<Specialist>? Specialists { get; set; }
        public ICollection<User>? Users { get; set; }
    }
}
