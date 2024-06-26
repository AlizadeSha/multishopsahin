﻿using System.ComponentModel.DataAnnotations.Schema;

namespace MultiShop.Models
{
    public class Product : BaseEntity
    {
       
        public string Name { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SellPrice { get; set; }
        public int Discount { get; set; }
        public int StockCount { get; set; }
        public string ImageUrl { get; set; }
        public float Raiting { get; set; }
    }
}
