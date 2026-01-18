using mySystem.Application.DTOs;

namespace mySystem.Application.Interfaces;

public interface ICloudinaryService
{
    Task<string?> UploadPhotoAsync(UploadPhotoDto entityDto);
}