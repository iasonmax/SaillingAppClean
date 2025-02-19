using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SailingAppClean.Domain.Entities;

namespace SaillingAppClean.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Ship> Ships { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Ship>().HasData(
              new Ship
              {
                  Id = 1,
                  Name = "Sea Serpent",
                  Description = "A classic sailing yacht, perfect for coastal cruises.",
                  BaseDailyRate = 250.00,
                  Capacity = 6,
                  HomePort = "Miami, FL",
                  Damages = null,
                  CreatedDate = DateTime.Now.AddDays(-30),
                  PurchasedDate = new DateTime(2018, 05, 15),
                  LastMaintenanceDate = new DateTime(2023, 10, 20),
                  CategoryId = 3
              },
              new Ship
              {
                  Id = 2,
                  Name = "Ocean Breeze",
                  Description = "A modern catamaran, offering stability and spaciousness.",
                  BaseDailyRate = 400.00,
                  Capacity = 10,
                  HomePort = "Tortola, BVI",
                  Damages = "Minor scratch on hull (repaired)",
                  CreatedDate = DateTime.Now.AddDays(-15),
                  PurchasedDate = new DateTime(2021, 11, 01),
                  LastMaintenanceDate = new DateTime(2024, 01, 10),
                  CategoryId = 4
              },
              new Ship
              {
                  Id = 3,
                  Name = "The Wanderer",
                  Description = "A sturdy motor yacht, ideal for long-distance voyages.",
                  BaseDailyRate = 600.00,
                  Capacity = 8,
                  HomePort = "San Diego, CA",
                  Damages = null,
                  CreatedDate = DateTime.Now.AddDays(-60),
                  PurchasedDate = new DateTime(2015, 07, 04),
                  LastMaintenanceDate = new DateTime(2023, 06, 25),
                  CategoryId = 1
              },
              new Ship
              {
                  Id = 4,
                  Name = "Island Hopper",
                  Description =
                  "A nimble sailboat, great for exploring secluded coves and bays.",
                  BaseDailyRate = 180.00,
                  Capacity = 4,
                  HomePort = "Annapolis, MD",
                  Damages = null,
                  CreatedDate = DateTime.Now.AddDays(-90),
                  PurchasedDate = new DateTime(2022, 03, 10),
                  LastMaintenanceDate = new DateTime(2023, 12, 01),
                  CategoryId = 1
              },
              new Ship
              {
                  Id = 5,
                  Name = "Sunset Dream",
                  Description =
                  "A luxurious superyacht, offering unparalleled comfort and style.",
                  BaseDailyRate = 1200.00,
                  Capacity = 12,
                  HomePort = "Monaco",
                  Damages = "Slight interior damage (being repaired)",
                  CreatedDate = DateTime.Now.AddDays(-5),
                  PurchasedDate = new DateTime(2020, 09, 18),
                  LastMaintenanceDate = new DateTime(2024, 02, 15),
                  CategoryId = 2
              }
            );

            modelBuilder.Entity<Category>().HasData(
               new Category { Id = 1, Name = "Monohull", DisplayOrder = 1 },
               new Category { Id = 2, Name = "Catamaran", DisplayOrder = 2 },
               new Category { Id = 3, Name = "Monohull with deep keel", DisplayOrder = 3 },
               new Category { Id = 4, Name = "Trimaran", DisplayOrder = 4 }
               );
        }
    }
}
