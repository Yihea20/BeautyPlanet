using BeautyPlanet.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BeautyPlanet.DTOs
{
    public class ProductShopDTO
    {
        public int ProductCenterColorSizeId { get; set; }
        public int ShoppingCartId { get; set; }
        public int count { get; set; }
        
    }
    public class ShoppingCartDTO
    {
        public int CenterId { get; set; }
        public string UserId { get; set; }

    }
}
