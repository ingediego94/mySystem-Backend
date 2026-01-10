using AutoMapper;
using mySystem.Domain.Entities;

namespace mySystem.Application.DTOs;

public class MapProfile : Profile
{
    public MapProfile()
    {
        // User:
        CreateMap<UserCreateDto, User>();
        CreateMap<UserUpdateDto, User>();
        CreateMap<User, UserResponseDto>();
    }
}