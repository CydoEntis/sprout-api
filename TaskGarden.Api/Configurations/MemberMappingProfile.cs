// using AutoMapper;
// using TaskGarden.Api.Dtos;
// using TaskGarden.Infrastructure.Models;
// using TaskGarden.Infrastructure.Models.Member;
//
// namespace TaskGarden.Api.Configurations;
//
// public class MemberMappingProfile : Profile
// {
//     public MemberMappingProfile()
//     {
//         CreateMap<AppUser, Member>().ReverseMap();
//         CreateMap<Member, MemberResponseDto>().ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id)).ReverseMap();
//     }
// }