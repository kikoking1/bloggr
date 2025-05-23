using Bloggr.Database.Models;

namespace Bloggr.Database.Interfaces;

public interface IPostRepository
{
    Task<Post?> GetByIdAsync(int postId);
    Task<List<Post>> GetPostsAsync();
    Task AddAsync(Post post);
    Task UpdateAsync(Post post);
    void Delete(int postId);
}