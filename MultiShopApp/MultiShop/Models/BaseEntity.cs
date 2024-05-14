﻿namespace MultiShop.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdateTime { get; set; }= DateTime.Now;
    }
}
