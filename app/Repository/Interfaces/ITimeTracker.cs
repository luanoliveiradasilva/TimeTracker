using app.Models.Datas;

namespace app.Repository.Interfaces;

public interface ITimeTracker
{
    bool AddTask(TimeBank timeBank);
}