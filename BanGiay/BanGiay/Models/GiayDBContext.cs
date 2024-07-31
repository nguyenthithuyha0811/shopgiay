using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BanGiay.Models
{
    public partial class GiayDBContext : DbContext
    {
        public GiayDBContext()
            : base("name=GiayDBContext")
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<Link> Link { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderDetail> OrderDetail { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Slider> Slider { get; set; }
        public virtual DbSet<Topic> Topic { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(e => e.Slug)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Link>()
                .Property(e => e.Slug)
                .IsUnicode(false);

            modelBuilder.Entity<Link>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<Menu>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<Menu>()
                .Property(e => e.Link)
                .IsUnicode(false);

            modelBuilder.Entity<Menu>()
                .Property(e => e.Position)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.DeliveryPhone)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.DeliveryEmail)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.Slug)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.Img)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Img)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .Property(e => e.AccessName)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .Property(e => e.GroupId)
                .IsUnicode(false);

            modelBuilder.Entity<Slider>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<Slider>()
                .Property(e => e.Position)
                .IsUnicode(false);

            modelBuilder.Entity<Slider>()
                .Property(e => e.Img)
                .IsUnicode(false);

            modelBuilder.Entity<Topic>()
                .Property(e => e.Slug)
                .IsUnicode(false);

            modelBuilder.Entity<Topic>()
                .Property(e => e.MetaKey)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Img)
                .IsUnicode(false);
        }
    }
}
