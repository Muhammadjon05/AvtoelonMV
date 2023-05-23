using AvtoElonData.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AvtoelonMV.Controllers;

public class MainController : Controller
{
    
    private readonly AppDbContext _context;

    public MainController(AppDbContext context)
    {
        _context = context;
    }
    
    public async  Task<IActionResult> Index()
    {
        var elonlar = await _context.Products.Include(i=>i.Category).ToListAsync();
        return View(elonlar);
    }
}