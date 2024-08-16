﻿namespace BagXML.DAL.Entities
{
    public sealed class ProductEntity : BaseEntity
    {
        public int Quantity { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
