using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TimeKeeper.Models;
using TimeKeeper.Models.DTO;
using TimeKeeper.Services;

namespace TimeKeeper.Controllers;
[ApiController]
[Route("/staff/")]
public class StaffController : Controller
{
    private IInfoService _info { get; set; }

    public StaffController(IInfoService info)
    {
        _info = info;
    }

    [HttpPost("/checkin")]
    public async Task<ActionResult<Timing>> Checkin(CheckInDTO dto)
    {
        if (ModelState.IsValid)
        {
            _info.CheckIn(dto);
            await _info.SaveChanges();
            return Ok();
        }
    
        return BadRequest();
    }
    
    [HttpPost("/checkout")]
    public async Task<ActionResult<Timing>> Checkout(CheckOutDTO dto)
    {
        if (ModelState.IsValid)
        {
            _info.CheckOut(dto);
            await _info.SaveChanges();
    
            return Ok();
        }
    
        return BadRequest();
    }
    
    [HttpGet("/schedule")]
    public async Task<ActionResult<Timing>> GetSchedule(string id)
    {
        if (id != null)
        {
            return Ok(_info.GetSchedule(id));
        }
    
        return BadRequest();
    }
    
    [HttpGet("/salary")]
    public async Task<ActionResult<Timing>> GetSalary(string id)
    {
        if (id != null)
        {
            return Ok(_info.GetTotalSalary(id));
        }
    
        return BadRequest();
    }
    
    [HttpGet("/hours")]
    public async Task<ActionResult<Timing>> GetHoursWorked(string id)
    {
        if (id != null)
        {
            return Ok(_info.GetTotalHoursWorked(id));
        }
    
        return BadRequest();
    }
    
}