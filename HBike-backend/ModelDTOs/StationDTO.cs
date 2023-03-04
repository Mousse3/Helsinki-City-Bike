namespace HBike.DTOs

{
    public class StationDTO
    {
        public long JourneyId { get; set; }

        public DateTime Departure { get; set; }

        public DateTime? Return { get; set; }

        public JourneyNoStationsDTO? DepartureStation { get; set; }

        public JourneyNoStationsDTO? ReturnStation { get; set; }
    }

    public class JourneyNoStationsDTO
    {
        public long JourneyId { get; set; }

        public DateTime Departure { get; set; }

        public DateTime? Return { get; set; }
    }
}