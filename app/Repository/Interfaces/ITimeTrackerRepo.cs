using app.Entities;

namespace app.Repository.Interfaces;

public interface ITimeTrackerRepo
{
    bool AddTimeTracker(TimeBank timeBank);
}