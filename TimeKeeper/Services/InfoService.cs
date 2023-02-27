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
            IsWorking = true,
        };
        _ctx.Timings.Add(checkIn);
    }

    public void CheckOut(CheckOutDTO outDto)
    {
        
        /* Select Id
         Insert CheckOut time
         Insert Calculations
         Save to DB
         */

        var checkOut = new Timing
        {
            CheckOut = outDto.CheckOutTime,
            IsWorking = false
        };
        _ctx.Timings.Add(checkOut);
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
        return item.checkouttime - item.checkintime;
    }
    
    /* Calculates everyday earnings
     returns double
     */
    public double CalculateEverydayEarnings(string id)
    {
        var hours = CalculateHours(id);
        var earnings = hours.TotalHours * 178;

        return earnings;
    }
    
    /* Calculate overall hours worked
     returns double
     */
    public double TotalHours(string id)
    {
        var item = _ctx.Timings.Where(t => t.Id == id)
            .Sum(x => x.TodaysHours);

        return item;
    }
    
    /* Calculate Overall Earnings
     returns double
     */
    public int TotalEarnings(string id)
    {
        var item = _ctx.Timings.Where(t => t.Id == id)
            .Sum(x => x.TodaysEarnings);

        return item;
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