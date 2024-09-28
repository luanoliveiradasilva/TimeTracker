using app.Adapters;
using app.Entities;
using app.Models;
using app.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace app.Controllers;

[ApiController]
[Route("[controller]/v1/")]
public class TimeTrackerController(
    ITimeTrackerService service,
    TimeBankAdapter adapter
    ): ControllerBase
{
    
    private readonly ITimeTrackerService _service = service;
    private readonly TimeBankAdapter _adapter = adapter;

    [HttpPost("timerbanks")]
    public ActionResult CreateTimebanck(TimeBankModels timeBank)
    {
        try
        {
            var times = _adapter.MapModelToEntity(timeBank);
            
            var postResult = _service.CreateTimeTracker(times);

            if (!postResult)
                return BadRequest();

            return Ok(timeBank);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
       
    }
}