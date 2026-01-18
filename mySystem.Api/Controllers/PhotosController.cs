using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mySystem.Application.DTOs;
using mySystem.Application.Interfaces;

namespace mySystem.Api.Controllers;


[ApiController]
[Route("api/photos")] 
public class PhotosController : ControllerBase
{
    private readonly IPhotoService _photoService;

    public PhotosController(IPhotoService photoService)
    {
        _photoService = photoService;
    }

    // ------------------------------------------------
    
    // Obtains all pictures.
    [Authorize(Roles = "Admin, User")]
    [HttpGet("getAll")]
    public async Task<ActionResult<List<PhotoResponseDto>>> GetAll()
    {
        var photos = await _photoService.GetAllPhotosAsync();
        
        // Return an empty list if null, while maintaining the expected type
        return Ok(photos ?? Enumerable.Empty<PhotoResponseDto>().ToList()); 
    }

    
    // Uploads a picture.
    [Authorize(Roles = "Admin")]
    [HttpPost("create")]
    public async Task<IActionResult> AddPhoto([FromForm] PhotoUploadFormDto photoForm)
    {
        if (!ModelState.IsValid || photoForm.Photo == null)
        {
            return BadRequest(ModelState);
        }
        
        
        // ---> MODIFICADO (opcional, validación explícita)
        if (!photoForm.Photo.ContentType.StartsWith("image/") &&
            !photoForm.Photo.ContentType.StartsWith("video/"))
        {
            return BadRequest(new { message = "Only image or video files are allowed." });
        }
        
        
        // We do not need the "using" nor converting to Stream
        var photoDto = new PhotoAddDto
        {
            Photo = photoForm.Photo,  // It passes IFormFile directly
            UserId = photoForm.UserId
        };
    
        try
        {
            var addedPhoto = await _photoService.AddPhotoAsync(photoDto);

            return CreatedAtAction(nameof(GetAll), new { id = addedPhoto.Id }, addedPhoto);
        }
        catch (ArgumentNullException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message }); 
        }
    }

    
    // It changes the status (active/disabled) of a picture by Id.
    [Authorize(Roles = "Admin")]
    [HttpPut("status/{id:int}")] 
    public async Task<IActionResult> ChangeStatus(int id)
    {
        var success = await _photoService.ChangePhotoStatusAsync(id);

        if (!success)
        {
            return NotFound(new { message = $"Foto con ID {id} no encontrada." });
        }

        return Ok(new { message = "Estado de la foto cambiado exitosamente." });
    }
    
    
    // Deletes a picture by Id.
    [Authorize(Roles = "Admin")]
    [HttpDelete("delete/{id:int}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var success = await _photoService.RemovePhotoAsync(id);

        if (!success)
        {
            return NotFound(new { message = $"Registro con ID {id} no encontrado." });
        }

        // 204 No Content
        return NoContent(); 
    }
}