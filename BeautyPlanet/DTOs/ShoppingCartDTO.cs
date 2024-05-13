using BeautyPlanet.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BeautyPlanet.DTOs
{

    public class GetShoppingCart
    {

        public int Id { get; set; }
        public GetCenterDTO Center { get; set; }
        public GetUserDTO User { get; set; }
        public ICollection<ProductCenterColorSizeDTO> ProductCenterColorSize { get; set; }
        public int TotalPrice { get; set; }
    }
    public class ShopCart
    {
        public int ProductId { get; set; }
        public int CenterId { get; set; }
        public string UserId { get; set; }
        public int SizeId { get; set; } 
        public int ColorId { get; set; }
        public int Count { get; set; }
    }
}
