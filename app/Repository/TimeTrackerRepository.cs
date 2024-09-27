using app.Infrastructure;
using app.Models.Datas;
using app.Repository.Interfaces;

namespace app.Repository;

public class TimeTrackerRepository(TimeTrackerContext context): ITimeTracker
{
    
    private readonly TimeTrackerContext _context = context;

    public bool AddTask(TimeBank timeBank)
    {
        var select = _context.TimeBanks.Any(t => t.TimeData == timeBank.TimeData);

        if (select)
            return false;
        
        _context.TimeBanks.Add(timeBank);
        _context.SaveChanges();
        
        return true;
    }
    
}