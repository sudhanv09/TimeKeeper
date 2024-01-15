using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TimeKeeper.Models;
using TimeKeeper.Models.DTO;
using TimeKeeper.Services;

namespace TimeKeeper.Controllers;
[ApiController]
[Route("/reserve")]
[Authorize]
public class ReservationController : Controller
{
    private IReserveService _rs { get; set; }
    public ReservationController(IReserveService rs)
    {
        _rs = rs;
    }

    [HttpGet]
    public async Task<IResult> GetReservations()
    {
        var allGuests = await _rs.GetAllReservations();
        return Results.Ok(allGuests);
    }
    
    [HttpGet("{id}")]
    public IResult GetReservationById(string id)
    {
        bool isValid = Guid.TryParse(id, out Guid guid);
        if (!isValid) return Results.BadRequest("Bad Id");
        
        var getReservation = _rs.GetReservationById(guid);
        return getReservation is null ? Results.NotFound() : Results.Ok(getReservation);
    }
    
    [HttpPost("new")]
    public async Task<IResult> NewReservation([FromBody]ReserveDTO dto)
    {
        if (!ModelState.IsValid) return Results.BadRequest();
        
        await _rs.NewReservation(dto);
        return Results.Created();
    }
    
     [HttpPatch("update")]
     public async Task<IResult> UpdateReservation(ReserveDTO dto)
     {
         if (!ModelState.IsValid) return Results.BadRequest();
         
         await _rs.UpdateReservation(dto);
         return Results.Ok("Reservation Updated");
    }
     
     [HttpPost("delete")]
     public async Task<IResult> DeleteReservation(string Id)
     {
         bool isValid = Guid.TryParse(Id, out Guid guid);
         if (!isValid) return Results.BadRequest("Bad Id");
         
         await _rs.DeleteReservation(guid);
         return Results.Ok("Reservation Updated");
     }
}