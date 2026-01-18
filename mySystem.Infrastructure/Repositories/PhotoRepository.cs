using Microsoft.EntityFrameworkCore;
using mySystem.Domain.Entities;
using mySystem.Domain.Interfaces;
using mySystem.Infrastructure.Data;


namespace mySystem.Infrastructure.Repositories;

public class PhotoRepository :IPhotoRepository
{
    private readonly AppDbContext _context;

    public PhotoRepository(AppDbContext context)
    {
        _context = context;
    }
    
    // ------------------------------------------
    
    // Get all:
    public async Task<IEnumerable<Photo>?> GetAllAsync()
    {
        return await _context.Photos.ToListAsync();
    }

    
    // Add photos:
    public async Task<Photo?> AddAsync(Photo photo)
    {
        _context.Photos.Add(photo);
        await _context.SaveChangesAsync();
        return photo;
    }

    
    // Remove photos:
    public async Task<bool> RemoveAsync(int id)
    {
        var entity = await _context.Photos.FirstOrDefaultAsync(p => p.Id == id);
        if (entity == null) return false;
        _context.Photos.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    
    // Change status (activate or desactivate):
    public async Task<bool> ChangeStatus(int id)
    {
        var photo = await _context.Photos.FirstOrDefaultAsync(p => p.Id == id);
        if (photo == null) return false;
        photo.Active = !photo.Active;
        _context.Photos.Update(photo);
        await _context.SaveChangesAsync();
        return true;
    }
}