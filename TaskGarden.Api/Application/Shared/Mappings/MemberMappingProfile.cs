using AutoMapper;
using TaskGarden.Api.Application.Shared.Models;
using TaskGarden.Api.Application.Shared.Projections;
using TaskGarden.Api.Domain.Entities;


namespace TaskGarden.Api.Application.Shared.Mappings;

public class MemberMappingProfile : Profile
{
    public MemberMappingProfile()
    {
        CreateMap<AppUser, MemberResponse>().ReverseMap();
        CreateMap<Member, MemberResponse>().ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ReverseMap();
    }
}