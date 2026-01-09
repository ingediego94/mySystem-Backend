using System.Runtime.InteropServices.JavaScript;
using mySystem.Domain.Interfaces;

namespace mySystem.Domain.Entities;

public class User
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public bool IsActive { get; set; }
    public Role Role { get; set; }
    
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpire { get; set; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}