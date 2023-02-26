namespace TimeKeeper.Models.DTO;

public class CheckInDTO
{
    public string Id { get; set; }
    public DateTime CheckInTime { get; set; } = DateTime.UtcNow;
}