using AutoMapper;
using mySystem.Domain.Entities;

namespace mySystem.Application.DTOs;

public class MapProfile : Profile
{
    public MapProfile()
    {
        // JWT
        CreateMap<RegisterDto, User>();
        CreateMap<User, RegisterDto>();
        
        CreateMap<User, UserRegisterResponseDto>();
        CreateMap<UserRegisterResponseDto, User>();
        
        CreateMap<UserAuthResponseDto, User>();
        CreateMap<User, UserAuthResponseDto>();
        
        // User:
        CreateMap<UserCreateDto, User>();
        CreateMap<UserUpdateDto, User>();
        CreateMap<User, UserResponseDto>();
        
        // Maping of Photo
        CreateMap<Photo, PhotoResponseDto>();
        CreateMap<PhotoResponseDto, Photo>();
    }
}