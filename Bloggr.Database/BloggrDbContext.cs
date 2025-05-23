using Bloggr.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Bloggr.Database;

public class BloggrDbContext : DbContext
{
    public BloggrDbContext(DbContextOptions<BloggrDbContext> options)
        : base(options)
    {
    }
    
    public virtual DbSet<Post> Posts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Post>()
            .ToTable("Posts");
        
        base.OnModelCreating(modelBuilder);
    }
}