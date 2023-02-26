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
    TimeSpan CalculateHours(string id);
    void TotalHours(string id);
    void CalculateEverydayEarnings(string id);
    void TotalEarnings(string id);
    
    // Get Props
    List<DayOfWeek> GetSchedule(string id);
    int GetTotalSalary(string id);
    double GetTotalHoursWorked(string id);
    
    // Helper
    Task<bool> SaveChanges();
}