using TimeKeeper.Data;
using TimeKeeper.Models;
using TimeKeeper.Models.DTO;

namespace TimeKeeper.Services;

public interface IInfoService
{
    // Actions
    void CheckIn(CheckInDTO inDto);
    void CheckOut(CheckOutDTO outDto);
    
    // // Calculations
    TimeSpan CalculateHours(string id);
    double TotalHours(string id);
    int CalculateEverydayEarnings(string id);
    int TotalEarnings(string id);
    
    // Get Props
    List<DayOfWeek> GetSchedule(string id);
    int GetTotalSalary(string id);
    double GetTotalHoursWorked(string id);
    
    // Helper
    Task<bool> SaveChanges();
}