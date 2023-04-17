namespace TimeKeeper.Models.DTO;

public class LoginDTO
{
    public string Username { get; set; }
    public string Password { get; set; }
    public bool isPersistent { get; set; }
}