namespace BanGiay.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Link")]
    public partial class Link
    {
        public int Id { get; set; }

        public string Slug { get; set; }

        public int? TableId { get; set; }

        [StringLength(200)]
        public string Type { get; set; }

        public int? ParentId { get; set; }
    }
}
