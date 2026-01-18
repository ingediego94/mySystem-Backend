using System.ComponentModel.DataAnnotations;
namespace mySystem.Application.DTOs;
using Microsoft.AspNetCore.Http; // IFormFile

public class UploadPhotoDto
{
    public IFormFile Photo { get; set; }
    public int? UserId { get; set; }
}

public class PhotoUploadFormDto
{
    [Required(ErrorMessage = "El archivo de la foto es requerido.")]
    public IFormFile Photo { get; set; }
    
    // We use the same name 'UserId' than in DTO for the service for consistence.
    public int? UserId { get; set; }
}