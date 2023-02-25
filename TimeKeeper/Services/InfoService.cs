using Microsoft.EntityFrameworkCore;
using TimeKeeper.Data;
using TimeKeeper.Models;

namespace TimeKeeper.Services;

public class InfoService : IInfoService
{
    public AppDbContext _ctx { get; set; }

    public InfoService(AppDbContext ctx)
    {
        _ctx = ctx;
    }
    
    public void CheckIn(Timing timing)
    {
        var checkIn = new Timing();
        checkIn.CheckIn = DateTime.Now;
        checkIn.isWorking = true;
        _ctx.Timings.Add(checkIn);
    }

    public void CheckOut(Timing timing)
    {
        var checkOut = new Timing();
        checkOut.CheckOut = DateTime.Now;
        checkOut.isWorking = false;
        _ctx.Timings.Add(checkOut);
    }

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

    public double CalculateSalary(string id)
    {
        var hours = CalculateHours(id);
        return hours.TotalHours * 178;
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

    public int GetSalary(string id)
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
                hours = x.HoursWorked
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