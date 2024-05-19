using BeautyPlanet.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BeautyPlanet.DTOs
{
    public class ProductCenterDTO
    {

        public int CenterId { get; set; }
        public int ProductId { get; set; }
        
    }
    public class GetProductCenter:ProductCenterDTO
    {

        public int Id { get; set; }
        public GetCenterDTO Center { get; set; }
        public GetProduct Product { get; set; }
        public ICollection<ShoppingCartDTO> ShoppingCarts { get; set; }

    }
    public class ProductDetels
    {
        public GetProduct Product{ get; set; }
        public GetCenterDTO Center { get; set; }
}
    public class ProductCenterColorSizeDTO
    {
        public int Id { get; set; }
        public GetProductSizeColor Product { get; set; }
        public ColorDTO Color { get; set; }
        public SizeDTO Size { get; set; }
        public int Count { get; set; }
        //public GetCenterDTO Centers { get; set; }
    }
}
