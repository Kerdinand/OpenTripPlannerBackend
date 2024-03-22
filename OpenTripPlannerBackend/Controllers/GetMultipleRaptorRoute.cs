using Microsoft.AspNetCore.Mvc;
using OpenTripPlannerBackend.DTO;

namespace OpenTripPlannerBackend.Controllers;

[ApiController]
[Route("[controller]")]
public class GetMultipleRaptorRoute
{
    [HttpGet(Name = "GetMultipleRaptorRoute")]
    public string Get([FromBody] RaptorDTO.RaptorGetDTO data)
    {
        DateTime departureTime = DateTime.Parse(data.departureTime);
        string result = RaptorSingle.GetRaptor().GetQuickestRoute(data.start, data.end, data.numberOfRounds,
            data.maximumWaitingTime, departureTime) + "\n";
        result += RaptorSingle.GetRaptor().GetQuickestRoute(data.start, data.end, data.numberOfRounds,
            data.maximumWaitingTime, departureTime.AddMinutes(20)) + "\n";
        result += RaptorSingle.GetRaptor().GetQuickestRoute(data.start, data.end, data.numberOfRounds,
            data.maximumWaitingTime, departureTime.AddMinutes(40)) + "\n";
        
        /*string firstDepartureTime = result.Split('-')[0].Trim();
        if ("no way" == firstDepartureTime)
        {
            return "no way";
        }
        TimeSpan timeSpan = DateTime.Parse(firstDepartureTime) - departureTime;
        departureTime = departureTime.Add(timeSpan).AddHours(-1);
        result += "\n " + RaptorSingle.GetRaptor().GetQuickestRoute(data.start, data.end, data.numberOfRounds,
            data.maximumWaitingTime, departureTime);
        
        firstDepartureTime = result.Split('-')[0].Trim();
        if ("no way" == firstDepartureTime)
        {
            return "no way";
        }
        timeSpan = DateTime.Parse(firstDepartureTime) - departureTime;
        departureTime = departureTime.Add(timeSpan).AddHours(-1);
        result += "\n " + RaptorSingle.GetRaptor().GetQuickestRoute(data.start, data.end, data.numberOfRounds,
            data.maximumWaitingTime, departureTime); */

        return result;
    }
}