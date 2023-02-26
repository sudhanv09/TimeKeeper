namespace TimeKeeper.Models.DTO;

public class StaffDTO
{
    public string Username { get; set; }
    public List<DayOfWeek> Schedule { get; set; }
}