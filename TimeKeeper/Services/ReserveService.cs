using Microsoft.EntityFrameworkCore;
using TimeKeeper.Data;
using TimeKeeper.Models;
using TimeKeeper.Models.DTO;

namespace TimeKeeper.Services;

public class ReserveService(AppDbContext ctx) : IReserveService
{
    private AppDbContext _ctx { get; set; } = ctx;

    public async Task<List<Reserve>> GetAllReservations()
    {
        var allGuests = await _ctx.Reservation.ToListAsync();
        return allGuests;
    }

    public Reserve GetReservationById(Guid id)
    {
        var reservation = _ctx.Reservation.FirstOrDefault(r => r.Id == id);
        return reservation;
    }
    
    public bool CheckReturnCustomer(string phoneNumber)
    {
        return _ctx.Reservation.Any(p => p.PhoneNumber.Equals(phoneNumber));
    }

    public async Task<Guid> NewReservation(ReserveDTO dto)
    {
        var newGuest = new Reserve()
        {
            Name = dto.Name,
            Booking = dto.BookingDate,
            PhoneNumber = dto.PhoneNumber,
            ReturnCustomer = CheckReturnCustomer(dto.PhoneNumber),
        };
        _ctx.Reservation.Add(newGuest);
        await _ctx.SaveChangesAsync();

        return newGuest.Id;
    }

    public async Task UpdateReservation(ReserveDTO dto)
    {
        var isValid = Guid.TryParse(dto.Id, out Guid guid);
        var guest = GetReservationById(guid);
        if (guest == null) throw new Exception("Guest not found");
        
        // No one updates Name and phone number, only datetime
        guest.Booking = dto.BookingDate;
        await _ctx.SaveChangesAsync();
    }

    public async Task DeleteReservation(Guid id)
    {
        var reserve = GetReservationById(id);

        _ctx.Remove(reserve);
        await _ctx.SaveChangesAsync();
    }
}