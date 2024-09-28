using app.Models.Datas;
using app.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace app.Controllers;

[ApiController]
[Route("[controller]/v1/")]
public class TimeTrackerController(ITimeTrackerService service): ControllerBase
{
    
    private readonly ITimeTrackerService _service = service;

    [HttpPost("timerbanks")]
    public ActionResult CreateTimebanck(TimeBank timeBank)
    {
        try
        {
            var postResult = _service.CreateTimeTracker(timeBank);

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