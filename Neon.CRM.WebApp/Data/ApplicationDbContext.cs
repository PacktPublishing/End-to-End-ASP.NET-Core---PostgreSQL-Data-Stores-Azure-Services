using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Neon.CRM.WebApp.Data.Models;

namespace Neon.CRM.WebApp.Data;

public class ApplicationDbContext : IdentityDbContext<Agent>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<VacationPackage> VacationPackages { get; set; } = null!;
    public DbSet<Booking> Bookings { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<VacationPackage>().HasData(
            new VacationPackage
            {
                Id = 1,
                Title = "Tropical Paradise",
                Description = "Experience the beauty of tropical beaches and lush landscapes.",
                Price = 1999.99m,
                DurationInDays = 7
            },
            new VacationPackage
            {
                Id = 2,
                Title = "Mountain Adventure",
                Description = "Experience the thrill of hiking, camping, and breathtaking mountain views for 7 days.",
                Price = 1299.50m,
                DurationInDays = 7
            },
            new VacationPackage
            {
                Id = 3,
                Title = "European Explorer",
                Description = "Visit historic cities across Europe on a 10-day guided luxury tour.",
                Price = 2499.00m,
                DurationInDays = 10
            }
        );
    }
}
