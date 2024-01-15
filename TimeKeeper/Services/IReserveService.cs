using TimeKeeper.Models;
using TimeKeeper.Models.DTO;

namespace TimeKeeper.Services;

public interface IReserveService
{
    Task<List<Reserve>> GetAllReservations();
    Reserve GetReservationById(Guid id);
    bool CheckReturnCustomer(string phoneNumber);
    Task NewReservation(ReserveDTO reserveDto);
    Task UpdateReservation(ReserveDTO reserveDto);
    Task DeleteReservation(Guid id);
}