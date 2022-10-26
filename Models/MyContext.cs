#pragma warning disable CS8618 
using Microsoft.EntityFrameworkCore;
namespace ConcertGrail.Models;

public class MyContext : DbContext
{
    public MyContext(DbContextOptions options) : base(options) { }
    public DbSet<User> Users { get; set; } 
    public DbSet<Post> Posts { get; set; } 
    public DbSet<Comment> Comments { get; set; } 
    public DbSet<Review> Reviews { get; set; } 
    public DbSet<Listing> Listings { get; set; }
}
