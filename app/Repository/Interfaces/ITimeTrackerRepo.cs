using app.Models.Datas;

namespace app.Repository.Interfaces;

public interface ITimeTrackerRepo
{
    bool AddTimeTracker(TimeBank timeBank);
}