using app.Infrastructure;
using app.Models.Datas;
using app.Repository.Interfaces;

namespace app.Repository;

public class TimeTrackerRepoRepository(TimeTrackerContext context): ITimeTrackerRepo
{
    
    //private readonly TimeTrackerContext _context = context;

    public bool AddTimeTracker(TimeBank timeBank)
    {
        var select = context.TimeBanks.Any(t => t.TimeData == timeBank.TimeData);

        if (select)
            return false;
        
        context.TimeBanks.Add(timeBank);
        context.SaveChanges();
        
        return true;
    }
    
}