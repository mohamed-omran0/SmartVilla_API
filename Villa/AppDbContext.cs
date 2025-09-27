using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Villa.Model.Entity;

namespace Villa
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            var adminRoleId = "a71a55d6-99d7-4123-b4e0-1218ecb90e3e";
            var userRoleId = "c309fa92-2123-47be-b397-a1c77adb502c";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = adminRoleId,
                    ConcurrencyStamp = adminRoleId,
                    Name = "admin",
                    NormalizedName = "admin".ToUpper()
                },
                new IdentityRole
                {
                    Id = userRoleId,
                    ConcurrencyStamp = userRoleId,
                    Name = "user",
                    NormalizedName = "user".ToUpper()
                }
            };

           modelBuilder.Entity<IdentityRole>().HasData(roles);









            modelBuilder.Entity<VillaNumber>().Property(x => x.CreatedTime)
                .HasDefaultValueSql("GETDATE()");


            modelBuilder.Entity<villa>().Property(x => x.CreatedTime)
                .HasDefaultValueSql("GETDATE()");



            modelBuilder.Entity<villa>().HasData(
                new villa
                {
                    Id = 1,
                    Name = "Royal Villa",
                    Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                    ImageUrl = "https://dotnetmastery.com/bluevillaimages/villa3.jpg",
                    Rate = 200,
                    Sqft = 550,
                    Amenity = "",

                },
              new villa
              {
                  Id = 2,
                  Name = "Premium Pool Villa",
                  Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                  ImageUrl = "https://dotnetmastery.com/bluevillaimages/villa1.jpg",
                  Rate = 300,
                  Sqft = 550,
                  Amenity = "",

              },
              new villa
              {
                  Id = 3,
                  Name = "Luxury Pool Villa",
                  Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                  ImageUrl = "https://dotnetmastery.com/bluevillaimages/villa4.jpg",
                  Rate = 400,
                  Sqft = 750,
                  Amenity = "",

              },
              new villa
              {
                  Id = 4,
                  Name = "Diamond Villa",
                  Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                  ImageUrl = "https://dotnetmastery.com/bluevillaimages/villa5.jpg",
                  Rate = 550,
                  Sqft = 900,
                  Amenity = "",

              },
              new villa
              {
                  Id = 5,
                  Name = "Diamond Pool Villa",
                  Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                  ImageUrl = "https://dotnetmastery.com/bluevillaimages/villa2.jpg",
                  Rate = 600,
                  Sqft = 1100,
                  Amenity = "",

              });
            //---------------------------------------------------------
            
        }
        public DbSet<LocalUser> LocalUsers { get; set; }
        public DbSet<villa> Villas { get; set; }
        public DbSet<VillaNumber> VillaNumbers { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers{ get; set; }

    }
}
