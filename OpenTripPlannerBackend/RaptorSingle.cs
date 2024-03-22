using GtfsReader;

namespace OpenTripPlannerBackend;

public static class RaptorSingle
{
    private static Reader _reader = new Reader(@"/home/ferdinand/Documents/Projects/OpenTripPlanner/OpenTripPlannerBackend/Data/");

    private static Raptor Raptor = new Raptor(_reader.ReadStops(), _reader.ReadTrips(), _reader.ReadStopTimes(),
        _reader.ReadCalendars(), _reader.ReadCalendarDate(), _reader.ReadTransfers(), _reader.ReadRoutes());

    public static Raptor GetRaptor()
    {
        return Raptor;
    }

    public static void BuildRaptor()
    {
        
    }
}