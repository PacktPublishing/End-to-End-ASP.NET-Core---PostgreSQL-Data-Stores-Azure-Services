namespace Neon.CRM.WebApp.Data.Models;

public class VacationPackage
{
    public int Id { get; set; }

    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int DurationInDays { get; set; }

    // Navigation property
    public ICollection<Booking> Bookings { get; set; } = [];
}
