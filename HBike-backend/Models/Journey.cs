namespace HBike.Models;

public class Journey
{
    public long JourneyId { get; set; }

    public DateTime DepartureTime { get; set; }

    public DateTime? ReturnTime { get; set; }

    public required long DepartureStationId { get; set; }
    public required Station DepartureStation { get; set; }

    public long? ReturnStationId { get; set; }
    public Station? ReturnStation { get; set; }
}