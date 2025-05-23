using AutoMapper;
using Bloggr.Core.Models;
using Bloggr.Database.Models;

namespace Bloggr.API.MapperProfiles;

public class Mappings : Profile
{
    public Mappings()
    {
        CreateMap<Post, PostDto>();
        CreateMap<PostDto, Post>();
    }
}