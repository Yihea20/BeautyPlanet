using BeautyPlanet.Models;

namespace BeautyPlanet.DTOs
{
    public class CompanyDTO
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }

    }
    public class GetCompanyDTO:CompanyDTO
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<Product> Products { get; set; }

    }
    public class CompanyFile
    {
        public CompanyDTO Companies { get; set; }
        public IFormFile Files { get; set; }

    }
    public class GetProductCompanyDTO : CompanyDTO
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
    }
}
