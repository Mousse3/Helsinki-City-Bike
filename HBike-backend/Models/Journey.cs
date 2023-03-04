namespace HBike.Models;

public class Journey
{
    public long JourneyId { get; set; }

    public DateTime DepartureTime { get; set; }

    public DateTime? ReturnTime { get; set; }
}