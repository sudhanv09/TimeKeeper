using Microsoft.AspNetCore.Http;
using TimeKeeper.Models;
using TimeKeeper.Models.DTO;

namespace TimeKeeper.Tests;

public class ReservationTest(TimeKeeperFactory factory) : BaseTest(factory)
{
    [Fact]
    public async Task NewReservation_Success()
    {
        // Arrange
        var newRes = new ReserveDTO()
        {
            Name = "zeus",
            PhoneNumber = "0123456789",
            BookingDate = DateTime.UtcNow
        };
        // Act
        var reserveId = await _reserve.NewReservation(newRes);
        
        //Assert
        var query = _dbContext.Reservation.FirstOrDefault(i => i.Id == reserveId);
        Assert.NotNull(query);
    }
    
    [Fact]
    public async Task NewReservation_ReturnsBadRequest()
    {
        
    }
}