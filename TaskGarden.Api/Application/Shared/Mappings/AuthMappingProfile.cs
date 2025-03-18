using AutoMapper;
using TaskGarden.Application.Features.Auth.Commands.Login;
using TaskGarden.Domain.Entities;

namespace TaskGarden.Application.MappingProfiles;

public class AuthMappingProfile : Profile
{
    public AuthMappingProfile()
    {
        // CreateMap<AppUser, RegisterRequestDto>().ReverseMap();
        CreateMap<AppUser, LoginResponse>().ReverseMap();
    }
}