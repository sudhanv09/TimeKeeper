using Microsoft.EntityFrameworkCore;
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
    public async Task<List<Reserve>> GetAllReservations()
    {
        var allGuests = await _ctx.Reservation.ToListAsync();
        return allGuests;
    }

    public Reserve GetReservationById(string id)
    {
        Reserve reservation = null;
        if (Guid.TryParse(id, out Guid reservationId))
        {
            try
            {
                reservation = _ctx.Reservation.FirstOrDefault(r => r.Id == reservationId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting reservation with id {id}: {ex.Message}");
            }
        }
        return reservation;
    }
    
    public bool CheckReturnCustomer(string phoneNumber)
    {
        return _ctx.Reservation.Any(p => p.PhoneNumber.Equals(phoneNumber));
    }

    public async Task NewReservation(ReserveDTO dto)
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
    }

    public async Task UpdateReservation(ReserveDTO dto)
    {
        var guest = GetReservationById(dto.Id);
        if (guest == null) throw new Exception("Guest not found");
        
        // No one updates Name and phone number, only datetime
        guest.Booking = dto.BookingDate;
        await _ctx.SaveChangesAsync();
    }
}