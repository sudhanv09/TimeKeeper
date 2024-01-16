using TimeKeeper.Models;
using TimeKeeper.Models.DTO;

namespace TimeKeeper.Tests;

public class StaffTest : BaseTest
{
    public StaffTest(TimeKeeperFactory factory) : base(factory)
    {
        var user = new Employee()
        {
            Id = "0cd94927-c075-43c7-834f-6fa854e94d32"
        };

        _dbContext.Employees.Add(user);
        _dbContext.SaveChanges();   
    }

    [Fact]
    public async Task Staff_ShouldCheckin()
    {
        // arrange
        var checkin = new CheckInDTO()
        {
            Id = "0cd94927-c075-43c7-834f-6fa854e94d32",
            CheckInTime = DateTime.UtcNow
        };

        //act
        var action = await _info.CheckIn(checkin);

        //assert
        var checkActive = _dbContext.Timings.FirstOrDefault(i => i.EmployeeId == checkin.Id);
        Assert.True(action);
        Assert.NotNull(checkActive);
        Assert.True(checkActive.IsWorking);
    }
    
    [Fact]
    public async Task Staff_CheckinShouldThrowError()
    {
        // arrange
        var user = new Timing()
        {
            EmployeeId = "0cd94927-c075-43c7-834f-6fa854e94d32",
            IsWorking = true
        };

        _dbContext.Timings.Add(user);
        await _dbContext.SaveChangesAsync();
        
        //act
        var checkin = new CheckInDTO()
        {
            Id = "0cd94927-c075-43c7-834f-6fa854e94d32",
            CheckInTime = DateTime.UtcNow
        };
        
        // act
        await Assert.ThrowsAsync<InvalidOperationException>(async () => await _info.CheckIn(checkin));
    }
    
    [Fact]
    public async Task Staff_CheckOutShouldThrowErrorEmployeeNotCheckedIn()
    {
        
        //act
        var checkout = new CheckOutDTO()
        {
            Id = "0cd94927-c075-43c7-834f-6fa854e94d32",
            CheckOutTime = DateTime.UtcNow
        };
        
        //assert
        await Assert.ThrowsAsync<ArgumentException>(async () => await _info.CheckOut(checkout));
    }
    
    [Fact]
    public async Task Staff_ShouldCheckout()
    {
        //arrange
        var checkin = new CheckInDTO()
        {
            Id = "0cd94927-c075-43c7-834f-6fa854e94d32",
            CheckInTime = DateTime.UtcNow
        };
        await _info.CheckIn(checkin);
        
        //act
        var checkout = new CheckOutDTO()
        {
            Id = "0cd94927-c075-43c7-834f-6fa854e94d32",
            CheckOutTime = DateTime.UtcNow.AddHours(2)
        };

        await _info.CheckOut(checkout);
        
        //assert
        var checkActive = _dbContext.Timings.FirstOrDefault(i => i.EmployeeId == checkin.Id);
        Assert.NotNull(checkActive);
        Assert.False(checkActive.IsWorking);
        Assert.Equal(2, Math.Round(checkActive.TodaysHours));
    }
}