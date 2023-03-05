namespace HBike.DTOs

{
    public class JourneyDTO
    {
        public long JourneyId { get; set; }
        public DateTime DepartureTime { get; set; }

        public DateTime? ReturnTime { get; set; }

        public required long DepartureStationId { get; set; }

        public long? ReturnStationId { get; set; }
    }
}