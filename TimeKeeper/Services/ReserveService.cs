using TimeKeeper.Data;
using TimeKeeper.Models;
using TimeKeeper.Models.DTO;

namespace TimeKeeper.Services;

public class ReserveService : IReserveService
{
    public AppDbContext _ctx { get; set; }

    public ReserveService(AppDbContext ctx)
    {
        _ctx = ctx;
    }
    public List<Reserve> GetAllReservations()
    {
        var allGuests = _ctx.Reservation.Where(t => t.Booking == DateTime.Today).ToList();
        return allGuests;
    }

    public Reserve ReservationById(string id)
    {
        var guest = _ctx.Reservation.SingleOrDefault(i => i.Id.Equals(id));
        return guest;
    }

    public bool CheckReturnCustomer(string id)
    {
        var guest = ReservationById(id);
        if (guest == null) return false;
        var count = _ctx.Reservation.Where(p => p.PhoneNumber == guest.PhoneNumber).ToList().Count();
        if (count > 1)
        {
            return true;
        }
        return false;
    }

    public void NewReservation(ReserveDTO dto)
    {
        var returnGuest = CheckReturnCustomer(dto.Id);
        var newGuest = new Reserve()
        {
            Name = dto.Name,
            Booking = dto.BookingDate,
            PhoneNumber = dto.PhoneNumber,
            ReturnCustomer = returnGuest
        };
        _ctx.Reservation.Add(newGuest);
        _ctx.SaveChangesAsync();
    }

    public void UpdateReservation(ReserveDTO dto)
    {
        var guest = ReservationById(dto.Id);
        if (guest == null) throw new Exception();
        
        // No one updates Name and phone number, only datetime
        guest.Booking = dto.BookingDate;
        _ctx.SaveChangesAsync();
    }
    
}