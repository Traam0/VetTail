using AutoMapper;
using VetTail.Application.Common.DTOs;
using VetTail.Domain.Entities;

namespace VetTail.Application.Common.Profiles;

public class CategoryProfiles : Profile
{
    public CategoryProfiles()
    {
        CreateMap<Category, CategoryBrief>();

    }
}
