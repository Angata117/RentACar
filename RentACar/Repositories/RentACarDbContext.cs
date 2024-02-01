using Microsoft.EntityFrameworkCore;
using RentACar.Entities;

namespace RentACar.Repositories
{
    public class RentACarDbContext : DbContext
    {
        public DbSet<Manager> Managers { get; set;}
        public DbSet<User> Users { get; set;}
        public DbSet<Car> Cars { get; set;}
        public DbSet<RentedCars> rentedCars { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer("Server=localhost;Database=RentACarDB;Trusted_Connection=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Manager>().HasData(new Manager()
            {
                Id = 1,
                Username = "angata",
                Password = "angapass",
                FirstName = "Angel",
                LastName = "Kolarov",
                PhoneNumber = "0899999999"
            });
            //modelBuilder.Entity<User>().HasData(new User()
            //{
            //    Id = 1,
            //    FirstName = "Gosho",
            //    LastName = "Georgiev",
            //    EGN = "0310101010",
            //    PhoneNumber = "0893901291"
            //});
            modelBuilder.Entity<Manager>()
                 .HasIndex(nameof(Manager.Username), nameof(User.PhoneNumber))
                 .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(nameof(User.EGN), nameof(User.PhoneNumber))
                .IsUnique();
        }
    }
}
