namespace TimeKeeper.Models;

public class Reserve
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public DateTime Booking { get; set; }
    public string PhoneNumber { get; set; }
    public bool ReturnCustomer { get; set; }
}