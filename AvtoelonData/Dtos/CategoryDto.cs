namespace AvtoElonData.Dtos;

public class CategoryDto
{
    public string Name { get; set; } 
   
    public Guid? ParentId { get; set; }
   
}