using System.Security.Claims;
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
                return Ok(result);
            }
            else
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
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
            return BadRequest();
        }

        var passCheck = _user.PasswordHasher.VerifyHashedPassword(userExists, userExists.PasswordHash, login.Password);
        if (passCheck == PasswordVerificationResult.Failed)
        {
            return BadRequest();
        }
        var result = await _SignIn.PasswordSignInAsync(login.Username, login.Password, true, false);
        return Ok(result.Succeeded);
    }
    
    
    [HttpPost]
    [Route("logout")]
    public async Task<IActionResult> Logout()
    {
        await _SignIn.SignOutAsync();
        return Ok("User Logged Out");
    }

    
}