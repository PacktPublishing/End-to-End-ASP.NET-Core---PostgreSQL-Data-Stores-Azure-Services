using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Neon.CRM.WebApp.Data.Models;
using Neon.CRM.WebApp.Helpers;

namespace Neon.CRM.WebApp.Data;

public class TenantDbContext : IdentityDbContext<Agent>
{
    public TenantDbContext(DbContextOptions<TenantDbContext> options)
        : base(options)
    {
    }
    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<VacationPackage> VacationPackages { get; set; } = null!;
    public DbSet<Booking> Bookings { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}

public class TenantDbContextFactory
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IConfiguration _configuration;

    public TenantDbContextFactory(IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
    {
        this._httpContextAccessor = httpContextAccessor;
        this._configuration = configuration;
    }

    public TenantDbContext Create()
    {
        var user = _httpContextAccessor.HttpContext?.User;
        var connectionString = user?.FindFirst("TenantConnectionString")?.Value;
        
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("Tenant connection string is not available.");
        }

        var decryptedConnectionString = EncryptionHelper.Decrypt(connectionString, _configuration["ENCRYPTION_KEY"]);
        var optionsBuilder = new DbContextOptionsBuilder<TenantDbContext>();
        optionsBuilder.UseNpgsql(decryptedConnectionString);
        return new TenantDbContext(optionsBuilder.Options);
    }
}
