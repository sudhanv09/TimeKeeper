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

    public void CheckIn(CheckInDTO inDto)
    {
        var working = _ctx.Timings.Where(x => x.EmployeeId == inDto.Id)
            .Select(x => new { status = x.IsWorking })
            .FirstOrDefault();

        // working is null if user not in Timings table
        if (working == null || working.status == false)
        {
            var item = new Timing()
            {
                EmployeeId = inDto.Id,
                CheckIn = inDto.CheckInTime,
                IsWorking = true
            };
            _ctx.Timings.Add(item);
        }
    }

    public void CheckOut(CheckOutDTO outDto)
    {
        var target = _ctx.Timings.Where(x => x.EmployeeId == outDto.Id)
            .OrderByDescending(x => x.IsWorking)
            .Select(x => x.Id)
            .FirstOrDefault();
        
        _ctx.Timings.Where(x => x.Id == target)
            .ExecuteUpdate(p =>
                p.SetProperty(x => x.CheckOut, outDto.CheckOutTime)
                    .SetProperty(x => x.IsWorking, false));
        // Update Checkout Time first
        _ctx.Timings.Where(x => x.Id == target)
            .ExecuteUpdate(p =>
                p.SetProperty(x => x.TodaysHours, CalculateHours(outDto.Id).TotalHours)
                    .SetProperty(x => x.TodaysEarnings, CalculateEverydayEarnings(outDto.Id))
                    .SetProperty(x => x.TotalHoursWorked, TotalHours(outDto.Id))
                    .SetProperty(x => x.TotalSalary, TotalEarnings(outDto.Id))
            );
    }

    /* Calculate everyday hours
     returns TimeSpan hours
     */
    public TimeSpan CalculateHours(string id)
    {
        var item = _ctx.Timings.Where(t => t.EmployeeId == id)
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
    public int CalculateEverydayEarnings(string id)
    {
        var hours = CalculateHours(id);
        var earnings = hours.TotalHours * 178;

        return (int)earnings;
    }

    /* Calculate overall hours worked
     returns double
     */
    public double TotalHours(string id)
    {
        var item = _ctx.Timings.Where(t => t.EmployeeId == id)
            .Select(x => x.TodaysHours)
            .Sum();

        return item + CalculateHours(id).TotalHours;
    }

    /* Calculate Overall Earnings
     returns double
     */
    public int TotalEarnings(string id)
    {
        var item = _ctx.Timings.Where(t => t.EmployeeId == id)
            .Select(x => x.TodaysEarnings)
            .Sum();

        return item + CalculateEverydayEarnings(id);
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