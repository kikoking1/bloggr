using Bloggr.Core.Models;

namespace Bloggr.Core.Interfaces;

public interface IPostService
{
    Task<PostDto> GetByIdAsync(int postId);
    Task<List<PostDto>> GetPostsAsync();

    Task<PostDto> AddAsync(PostDto postDto);
    Task<PostDto> UpdateAsync(PostDto postDto);
    void Delete(int id);
}