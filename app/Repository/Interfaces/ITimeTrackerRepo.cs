using app.Entities;
using app.Models;

namespace app.Repository.Interfaces;

public interface ITimeTrackerRepo
{
    Task<bool> AddTimeTracker(TimeBank timeBank);
    
    Task<TimeBank>  GetTimeTracking(string date);
}