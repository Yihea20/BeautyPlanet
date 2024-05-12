using BeautyPlanet.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BeautyPlanet.DTOs
{
    public class ShoppingCartDTO
    {
        public int ProductCenterId { get; set; }
        public string UserId { get; set; }
        public int Count { get; set; }

    }
    public class GetShoppingCart
    {
        
        public int Id { get; set; }
        public int ProductCenterId { get; set; }
        public GetProductCenter ProductCenterr { get; set; }
        public string UserId { get; set; }
        public GetUserDTO Userr { get; set; }
        public int Count { get; set; }
    }
    public class ShopCart
    {
        public int ProductId { get; set; }
        public int CenterId { get; set; }
        public string UserId { get; set; }
        public int SizeId { get; set; } 
        public int ColorId { get; set; }
    }
}
