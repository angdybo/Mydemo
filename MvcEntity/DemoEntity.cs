using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace MvcEntity
{
    public partial class DemoEntity : DbContext
    {
        public DemoEntity()
            : base("name=DemoEntity")
        {
        }

        public virtual DbSet<Goods> Goods { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Goods>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Goods>()
                .Property(e => e.UnitPrice)
                .HasPrecision(18, 0);
        }
    }
}
