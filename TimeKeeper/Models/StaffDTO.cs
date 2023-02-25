namespace TimeKeeper.Models;

public class StaffDTO
{
    public string Username { get; set; }
    public List<DayOfWeek> Schedule { get; set; }
}