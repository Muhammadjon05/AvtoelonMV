namespace AvtoElonData.Models;

public class Categories
{
    public Guid Id {get; set;}
    public string Name { get; set; } 
    public Guid? ParentId { get; set; }
    public Categories? Parent { get; set; }
    public List<Categories> Children { get; set; }
    public List<Products> ProductsList { get; set; }
}