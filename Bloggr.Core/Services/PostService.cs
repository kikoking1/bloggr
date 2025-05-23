using AutoMapper;
using Bloggr.Core.Interfaces;
using Bloggr.Core.Models;
using Bloggr.Database.Interfaces;
using Bloggr.Database.Models;

namespace Bloggr.Core.Services;

public class PostService : IPostService
{
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;
    
    public PostService(
        IPostRepository postRepository,
        IMapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
    }
    
    public async Task<PostDto> GetByIdAsync(int postId)
    {
        var postDto = _mapper.Map<PostDto>(await _postRepository.GetByIdAsync(postId));
        
        return postDto;
    }
    
    public async Task<List<PostDto>> GetPostsAsync()
    {
        var posts = await _postRepository.GetPostsAsync();
        var postDtos = _mapper.Map<List<PostDto>>(posts);
        
        return postDtos;
    }
    
    public async Task<PostDto> AddAsync(PostDto postDto)
    {
        var post = _mapper.Map<Post>(postDto);
        
        await _postRepository.AddAsync(post);
        
        postDto = _mapper.Map<PostDto>(post);
        
        return postDto;
    }
    
    public async Task<PostDto> UpdateAsync(PostDto postDto)
    {
        var post = _mapper.Map<Post>(postDto);
        
        await _postRepository.UpdateAsync(post);
        
        postDto = _mapper.Map<PostDto>(post);
        
        return postDto;
    }
    
    public void Delete(int id)
    {
        _postRepository.Delete(id);
    }
}