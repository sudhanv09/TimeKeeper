using Microsoft.AspNetCore.Mvc;
using TimeKeeper.Models;
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

    // public async Task<ActionResult<Timing>> Checkin(Timing timing)
    // {
    //     throw NotImplementedException();
    // }

    [HttpGet("/schedule")]
    public async Task<ActionResult<Timing>> GetSchedule(string id)
    {
        if (id != null)
        {
            return Ok(_info.GetSchedule(id));
        }

        return BadRequest();
    }
    
}