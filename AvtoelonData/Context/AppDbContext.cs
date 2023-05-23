using AvtoelonData.Entities;
using AvtoElonData.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AvtoElonData.Context;
 
public class AppDbContext : IdentityDbContext<User,Role,Guid>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
    public DbSet<Categories> Categories { get; set; }
    public DbSet<User> Users { get; set; } 
    public DbSet<Products> Products { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Categories>().ToTable("categories");
        modelBuilder.Entity<Products>().ToTable("products");
        
        modelBuilder.Entity<Categories>()
            .HasOne(c => c.Parent)
            .WithMany(c => c.Children)
            .HasForeignKey(c => c.ParentId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Products>()
            .HasOne(product => product.User)
            .WithMany(user => user.Products)
            .OnDelete(DeleteBehavior.NoAction);
            
        modelBuilder.Entity<User>().ToTable("users");
        modelBuilder.Entity<User>().Property(u => u.UserName).IsRequired().HasColumnName("username");
        modelBuilder.Entity<User>().Property(u => u.Email).IsRequired().HasColumnName("emails");
        modelBuilder.Entity<User>().Property(u => u.PhoneNumber).IsRequired().HasColumnName("phonenumbers");
    }
}