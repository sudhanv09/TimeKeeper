using TimeKeeper.Data;
using TimeKeeper.Models;
using TimeKeeper.Models.DTO;

namespace TimeKeeper.Services;

public class InfoService : IInfoService
{
    private AppDbContext _ctx { get; set; }

    public InfoService(AppDbContext ctx)
    {
        _ctx = ctx;
    }
    
    public void CheckIn(CheckInDTO inDto)
    {
        var checkIn = new Timing
        {
            CheckIn = inDto.CheckInTime,
            IsWorking = true
        };
        _ctx.Timings.Add(checkIn);
        SaveChanges();
    }

    public void CheckOut(CheckOutDTO outDto)
    {
        var checkOut = new Timing
        {
            CheckOut = outDto.CheckOutTime,
            IsWorking = false
        };
        _ctx.Timings.Add(checkOut);
        SaveChanges();
    }

    /* Calculate everyday hours
     Add TodaysHours to DB
     returns TimeSpan hours
     */
    
    public TimeSpan CalculateHours(string id)
    {
        var item = _ctx.Timings.Where(t => t.Id == id)
            .Select(x => new
            {
                checkintime = x.CheckIn,
                checkouttime = x.CheckOut
            })
            .FirstOrDefault();
        var hours = item.checkouttime - item.checkintime;
        _ctx.Timings.Add(new Timing() { TodaysHours = hours.TotalHours });
        return hours;
    }

    /* Calculate overall hours worked
     Add TotalHoursWorked to DB
     */
    public void TotalHours(string id)
    {
        var item = _ctx.Timings.Where(t => t.Id == id)
            .Sum(x => x.TodaysHours);

        _ctx.Timings.Add(new Timing() { TotalHoursWorked = item });
    }

    /* Calculates everyday earnings
     Add TotalSalary to DB
     */
    public void CalculateEverydayEarnings(string id)
    {
        var hours = CalculateHours(id);
        var earnings = hours.TotalHours * 178;

        _ctx.Timings.Add(new Timing() { TodaysEarnings = (int)earnings });
    }
    
    /* Calculate Overall Earnings
     Add TotalSalary to DB
     */
    public void TotalEarnings(string id)
    {
        var item = _ctx.Timings.Where(t => t.Id == id)
            .Sum(x => x.TodaysEarnings);

        _ctx.Timings.Add(new Timing() { TotalSalary = item });
    }

    public List<DayOfWeek> GetSchedule(string id)
    {
        
        var item = _ctx.Timings.Where(t => t.Id == id)
            .Select(x => new
            {
                schedule = x.Schedule
            })
            .FirstOrDefault();
        return item.schedule;
    }
    
    public int GetTotalSalary(string id)
    {
        var item = _ctx.Timings.Where(t => t.Id == id)
            .Select(x => new
            {
                salary = x.TotalSalary
            })
            .FirstOrDefault();
        return item.salary;
    }

    public double GetTotalHoursWorked(string id)
    {
        var item = _ctx.Timings.Where(t => t.Id == id)
            .Select(x => new
            {
                hours = x.TotalHoursWorked
            })
            .FirstOrDefault();
        return item.hours;
    }
    
    public async Task<bool> SaveChanges()
    {
        if (await _ctx.SaveChangesAsync() > 0)
            return true;
        else
        {
            return false;
        }
    }
}