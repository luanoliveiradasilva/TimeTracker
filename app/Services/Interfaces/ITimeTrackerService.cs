using app.Models;

namespace app. Services. Interfaces;

public interface ITimeTrackerService
{
    Task<bool> CreateTimeTracker(TimeBankModel timeBankModel);
    Task<TimeBankModel> GetTimeTrackersByDate(string date);

}