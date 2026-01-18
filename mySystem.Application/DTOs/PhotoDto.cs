using Microsoft.AspNetCore.Http;

namespace mySystem.Application.DTOs;

public class PhotoResponseDto
{
    public int Id { get; set; }
    public int? UserId { get; set; }

    public string? UrlImage { get; set; } = string.Empty;
    public bool Active { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}

public class PhotoAddDto
{
    public IFormFile Photo { get; set; }  // To change from Stream to IFormFile
    public int? UserId { get; set; }
}