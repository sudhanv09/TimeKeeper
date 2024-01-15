using Microsoft.EntityFrameworkCore;
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

    public async Task CheckIn(CheckInDTO inDto)
    {
        var working = _ctx.Timings.FirstOrDefault(x => x.EmployeeId == inDto.Id);

        // working is null if user not in Timings but in user table
        if (working == null || !working.IsWorking)
        {
            var item = new Timing()
            {
                EmployeeId = inDto.Id,
                CheckIn = inDto.CheckInTime,
                IsWorking = true
            };
            _ctx.Timings.Add(item);
            await _ctx.SaveChangesAsync();
        }
        else
        {
            throw new InvalidOperationException("Employee already checked in");
        }
    }

    public async Task CheckOut(CheckOutDTO outDto)
    {
        var mostRecentTiming = _ctx.Timings
            .Where(t => t.EmployeeId == outDto.Id && t.IsWorking)
            .OrderByDescending(t => t.CheckIn)
            .FirstOrDefault();

        if (mostRecentTiming == null)
        {
            throw new ArgumentException("Employee has no active timing entries");
        }
        // Update all fields
        mostRecentTiming.CheckOut = outDto.CheckOutTime;
        mostRecentTiming.IsWorking = false;
        mostRecentTiming.TodaysHours = CalculateHours(outDto.Id, outDto.CheckOutTime).TotalHours;
        mostRecentTiming.TodaysEarnings = CalculateEverydayEarnings(outDto.Id, outDto.CheckOutTime);
        mostRecentTiming.TotalHoursWorked = TotalHours(outDto.Id, outDto.CheckOutTime);
        mostRecentTiming.TotalSalary = TotalEarnings(outDto.Id, outDto.CheckOutTime);
        await _ctx.SaveChangesAsync();
    }

    /* Calculate time difference between check-in and out time
     returns TimeSpan hours
     */
    public TimeSpan CalculateHours(string id, DateTime time)
    {
        /* Get item by Id and order by descending.
         Since _ctx.SaveChangesAsync has not been reached yet, isWorking is still true
         use that to find and update the field.
         */
        var item = _ctx.Timings.Where(t => t.EmployeeId == id)
            .OrderByDescending(o=>o.IsWorking)
            .Select(x => new
            {
                checkintime = x.CheckIn,
            })
            .FirstOrDefault();
        return time - item.checkintime;
    }

    /* Calculate earnings
     returns double
     */
    public int CalculateEverydayEarnings(string id, DateTime time)
    {
        var hours = CalculateHours(id, time);
        var earnings = hours.TotalHours * 178;

        return (int)earnings;
    }

    /* Calculate overall hours worked
     returns double
     */
    public double TotalHours(string id, DateTime time)
    {
        var item = _ctx.Timings.Where(t => t.EmployeeId == id)
            .Select(x => x.TodaysHours)
            .Sum();

        return item + CalculateHours(id, time).TotalHours;
    }

    /* Calculate Overall Earnings
     returns double
     */
    public int TotalEarnings(string id, DateTime time)
    {
        var item = _ctx.Timings.Where(t => t.EmployeeId == id)
            .Select(x => x.TodaysEarnings)
            .Sum();

        return item + CalculateEverydayEarnings(id, time);
    }

    public List<DayOfWeek> GetSchedule(string id)
    {
        var item = _ctx.Employees.Where(t => t.Id == id)
            .Select(x => new
            {
                schedule = x.Schedule
            })
            .FirstOrDefault();
        return item.schedule;
    }

    public int GetTotalSalary(string id)
    {
        var item = _ctx.Timings.Where(t => t.EmployeeId == id)
            .OrderByDescending(x=>x.TotalSalary)
            .Select(x => new
            {
                salary = x.TotalSalary
            })
            .FirstOrDefault();
        return item.salary;
    }

    public double GetTotalHoursWorked(string id)
    {
        var item = _ctx.Timings.Where(t => t.EmployeeId == id)
            .OrderByDescending(x=>x.TotalHoursWorked)
            .Select(x => new
            {
                hours = x.TotalHoursWorked
            })
            .FirstOrDefault();
        return item.hours;
    }

    public async Task<List<Timing>> GetEmployeeInfo(string id)
    {
        var user = await _ctx.Timings.Where(i => i.EmployeeId == id).ToListAsync();
        return user;
    }
}
