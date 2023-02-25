using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TimeKeeper.Models;
using TimeKeeper.Services;

namespace TimeKeeper.Controllers;

[ApiController]
[Route("/user")]
[ActivatorUtilitiesConstructor]
public class UserController : Controller
{
    private IInfoService _info { get; set; }
    private UserManager<Timing> _user { get; set; }

    public UserController(IInfoService info, UserManager<Timing> user)
    {
        _info = info;
        _user = user;
    }

    [HttpPost("/create-user")]
    public async Task<ActionResult<IdentityUser>> CreateUser(StaffDTO staff)
    {
        if (ModelState.IsValid)
        {
            var result = await _user.CreateAsync(new Timing()
            {
                UserName = staff.Username,
                NormalizedEmail = staff.Username.ToUpper(),
                Schedule = staff.Schedule
            });

            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
        }

        return BadRequest();
    }

    
}