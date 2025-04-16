using AutoMapper;
using Sprout.Api.Application.Features.Auth.Commands.Login;
using Sprout.Api.Domain.Entities;

namespace Sprout.Api.Application.Shared.Mappings;

public class AuthMappingProfile : Profile
{
    public AuthMappingProfile()
    {
        // CreateMap<AppUser, RegisterRequestDto>().ReverseMap();
        CreateMap<AppUser, LoginResponse>().ReverseMap();
    }
}