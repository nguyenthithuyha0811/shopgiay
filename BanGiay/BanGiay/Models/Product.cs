namespace BanGiay
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public int Id { get; set; }
        public int CatId { get; set; }
        public int Submenu { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Img { get; set; }
        public string Detail { get; set; }
        public int Number { get; set; }
        public double Price { get; set; }
        public double PriceSale { get; set; }
        public string MetaKey { get; set; }
        public string MetaDesc { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UpdatedBy { get; set; }
        public int Status { get; set; }
        public int Sold { get; set; }
    }
}
