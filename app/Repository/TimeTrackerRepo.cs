using app.Entities;
using app.Infrastructure;
using app.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace app.Repository;

public class TimeTrackerRepo(
    TimeTrackerContext context
    ): ITimeTrackerRepo
{

    public async Task<bool> AddTimeTracker(TimeBank timeBank)
    {
        var isSelect = context.TimeBanks.Any(t => t.TimeData == timeBank.TimeData);
        
        if (isSelect)
            return false;
        
        context.TimeBanks.Add(timeBank);
        await context.SaveChangesAsync();
        
        return true;
    }
    
    
    public IQueryable<TimeBank> GetTimeTracking(string date)
    { 
        var select = context.TimeBanks.Where(t => t.TimeData == date);
        
        if(!select.Any()) 
            return null!;
        
        return select;
    }
    
}