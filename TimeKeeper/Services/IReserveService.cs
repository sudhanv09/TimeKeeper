using TimeKeeper.Models;
using TimeKeeper.Models.DTO;

namespace TimeKeeper.Services;

public interface IReserveService
{
    List<Reserve> GetAllReservations();
    Reserve ReservationById(string id);
    bool CheckReturnCustomer(string id);
    void NewReservation(ReserveDTO reserveDto);
    void UpdateReservation(ReserveDTO reserveDto);
}