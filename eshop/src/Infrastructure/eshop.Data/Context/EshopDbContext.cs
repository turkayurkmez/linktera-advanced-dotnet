using eshop.Entities;
using Microsoft.EntityFrameworkCore;

namespace eshop.Data.Context
{
    public class EshopDbContext : DbContext
    {
        public EshopDbContext(DbContextOptions<EshopDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //fluent api:
            modelBuilder.Entity<Product>().Property(p => p.Name).IsRequired()
                                                                .HasMaxLength(300);

            modelBuilder.Entity<Product>().HasOne(p => p.Category)
                                          .WithMany(c => c.Products)
                                          .HasForeignKey(p => p.CategoryId)
                                          .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Category>().HasData(new Category[]
            {
                new Category{ Id=1, Name="Kırtasiye"},
                new Category{ Id=2, Name="Kitap"},
                new Category{ Id=3, Name="Elektronik"}
            });

            modelBuilder.Entity<Product>().HasData(new Product[]
            {
                new Product{ Id = 1, Name="Kalem seti", CategoryId=1, Description="Kalem...", Price=100, Discount= 0.2m  },
                new Product{ Id = 2, Name="Spinoza'nın sevinci nereden geliyor", CategoryId=2, Description="Kalem...", Price=100, Discount= 0.2m  },
                new Product{ Id = 3, Name="Kulaklık", CategoryId=3, Description="Bose kulaklık", Price=1000, Discount= 0.2m  },

            });

        }

        //public override int SaveChanges()
        //{
        //    //Log db burada....
        //    return base.SaveChanges();
        //}


    }
}
