using AutoMapper;
using Sprout.Api.Application.Shared.Models;
using Sprout.Api.Application.Shared.Projections;
using Sprout.Api.Domain.Entities;


namespace Sprout.Api.Application.Shared.Mappings;

public class MemberMappingProfile : Profile
{
    public MemberMappingProfile()
    {
        CreateMap<AppUser, MemberResponse>().ReverseMap();
        CreateMap<Member, MemberResponse>().ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ReverseMap();
    }
}