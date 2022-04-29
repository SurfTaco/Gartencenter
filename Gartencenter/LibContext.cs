using Gartencenter.Model;
using Microsoft.EntityFrameworkCore;

namespace Gartencenter
{
    public class LibContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Lieferant> Lieferanten { get; set; }
        public DbSet<Lieferung> Lieferung { get; set; }

        public LibContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"server=localhost\SQLEXPRESS;database=Gartencenter;trusted_connection=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedData(modelBuilder);
        }
        void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasData(new Category
                {
                    Id = 1,
                    Name = "Balkonpflanze",

                }
                , new Category
                {
                    Id = 2,
                    Name = "Strauch",

                },
                new Category
                {
                    Id = 3,
                    Name = "Baum",

                });

            modelBuilder.Entity<Article>()
                .HasData(new Article
                {
                    Id = 1,
                    Name = "Tulpe",
                    Price = 5.99m,
                    CategoryID = 1
                },
                new Article
                {
                    Id = 2,
                    Name = "Buchs",
                    Price = 16.99m,
                    CategoryID = 2
                },
                new Article
                {
                    Id = 3,
                    Name = "Ahornbaum",
                    Price = 55.98m,
                    CategoryID = 3
                });

            modelBuilder.Entity<Account>()
                .HasData(new Account
                {
                    Id = 1,
                    Username = "test@test.at",
                    Password = "Test1234!"
                });

            modelBuilder.Entity<Lieferant>()
               .HasData(new Lieferant
               {
                   Id = 1,
                   Name = "Obi",
                   Country = "Innsbruck"
               },
               new Lieferant
               {
                   Id = 2,
                   Name = "Hornbach",
                   Country = "Neu Rum"
               },
               new Lieferant
               {
                   Id = 3,
                   Name = "Bauhaus",
                   Country = "Völs"
               });
        }
    }
}
