using GtfsReader.Structures;
using Microsoft.AspNetCore.Mvc;
using OpenTripPlannerBackend.DTO;

namespace OpenTripPlannerBackend.Controllers;
[ApiController]
[Route("[controller]")]
public class RaptorRouteController : ControllerBase
{
    [HttpGet(Name = "GetRaptorRoute")]
    public string Get([FromBody] RaptorDTO.RaptorGetDTO data)
    {   
        Console.Clear();
        List<Stop> result = RaptorSingle.GetRaptor().GetQuickestRoute(data.start, data.end, data.numberOfRounds, data.maximumWaitingTime, DateTime.Parse(data.departureTime));
        Console.WriteLine(Util.Util.GetTimeForNextQuery(result));
        return Util.Util.RaptorResultStringBuilder(result);
    }
}