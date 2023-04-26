using Microsoft.AspNetCore.Mvc;
using TimeKeeper.Models;
using TimeKeeper.Models.DTO;
using TimeKeeper.Services;

namespace TimeKeeper.Controllers;
[ApiController]
[Route("/reserve")]
public class ReservationController : Controller
{
    private IReserveService _rs { get; set; }
    public ReservationController(IReserveService rs)
    {
        _rs = rs;
    }

    [HttpGet]
    public async Task<ActionResult<Reserve>> GetReservations()
    {
        var allGuests = await _rs.GetAllReservations();
        return Ok(allGuests);
    }
    
    [HttpGet("{id}")]
    public ActionResult<Reserve> GetReservationById(string id)
    {
        var getReservation = _rs.GetReservationById(id);
        return Ok(getReservation);
    }
    
    [HttpPost("new")]
    public async Task<ActionResult<Reserve>> NewReservation(ReserveDTO dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        await _rs.NewReservation(dto);
        return Ok("Created new reservation");
    }
     [HttpPatch("update")]
     public async Task<ActionResult<Reserve>> UpdateReservation(ReserveDTO dto)
     {
         if (!ModelState.IsValid)
         {
             return BadRequest();
         }
         await _rs.UpdateReservation(dto);
         return Ok("Reservation Updated");
    }
}