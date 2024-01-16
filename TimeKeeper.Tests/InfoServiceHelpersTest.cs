using TimeKeeper.Models;

namespace TimeKeeper.Tests;

public class InfoServiceHelpersTest : BaseTest
{
    public InfoServiceHelpersTest(TimeKeeperFactory factory) : base(factory)
    {
        var timings = new Timing()
        {
            EmployeeId = "0cd94927-c075-43c7-834f-6fa854e94d32",
            CheckIn = DateTime.UtcNow,
            IsWorking = true,
        };

        _dbContext.Timings.Add(timings);
        _dbContext.SaveChanges();  
    }

    public static IEnumerable<object[]> HourData => new List<object[]>
    {
        new object[]{DateTime.UtcNow.AddHours(2), 2},
        new object[]{DateTime.UtcNow.AddHours(6), 6},
    };

    [Theory, MemberData(nameof(HourData))]
    public void CalculateTime_Returns(DateTime checkout, int expected)
    {
        var id = "0cd94927-c075-43c7-834f-6fa854e94d32";
        var calcTime = _info.CalculateHours(id, checkout);
    
        Assert.Equal(expected, Math.Round(calcTime.TotalHours));
    }
    
    public static IEnumerable<object[]> EarningData => new List<object[]>
    {
        new object[]{DateTime.UtcNow.AddHours(2), 178*2},
        new object[]{DateTime.UtcNow, 0},
        new object[]{DateTime.UtcNow.AddHours(6), 178*6},
    };

    [Theory, MemberData(nameof(EarningData))]
    public void CalculateEverydayEarnings_Returns(DateTime checkout, int expected)
    {
        var id = "0cd94927-c075-43c7-834f-6fa854e94d32";
        var calcEarnings = _info.CalculateEverydayEarnings(id, checkout);
    
        Assert.Equal(expected, calcEarnings);
    }
    
    public static IEnumerable<object[]> TotalEarningData => new List<object[]>
    {
        new object[]{DateTime.UtcNow.AddHours(2), 500+178*2},
    };

    [Theory, MemberData(nameof(TotalEarningData))]
    public void CalculateTotalEarnings_Returns(DateTime checkout, int expected)
    {
        var id = "0cd94927-c075-43c7-834f-6fa854e94d32";
        
        var seed = new Timing()
        {
            EmployeeId = id,
            TodaysEarnings = 500
        };
        _dbContext.Timings.Add(seed);
        _dbContext.SaveChangesAsync();
        
        var calcEarnings = _info.TotalEarnings(id, checkout);
    
        Assert.Equal(expected, calcEarnings);
    }
    
    public static IEnumerable<object[]> TotalHoursData => new List<object[]>
    {
        new object[]{DateTime.UtcNow.AddHours(2), 4+2},
        new object[]{DateTime.UtcNow.AddHours(6), 4+6},
    };

    [Theory, MemberData(nameof(TotalHoursData))]
    public void CalculateTotalHours_Returns(DateTime checkout, int expected)
    {
        var id = "0cd94927-c075-43c7-834f-6fa854e94d32";
        
        var seed = new Timing()
        {
            EmployeeId = id,
            TodaysHours = 4
        };
        _dbContext.Timings.Add(seed);
        _dbContext.SaveChangesAsync();
        
        var calcEarnings = _info.TotalHours(id, checkout);
    
        Assert.Equal(expected, Math.Round(calcEarnings));
    }
}