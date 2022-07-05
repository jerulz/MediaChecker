using MediaChecker.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MediaChecker.Controllers;

[ApiController]
[Produces("application/json")]
[Route("api/[controller]")]
public class MediaController : ControllerBase
{
    private readonly ILogger<MediaController> _logger;
    private readonly IMediaServices _mediaServices;

    public MediaController(ILogger<MediaController> logger, IMediaServices mediaServices)
    {
        _logger = logger;
        _mediaServices = mediaServices;
    }
    /// <summary>
    /// Get every media files in the root directory
    /// </summary>
    /// <returns></returns>
    [HttpGet("getMedias")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetMediasAsync()
    {
        try
        {
            return Ok(await _mediaServices.GetAllMediasAsync());
        }
        catch (ArgumentException e)
        {
            _logger.LogError(e.Message);
            return BadRequest(e.Message);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return Problem(e.Message);
        }
    }

    /// <summary>
    /// Get every media files containing the parameter name
    /// </summary>
    /// <param name="name">Name to look for</param>
    /// <returns></returns>
    [HttpGet("getMedia")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetMediaAsync(string name)
    {
        try
        {
            return Ok(await _mediaServices.GetMediaFromNameAsync(name));
        }
        catch (ArgumentException e)
        {
            _logger.LogError(e.Message);
            return BadRequest(e.Message);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return Problem(e.Message);
        }
    }
}