using AutoMapper;
using Microsoft.AspNetCore.SignalR;
using Recipes.Application.Users.Dtos.Auth;
using Recipes.Application.Users.Dtos.Login;
using Recipes.Application.Users.Queries.GetMyAuthProfile;
using Recipes.Domain.Entities.UserContext;

namespace Recipes.Application.Users.Dtos;
public class UsersMappingProfile : Profile
{
    public UsersMappingProfile()
    {
        CreateMap<ApplicationUser, UserDto>();

        CreateMap<AuthResult, LoginResponse>()
            .ForMember(d => d.AccessToken, m => m.MapFrom(s => s.AccessToken))
            .ForMember(d => d.Expires, m => m.MapFrom(s => s.Expires))
            .ForMember(d => d.TokenType, m => m.MapFrom(_ => "Bearer"))
            .ForMember(d => d.Roles, m => m.MapFrom(s => s.Roles))
            .ForMember(d => d.User, m => m.MapFrom(s => s.User)); // ApplicationUser -> UserDto (вже налаштовано)

        CreateMap<AuthResult, AuthProfileDto>()
                .ForMember(d => d.User, m => m.MapFrom(s => s.User))
                .ForMember(d => d.Roles, m => m.MapFrom(s => s.Roles));
    }
}
