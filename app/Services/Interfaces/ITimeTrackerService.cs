using app.Entities;

namespace app. Services. Interfaces;

public interface ITimeTrackerService
{
    bool CreateTimeTracker(TimeBank timeBank);
}