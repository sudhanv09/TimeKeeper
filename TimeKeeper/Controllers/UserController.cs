using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TimeKeeper.Models;
using TimeKeeper.Models.DTO;
using TimeKeeper.Services;

namespace TimeKeeper.Controllers;

[ApiController]
[Route("/user")]
[ActivatorUtilitiesConstructor]
public class UserController : Controller
{
    private IInfoService _info { get; set; }
    private UserManager<Employee> _user { get; set; }

    public UserController(IInfoService info, UserManager<Employee> user)
    {
        _info = info;
        _user = user;
    }

    [HttpPost("/create-user")]
    public async Task<ActionResult<IdentityUser>> CreateUser(StaffDTO staff)
    {
        if (ModelState.IsValid)
        {
            var user = new Employee()
            {
                UserName = staff.Username,
                NormalizedUserName = staff.Username.ToUpper(),
                Email = staff.Email,
                Schedule = staff.Schedule
            };
            var result = await _user.CreateAsync(user, staff.Password);

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