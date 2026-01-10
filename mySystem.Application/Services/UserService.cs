using AutoMapper;
using mySystem.Application.DTOs;
using mySystem.Application.Interfaces;
using mySystem.Domain.Entities;
using mySystem.Domain.Interfaces;

namespace mySystem.Application.Services;

public class UserService : IUserService
{
    private readonly IGeneralRepository<User> _userRepository;
    private readonly IMapper _mapper;

    public UserService(IGeneralRepository<User> userRepository,
        IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    
    // -------------------------------------------------
    
    // Get All:
    public async Task<IEnumerable<UserResponseDto>> GetAllAsync()
    {
        var users = await _userRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<UserResponseDto>>(users);
    }

    
    // Get By Id:
    public async Task<UserResponseDto?> GetById(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        return _mapper.Map<UserResponseDto>(user);
    }
    
    
    // Update:
    public Task<bool> UpdateAsync(UserUpdateDto dto)
    {
        throw new NotImplementedException();
    }

    // Delete:
    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}