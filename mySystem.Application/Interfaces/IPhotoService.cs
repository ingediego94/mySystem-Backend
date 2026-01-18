using mySystem.Application.DTOs;

namespace mySystem.Application.Interfaces;

public interface IPhotoService
{
    Task<IEnumerable<PhotoResponseDto>?> GetAllPhotosAsync();
    Task<PhotoResponseDto?> AddPhotoAsync(PhotoAddDto photoDto);
    Task<bool> ChangePhotoStatusAsync(int id);
    Task<bool> RemovePhotoAsync(int id);
}