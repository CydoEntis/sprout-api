using AutoMapper;
using TaskGarden.Api.Application.Features.Auth.Commands.Login;
using TaskGarden.Api.Domain.Entities;

namespace TaskGarden.Api.Application.Shared.Mappings;

public class AuthMappingProfile : Profile
{
    public AuthMappingProfile()
    {
        // CreateMap<AppUser, RegisterRequestDto>().ReverseMap();
        CreateMap<AppUser, LoginResponse>().ReverseMap();
    }
}