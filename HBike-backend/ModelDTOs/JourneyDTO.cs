namespace HBike.DTOs

{
    public class JourneyDTO
    {
        public long JourneyId { get; set; }

        public DateTime Departure { get; set; }

        public DateTime? Return { get; set; }

        public StationNoJourneysDTO? DepartureStation { get; set; }

        public StationNoJourneysDTO? ReturnStation { get; set; }
    }

    public class StationNoJourneysDTO
    {
        public long StationId { get; set; }

        public string StationName { get; set; } = string.Empty;
    }
}