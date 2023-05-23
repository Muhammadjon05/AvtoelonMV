using AvtoelonData.Entities;
using Microsoft.AspNetCore.Http;

namespace AvtoElonData.Models;
#pragma warning disable CS8618

public class Products
{
    public Guid Id { get; set; }
    public string Marka { get; set; }
    public string? Description { get; set; }
    public long  Price { get; set; }
    public long Distance { get; set; }
    public string  Color { get; set; }
    public DateTime CreatedDate{ get; set; }
    public string PhotoUrl { get; set; }
    public string  OilType { get; set; }
    public string Region { get; set; }
    public string District { get; set; }
    public string PhoneNumber { get; set; }
    public Categories Category { get; set; }
    public Guid CategoryId { get; set; }
    
    
    public Guid UserId { get; set; }
    public User User { get; set; }


}
#pragma warning restore CS8618

