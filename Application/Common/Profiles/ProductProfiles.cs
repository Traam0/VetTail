using AutoMapper;
using VetTail.Domain.Entities;
using VetTail.Application.Common.DTOs;

namespace VetTail.Application.Common.Profiles;

public class ProductProfiles : Profile
{
    public ProductProfiles()
    {
        CreateMap<Product, ProductBrief>();
    }
}
