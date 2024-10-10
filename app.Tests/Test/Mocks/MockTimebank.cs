using app.Entities;
using app.Models;

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
            Clockout = dateTimeOffset.ToString("t"),
            Description = "Teste do texto"
        };
        
        return timeBanks;
    }
    
    public static TimeBankModel TimeBankInput()
    {
        DateTimeOffset dateTimeOffset = DateTimeOffset.Now;
        TimeBankModel timeBanks = new()
        { 
            TimeData  = dateTimeOffset.ToString("d"), 
            StartTime = dateTimeOffset.ToString("t"), 
            BreakTime = dateTimeOffset.ToString("t"), 
            Clockin = dateTimeOffset.ToString("t"), 
            Clockout = dateTimeOffset.ToString("t"),
            Description = "Teste do texto"
        };
        
        return timeBanks;
    }
}