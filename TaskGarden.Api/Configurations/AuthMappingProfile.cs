using AutoMapper;
using TaskGarden.Api.Dtos.Auth;
using TaskGarden.Data.Models;

namespace TaskGarden.Api.Configurations;

public class AuthMappingProfile : Profile
{
    public AuthMappingProfile()
    {
        CreateMap<AppUser, RegisterRequestDto>().ReverseMap();
        CreateMap<AppUser, LoginRequestDto>().ReverseMap();
    }
}