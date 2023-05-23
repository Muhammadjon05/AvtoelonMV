using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;

namespace AvtoElonData.Dtos;

public class AnnouncementDto
{
    public string Marka { get; set; }
    
    public string? Description { get; set; }
    
    public long  Price { get; set; }
    
    public long Distance { get; set; }
    
    public string  Color { get; set; }
    
    public DateTime CreatedDate{ get; set; }
    
    public IBrowserFile? Photo { get; set; }

    public string  OilType { get; set; }
    
    public string Region { get; set; }
    
    public string District { get; set; }
    
    public string PhoneNumber { get; set; }
    
    public Guid CategoryId { get; set; }
}