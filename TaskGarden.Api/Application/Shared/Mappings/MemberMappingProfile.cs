using AutoMapper;
using TaskGarden.Application.Features.Shared.Models;
using TaskGarden.Domain.Entities;
using TaskGarden.Infrastructure.Projections;


namespace TaskGarden.Application.MappingProfiles;


public class MemberMappingProfile : Profile
{
    public MemberMappingProfile()
    {
        CreateMap<AppUser, MemberResponse>().ReverseMap();
        CreateMap<Member, MemberResponse>().ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id)).ReverseMap();
    }
}