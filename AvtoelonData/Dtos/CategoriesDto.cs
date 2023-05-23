namespace AvtoElonData.Dtos;

public class CategoriesDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid ParentId { get; set; }
    
}