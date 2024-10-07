using app.Entities;
using Microsoft.EntityFrameworkCore;

namespace app.Infrastructure;

public class TimeTrackerContext: DbContext
{
    
    public TimeTrackerContext(){}
    
    public TimeTrackerContext(DbContextOptions<TimeTrackerContext> options) : base(options) { }
    public virtual DbSet<TimeBank> TimeBanks { get; set; }
}