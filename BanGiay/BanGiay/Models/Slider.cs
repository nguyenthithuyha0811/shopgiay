namespace BanGiay
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Slider")]
    public partial class Slider
    {
       
        public int Id { get; set; }       
        public string Name { get; set; }
        public string Url { get; set; }
        public string Position { get; set; }
        public string Img { get; set; }
        public int? Orders { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public int Status { get; set; }
    }
}
