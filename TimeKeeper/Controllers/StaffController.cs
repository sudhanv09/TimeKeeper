using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TimeKeeper.Models;
using TimeKeeper.Models.DTO;
using TimeKeeper.Services;

namespace TimeKeeper.Controllers;
[ApiController]
[Route("/staff")]
// [Authorize]
public class StaffController : Controller
{
    private IInfoService _info { get; set; }
    public StaffController(IInfoService info)
    {
        _info = info;
    }

    [HttpPost("checkin")]
    public async Task<IResult> Checkin([FromBody]CheckInDTO dto)
    {
        if (!ModelState.IsValid) return Results.BadRequest();
        
        await _info.CheckIn(dto);
        return Results.Ok();
    }
    
    [HttpPost("checkout")]
    public async Task<IResult> Checkout([FromBody]CheckOutDTO dto)
    {
        if (!ModelState.IsValid) return Results.BadRequest();
        await _info.CheckOut(dto);
        return Results.Ok();
    }
    
    [HttpGet("schedule")]
    public async Task<IResult> GetSchedule(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            return Results.BadRequest();
        }

        var timings = _info.GetSchedule(id);
        return Results.Ok(timings);
    }
    
    [HttpGet("salary")]
    public async Task<IResult> GetSalary(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            return Results.BadRequest();
        }
        return Results.Ok(_info.GetTotalSalary(id));
    }
    
    [HttpGet("hours")]
    public async Task<IResult> GetHoursWorked(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            return Results.BadRequest();    
        }
        return Results.Ok(_info.GetTotalHoursWorked(id));
        
    }

    [HttpGet("{id}")]
    public async Task<IResult> GetStaffDetails(string id)
    {
        var user = await _info.GetEmployeeInfo(id);
        return Results.Ok(user);
    }
}
