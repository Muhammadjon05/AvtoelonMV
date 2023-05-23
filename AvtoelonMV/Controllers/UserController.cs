using System.Security.Claims;
using AvtoElonData.Dtos;
using AvtoelonData.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AvtoelonMV.Controllers;

public class UserController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    public UserController(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }
    [Authorize]
    public async Task<IActionResult> Profile()
    {
        var user = await _userManager.GetUserAsync(User);
        return View(user);
    }  
    [HttpGet]
    public IActionResult SignUp()
    {
        if (User.Identity.IsAuthenticated)
        {
            return RedirectToAction("Index", "Home"); // Redirect to another page
        }
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SignUp(SignUpDTO dto)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }
        var user = new User()
        {
            FirstName = dto.FirstName,
            UserName = dto.UserName,
            Email = dto.Email,
            PhoneNumber = dto.PhoneNumber
        };
        var result = await _userManager.CreateAsync(user, dto.Password);
        if (!result.Succeeded)
        {
            ModelState.AddModelError("Username",result.Errors.First().Description);
            return View();
        }
        await _signInManager.SignInAsync(user, isPersistent: true);
        return RedirectToAction("Index","Main");
    }
    [HttpGet]
    public IActionResult SignIn()
    { 
        if (User.Identity.IsAuthenticated)
        {
            return RedirectToAction("Index", "Home"); // Redirect to another page
        }
        return View();
    }

    [HttpPost]

    public async Task<IActionResult> SignIn([FromForm]SignInDTO dto)
    {
        var result = await _signInManager.PasswordSignInAsync(dto.UserName, dto.Password, isPersistent: true, false);
        if (!result.Succeeded)
        {
            ModelState.AddModelError("Username","Username or password is incorrect");
            return View();
        }
        return RedirectToAction("Profile");
    }

    public async Task<IActionResult> LogOut()
    {
      await _signInManager.SignOutAsync();
      return RedirectToAction("SignIn");
    }
}