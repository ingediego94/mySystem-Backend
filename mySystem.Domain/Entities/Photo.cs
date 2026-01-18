namespace mySystem.Domain.Entities;

public class Photo
{
    public int Id { get; set; }
    public int? UserId { get; set; }

    
    public string? UrlImage { get; set; } = string.Empty;
    public bool Active { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    
    // Relations
    public User User { get; set; }
}