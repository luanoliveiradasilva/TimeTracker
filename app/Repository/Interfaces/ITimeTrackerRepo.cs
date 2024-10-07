using app.Entities;
using app.Models;

namespace app.Repository.Interfaces;

public interface ITimeTrackerRepo
{
    Task<bool> AddTimeTracker(TimeBank timeBank);
    
    IQueryable<TimeBank> GetTimeTracking(string date);
}