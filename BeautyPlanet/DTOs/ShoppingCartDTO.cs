﻿using BeautyPlanet.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BeautyPlanet.DTOs
{

    public class GetShoppingCart
    {

        public int Id { get; set; }
        //public int? StatusId { get; set; }
        public Status Status { get; set; }
        public GetStorDTO Store { get; set; }
        public GetUserDTO User { get; set; }
        public ICollection<ProductCenterColorSizeDTO> ProductCenterColorSize { get; set; }
        public int TotalPrice { get; set; }
        public int TotalCount { get; set; }
    }
    public class GetShoppingCartDTO
    {
        public int Id { get; set; }
        public GetStorDTO Store { get; set; }
        public GetUserDTO User { get; set; }
        public ICollection<ProductCenterColorSizeDTO> ProductCenterColorSize { get; set; }
        public int count { get; set; }
        public int TotalPrice { get; set; }

    }
    public class GetCartDTO
    {
      public   GetShoppingCart ShoppingCart { get; set; }
        //public int count { get; set; }
    }
    public class ShopCart
    {
        public int ProductId { get; set; }
        public int StoreId { get; set; }
        public string UserId { get; set; }
        public int Count { get; set; }
    }
}
