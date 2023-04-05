using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace TimeKeeper.Models;

public class Employee : IdentityUser
{
    public List<DayOfWeek> Schedule { get; set; }
    public List<Timing> TimingInfo { get; set; }
    
}