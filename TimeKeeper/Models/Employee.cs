using Microsoft.AspNetCore.Identity;

namespace TimeKeeper.Models;

public class Employee : IdentityUser
{
    public List<Timing> TimingInfo { get; set; }
}