using Bloggr.Database.Interfaces;
using Bloggr.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Bloggr.Database;

public class PostRepository : IPostRepository
{
    private readonly BloggrDbContext _bloggrDbContext;
    
    public PostRepository(BloggrDbContext bloggrDbContext)
    {
        _bloggrDbContext = bloggrDbContext;
    }
    
    public async Task<Post?> GetByIdAsync(int postId)
    {
        return await _bloggrDbContext.Posts
            .Where(post => post.Id == postId)
            .FirstOrDefaultAsync();
    }
    
    public async Task<List<Post>> GetPostsAsync()
    {
        return await _bloggrDbContext.Posts
            .OrderByDescending(b => b.DateCreated)
            .ToListAsync();
    }
    
    public async Task AddAsync(Post post)
    {
        post.DateCreated = DateTime.UtcNow;
        post.DateModified = DateTime.UtcNow;

        await _bloggrDbContext.AddAsync(post);
        await _bloggrDbContext.SaveChangesAsync();
    }
    
    public async Task UpdateAsync(Post post)
    {
        post.DateModified = DateTime.UtcNow;

        _bloggrDbContext.Update(post);
        await _bloggrDbContext.SaveChangesAsync();
    }
    
    public void Delete(int postId)
    {
        _bloggrDbContext.Remove(_bloggrDbContext.Posts.Single(a => a.Id == postId));
        _bloggrDbContext.SaveChanges();
    }
}