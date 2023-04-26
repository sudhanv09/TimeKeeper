using Microsoft.AspNetCore.Mvc;
using TimeKeeper.Models;
using TimeKeeper.Models.DTO;
using TimeKeeper.Services;

namespace TimeKeeper.Controllers;
[ApiController]
[Route("/staff")]
public class StaffController : Controller
{
    private IInfoService _info { get; set; }
    public StaffController(IInfoService info)
    {
        _info = info;
    }

    [HttpPost("checkin")]
    public async Task<ActionResult<Timing>> Checkin(CheckInDTO dto)
    {
        if (ModelState.IsValid)
        {
            await _info.CheckIn(dto);
            return Ok();
        }
        return BadRequest();
    }
    
    [HttpPost("checkout")]
    public async Task<ActionResult<Timing>> Checkout(CheckOutDTO dto)
    {
        if (ModelState.IsValid)
        {
            await _info.CheckOut(dto);
            return Ok();
        }
        return BadRequest();
    }
    
    [HttpGet("schedule")]
    public async Task<ActionResult<Timing>> GetSchedule(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            return Ok(_info.GetSchedule(id));
        }
        return BadRequest();
    }
    
    [HttpGet("salary")]
    public async Task<ActionResult<Timing>> GetSalary(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            return Ok(_info.GetTotalSalary(id));
        }
        return BadRequest();
    }
    
    [HttpGet("hours")]
    public async Task<ActionResult<Timing>> GetHoursWorked(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            return Ok(_info.GetTotalHoursWorked(id));
        }
        return BadRequest();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Timing>> GetStaffDetails(string id)
    {
        var user = await _info.GetEmployeeInfo(id);
        return Ok(user);
    }
    
    [HttpGet("active")]
    public async Task<ActionResult<Timing>> GetNoActive()
    {
        var active = _info.GetNumActive();
        return Ok(active);
    }
}
