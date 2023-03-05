namespace HBike.Models;

public class Station
{
    public long StationId { get; set; }

    public required string StationName { get; set; }

    public ICollection<Journey>? Departures { get; set; }

    public ICollection<Journey>? Returns { get; set; }
}