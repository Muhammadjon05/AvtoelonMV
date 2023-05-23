using System.Security.Claims;
using AvtoElonData.Context;
using AvtoElonData.Dtos;
using AvtoelonData.Entities;
using AvtoElonData.FileHelper;
using AvtoElonData.Models;
using AvtoelonMV.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AvtoelonMV.Controllers;

public class ProductController : Controller
{
 
    private readonly AppDbContext _context;
    private readonly UserProvider UserProvider;
    public ProductController(AppDbContext context, UserProvider userProvider)
    {
        _context = context;
        UserProvider = userProvider;
    }
    
    [Authorize]
    [HttpGet]
    public  IActionResult Addproduct()
    {
        return View();
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Addproduct([FromForm] ProductDto dto,Guid Id)
    {
        var product = new Products()
        {
            Marka = dto.Marka,
            Description = dto.Description,
            Price = dto.Price,
            Distance = dto.Distance,
            Color = dto.Color,
            CreatedDate = dto.CreatedDate,
            OilType = dto.OilType,
            Region = dto.Region,
            District = dto.District,
            CategoryId = Id,
            UserId = UserProvider.UserId,
            PhoneNumber = dto.PhoneNumber,
        };  
        product.PhotoUrl = await Helper.SaveProduct(dto.Photo);
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index","Main");
    }
    [Authorize]
    [HttpGet]
    public  IActionResult ChooseCategory()
    {
        return View();
    }
}