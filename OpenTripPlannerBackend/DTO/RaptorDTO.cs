namespace OpenTripPlannerBackend.DTO;

public class RaptorDTO
{
    public class RaptorGetDTO
    {
        public string start { get; set; }
        public string end { get; set; }
        public int numberOfRounds { get; set; }
        public int maximumWaitingTime { get; set; }
        public string departureTime { get; set; }
    }
}