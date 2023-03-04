namespace HBike.Models;

public class Station
{
    public long StationId { get; set; }

    public string StationName { get; set; } = string.Empty;

    public ICollection<Journey>? Departures { get; set; }

    public ICollection<Journey>? Returns { get; set; }
}