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
public class UserController : Controller
{
    private IInfoService _info { get; set; }
    private UserManager<Employee> _user { get; set; }
    private SignInManager<Employee> _signIn { get; set; }

    public UserController(IInfoService info, UserManager<Employee> user, SignInManager<Employee> signIn)
    {
        _info = info;
        _user = user;
        _signIn = signIn;
    }

    [HttpPost("register")]
    public async Task<IResult> CreateUser([FromBody] StaffDTO staff)
    {
        if (!ModelState.IsValid) return Results.BadRequest("Input not valid");
        var user = new Employee()
        {
            UserName = staff.Username,
            NormalizedUserName = staff.Username.ToUpper(),
            Email = staff.Email,
            Schedule = staff.Schedule
        };
        
        var result = await _user.CreateAsync(user, staff.Password);
        if (!result.Succeeded)
        {
            foreach (var err in result.Errors)
            {
                return Results.BadRequest(err.Description);
            }
        }
        return Results.Created();
        
    }
    
    [HttpPost]
    [Route("login")]
    public async Task<IResult> Login(LoginDTO login)
    {
        if (!ModelState.IsValid) return Results.BadRequest();        
        
        var userExists = await _user.FindByNameAsync(login.Username);
        if (userExists == null)
        {
            return Results.NotFound("Cant find user");
        }
        var result = await _signIn.PasswordSignInAsync(login.Username, login.Password, true, false);
        if (!result.Succeeded) return Results.Unauthorized();
        
        return Results.Ok();
    }
    
    [HttpPost]
    [Route("logout")]
    public async Task<IResult> Logout()
    {
        await _signIn.SignOutAsync();
        return Results.SignOut();
    }
}