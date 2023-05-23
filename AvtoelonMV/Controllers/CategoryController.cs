using AvtoElonData.Context;
using AvtoElonData.Dtos;
using AvtoElonData.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AvtoelonMV.Controllers;

public class CategoryController : Controller
{
    
    private readonly AppDbContext _context;

    public CategoryController(AppDbContext context)
    {
        _context = context;
    }

    [Authorize]
    [HttpGet]
    public  IActionResult AddCategory()
    {
        return View();
    }
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddCategory([FromForm] CategoryDto dto)
    {
        var category = new Categories()
        {
            Name = dto.Name,
            ParentId = dto.ParentId
        };
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
        return Ok();
    }
}