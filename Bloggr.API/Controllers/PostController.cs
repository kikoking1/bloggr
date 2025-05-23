using Bloggr.Core.Interfaces;
using Bloggr.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bloggr.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostController : ControllerBase
{
    private readonly IPostService _postService;
    private readonly ILogger<PostController> _logger;

    public PostController(
        IPostService postService,
        ILogger<PostController> logger)
    {
        _postService = postService;
        _logger = logger;
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<PostDto>> RetrieveProductByIdAsync(int id)
    {
        var postDto = await _postService.GetByIdAsync(id);
        return StatusCode(StatusCodes.Status200OK, postDto);
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<List<PostDto>>> GetPostsAsync()
    {
        return StatusCode(StatusCodes.Status200OK, await _postService.GetPostsAsync());
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<PostDto>> AddPost([FromBody] PostDto postDto)
    {
        postDto = await _postService.AddAsync(postDto);
        return StatusCode(StatusCodes.Status200OK, postDto);
    }
    
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<PostDto>> UpdateProductAsync([FromBody] PostDto postDto)
    {
        postDto = await _postService.UpdateAsync(postDto);
        return StatusCode(StatusCodes.Status200OK, postDto);
    }
    
    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult DeleteProduct(int id)
    {
        _postService.Delete(id);
        return StatusCode(StatusCodes.Status204NoContent);
    }
}