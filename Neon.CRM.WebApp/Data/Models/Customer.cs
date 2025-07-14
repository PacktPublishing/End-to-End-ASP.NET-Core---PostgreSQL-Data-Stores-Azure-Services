using System.ComponentModel.DataAnnotations.Schema;

namespace Neon.CRM.WebApp.Data.Models;

public class Customer
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }

    public Agent? Agent { get; set; }
    public string? AgentId { get; set; }

    public ICollection<Booking> Bookings { get; set; } = [];

    [NotMapped]
    public string FullName => $"{FirstName} {LastName}".Trim();

}
