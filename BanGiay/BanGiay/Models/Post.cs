namespace BanGiay
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Post")]
    public partial class Post
    {
        public int Id { get; set; }
        public int? TopId { get; set; }       
        public string Title { get; set; }     
        public string Slug { get; set; }      
        public string Detail { get; set; }
        public string Img { get; set; }
        public string Type { get; set; }
        public string MetaKey { get; set; }
        public string MetaDesc { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }       
        public DateTime UpdatedAt { get; set; } 
        public int UpdatedBy { get; set; }
        public int Status { get; set; }
    }
}
