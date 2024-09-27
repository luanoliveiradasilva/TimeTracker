using app.Models.Datas;

namespace app. Services. Interfaces;

public interface ITimeTrackerService
{
    bool CreateTimeTracker(TimeBank timeBank);
}