using TimeKeeper.Data;
using TimeKeeper.Models;
using TimeKeeper.Models.DTO;

namespace TimeKeeper.Services;

public interface IInfoService
{
    // Actions
    void CheckIn(CheckInDTO inDto);
    void CheckOut(CheckOutDTO outDto);
    
    // Calculations
    TimeSpan CalculateHours(string id, DateTime time);
    double TotalHours(string id, DateTime time);
    int CalculateEverydayEarnings(string id, DateTime time);
    int TotalEarnings(string id, DateTime time);
    
    // Get Props
    List<DayOfWeek> GetSchedule(string id);
    int GetTotalSalary(string id);
    double GetTotalHoursWorked(string id);
    
    // Helper
    Task<bool> SaveChanges();
}