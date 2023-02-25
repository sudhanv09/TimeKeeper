using Microsoft.AspNetCore.Identity;

namespace TimeKeeper.Models;

public class Timing : IdentityUser
{
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
    public bool isWorking { get; set; }
    public int TotalSalary { get; set; }
    public double HoursWorked { get; set; }
    public List<DayOfWeek> Schedule { get; set; }
}