using Microsoft.AspNetCore.Identity;

namespace TimeKeeper.Models;

public class Employee : IdentityUser
{
    public List<DayOfWeek> Schedule { get; set; }
    public List<Timing> TimingInfo { get; set; }
    
}