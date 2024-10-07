using app.Adapters;
using app.Adapters.Interfaces;
using app.Entities;
using app.Models;
using app.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace app.Controllers;

[ApiController]
[Route("[controller]/v1/")]
public class TimeTrackerController(
    ITimeTrackerService service
    ): ControllerBase
{
    
    private readonly ITimeTrackerService _service = service;

    [HttpPost("timerbanks")]
    public async Task<ActionResult> CreateTimebanck(TimeBankModel timeBankModel)
    {
        try
        {
            var postResult = await _service.CreateTimeTracker(timeBankModel);

            if (!postResult)
                return BadRequest("Time already registered");

            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
       
    }
}