namespace BanGiay
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Role")]
    public partial class Role
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string AccessName { get; set; }
        public string Description { get; set; }
        public string GroupId { get; set; }
    }
}
