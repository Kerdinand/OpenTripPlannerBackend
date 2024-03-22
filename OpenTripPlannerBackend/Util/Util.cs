using GtfsReader.Structures;

namespace OpenTripPlannerBackend.Util;

public static class Util
{
    public static string RaptorResultStringBuilder(List<Stop> result)
    {
        string tripInfo = "";
        for (int i = 0; i + 1 < result.Count; i++)
        {
            if (result[i].label.departingTrip != null)
            {
                tripInfo += result[i].parentStop.label.departingTrip.GetDepartureTime() + "  -  " + result[i].stop_name + " using: " +result[i].label.departingTrip.route.route_short_name + "\n";
                foreach (StopTime stopTime in result[i].parentStop.label.departingTrip.intermediateStops)
                {
                    if (stopTime.stop.parentStop.stop_id == result[i+1].parentStop.stop_id) break;
                    tripInfo += "  - " + stopTime.arrival_time + " , " + stopTime.stop.stop_name + " , " +
                                stopTime.departure_time + "\n";
                }
            }
            else
            {
                tripInfo +=
                    $"Transfer von {result[i].parentStop.stop_name}, @{result[i].parentStop.label.departureTime} -> {result[i + 1].parentStop.stop_name} @{result[i + 1].parentStop.label.arrivalTime}";
            }
        }

        tripInfo += "\n" + result[^1].parentStop.label.arrivalTime + "  -  " + result[^1].stop_name;
        Console.WriteLine(tripInfo);
        return tripInfo;
    }

    public static DateTime GetTimeForNextQuery(List<Stop> result)
    {
        if (!result.Any()) return DateTime.Now;
        if (result[0].label.exitTrip == null)
        {
            return result[0].label.departureTime;

        }
        else
        {
            TimeOnly tmp = result[1].label.exitTrip.GetDepartureTime();
            DateOnly date = DateOnly.FromDateTime(result[0].label.arrivalTime);
            return new DateTime(date.Year, date.Month, date.Day, tmp.Hour, tmp.Minute, tmp.Second).AddMinutes(1);
        }
    }
}