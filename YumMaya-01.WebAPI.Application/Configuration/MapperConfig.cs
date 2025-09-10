using AutoMapper;
using YumMaya_01.WebAPI.Application.DTOs.Recipes;
using YumMaya_01.WebAPI.Application.DTOs.Tags;
using YumMaya_01.WebAPI.Domain.Enums;
using YumMaya_01.WebAPI.Domain.Models;

namespace YumMaya_01.WebAPI.Application.Configuration;

public sealed class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<Recipe, RecipeDto>()
            .ForMember(dest => dest.Difficulty,
                       opt => opt.MapFrom(src => src.Difficulty.ToString()))
            .ForMember(dest => dest.tags,
                       opt => opt.MapFrom(src => src.RecipeTags.Select(rt => rt.Tag)));

        CreateMap<RecipeCreateDto, Recipe>()
            .ForMember(dest => dest.Difficulty,
                        opt => opt.MapFrom(src => Enum.Parse<Difficulty>(src.Difficulty, true)))
            .ForMember(dest => dest.RecipeTags,
                        opt => opt.MapFrom(src => src.TagIds.Select(t => new RecipeTag { TagId = t })))
            .ForMember(dest => dest.Tags, opt => opt.Ignore());

        CreateMap<RecipeUpdateDto, Recipe>()
            .ForMember(dest => dest.Difficulty,
                       opt => opt.MapFrom(src => Enum.Parse<Difficulty>(src.Difficulty, true)))
            .ForMember(dest => dest.RecipeTags,
                       opt => opt.MapFrom(src => src.TagIds.Select(t => new RecipeTag { TagId = t })))
            .ForMember(dest => dest.Tags, opt => opt.Ignore()); 

        CreateMap<Tag, TagDto>();
    }
}