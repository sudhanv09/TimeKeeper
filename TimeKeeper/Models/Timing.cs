using Microsoft.AspNetCore.Identity;

namespace TimeKeeper.Models;

public class Timing
{
    public Employee Employee { get; set; }
    public string EmployeeId { get; set; }
    public Guid Id { get; set; }
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
    public bool IsWorking { get; set; }
    public int TodaysEarnings { get; set; }
    public double TodaysHours { get; set; }
    public int TotalSalary { get; set; }
    public double TotalHoursWorked { get; set; }
}