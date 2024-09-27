using app.Models.Datas;
using app.Repository.Interfaces;
using app.Services.Interfaces;

namespace app.Services;

public class TimeTrackerService(ITimeTrackerRepo repo): ITimeTrackerService
{
    //private readonly ITimeTrackerRepo _repo = repo;
    
    public bool CreateTimeTracker(TimeBank timeBank)
    {
       var addTime =  repo.AddTimeTracker(timeBank);

       if (!addTime)
           return false;
       
       return true;
    }
}