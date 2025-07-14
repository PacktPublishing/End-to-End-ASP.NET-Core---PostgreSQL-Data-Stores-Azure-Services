using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Neon.CRM.WebApp.Data.Models;

public class Agent : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? TenantConnectionString { get; set; }

    // Navigation property
    public ICollection<Customer> Customers { get; set; } = [];

    [NotMapped]
    public string FullName => $"{FirstName} {LastName}".Trim();
}
