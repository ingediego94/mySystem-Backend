using mySystem.Application.DTOs;
using mySystem.Domain.Entities;

namespace mySystem.Application.Interfaces;

public interface IUserService
{
    Task<IEnumerable<UserResponseDto>> GetAllAsync();
    Task<UserResponseDto?> GetById(int id);
    Task<bool> UpdateAsync(UserUpdateDto dto);
    Task<bool> DeleteAsync(int id);
}