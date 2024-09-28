using app.Entities;

namespace app.Tests.Test.Mocks;

internal class MockTimebank
{
    public static TimeBank TimeBanks()
    {
        DateTimeOffset dateTimeOffset = DateTimeOffset.Now;
        TimeBank timeBanks = new()
        { 
            TimebankId = 1, 
            TimeData  = dateTimeOffset.ToString("d"), 
            StartTime = dateTimeOffset.ToString("t"), 
            BreakTime = dateTimeOffset.ToString("t"), 
            Clockin = dateTimeOffset.ToString("t"), 
            Clockout = dateTimeOffset.ToString("t")
        };
      

        return timeBanks;
    }
}