using mySystem.Domain.Entities;

namespace mySystem.Domain.Interfaces;

public interface IPhotoRepository
{
    Task<IEnumerable<Photo>?> GetAllAsync();
    Task<Photo?> AddAsync(Photo photo);
    Task<bool> RemoveAsync(int id);
    Task<bool> ChangeStatus(int id);
}