using TimeKeeper.Data;
using TimeKeeper.Models;

namespace TimeKeeper.Services;

public interface IInfoService
{
    void CheckIn(Timing timing);
    void CheckOut(Timing timing);
    TimeSpan CalculateHours(string id);
    double CalculateSalary(string id);
    List<DayOfWeek> GetSchedule(string id);
    int GetSalary(string id);
    double GetTotalHoursWorked(string id);
    Task<bool> SaveChanges();
}