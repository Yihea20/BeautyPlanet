namespace BeautyPlanet.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
