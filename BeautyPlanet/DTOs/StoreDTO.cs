using BeautyPlanet.Models;

namespace BeautyPlanet.DTOs
{
    public class StoreDTO
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }

    }
    public class GetStorDTO:StoreDTO
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<GetProduct> Products { get; set; }

    }
    public class StoreFile
    {
        public StoreDTO Store { get; set; }
        public IFormFile Files { get; set; }

    }
    public class GetProductStoreDTO : StoreDTO
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
    }
}
