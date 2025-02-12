using AutoMapper;
using TaskGarden.Api.Dtos;
using TaskGarden.Data.Models;
using TaskGarden.Data.Models.Member;

namespace TaskGarden.Api.Configurations;

public class MemberMappingProfile : Profile
{
    public MemberMappingProfile()
    {
        CreateMap<AppUser, Member>().ReverseMap();
        CreateMap<Member, MemberResponseDto>().ReverseMap();
    }
}