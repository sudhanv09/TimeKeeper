using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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
    public SignInManager<Employee> _SignIn { get; set; }

    public UserController(IInfoService info, UserManager<Employee> user, SignInManager<Employee> signIn)
    {
        _info = info;
        _user = user;
        _SignIn = signIn;
    }

    [HttpPost("create-user")]
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
                return Ok(user);
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return BadRequest(result.Errors);
            }
        }
        return BadRequest("Input not valid");
    }
    
    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login(LoginDTO login)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();        
        }
        var userExists = await _user.FindByNameAsync(login.Username);
        if (userExists == null)
        {
            return BadRequest("Cant find user");
        }
        var result = await _SignIn.PasswordSignInAsync(login.Username, login.Password, true, false);
        return Ok(new {result.Succeeded, userExists.Id });
    }
    
    [HttpPost]
    [Route("logout")]
    public async Task<IActionResult> Logout()
    {
        await _SignIn.SignOutAsync();
        await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
        return Ok("User Logged Out");
    }
}