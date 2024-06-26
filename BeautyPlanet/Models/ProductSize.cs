﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyPlanet.Models
{
    public class ProductSize
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Sizes))]
        public int SizeId { get; set; }
        public Sizes Size { get; set; }
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public Product Productt { get; set; }
    }
}
