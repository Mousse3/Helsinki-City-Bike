namespace HBike.Models;

public class Journey
{
    public long JourneyId { get; set; }

    public DateTime Departure { get; set; }

    public DateTime? Return { get; set; }

    public Station DepartureStation { get; set; } = null!;

    public Station ReturnStation { get; set; } = null!;
}