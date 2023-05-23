using AvtoElonData.Models;
using Microsoft.AspNetCore.Identity;

namespace AvtoelonData.Entities;

public class User : IdentityUser<Guid>
{
    public string  FirstName { get; set; }
    public List<Products> Products { get; set; }
}