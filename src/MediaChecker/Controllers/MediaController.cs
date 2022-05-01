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
    /// Get every movie files in the Movie directory
    /// </summary>
    /// <returns></returns>
    [HttpGet("getMovies")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetMoviesAsync()
    {
        try
        {
            return Ok(await _mediaServices.GetAllMoviesAsync());
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
    /// Get every audio files in the Audio directory
    /// </summary>
    /// <returns></returns>
    [HttpGet("getAudios")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAudiosAsync()
    {
        try
        {
            return Ok(await _mediaServices.GetAllAudiosAsync());
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
    /// Get every image files in the Images directory
    /// </summary>
    /// <returns></returns>
    [HttpGet("getImages")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetImagesAsync()
    {
        try
        {
            return Ok(await _mediaServices.GetAllImagesAsync());
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

    /// <summary>
    /// Get every movie files containing the parameter name
    /// </summary>
    /// <param name="name">Name to look for</param>
    /// <returns></returns>
    [HttpGet("getMovie")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetMovieAsync(string name)
    {
        try
        {
            return Ok(await _mediaServices.GetMovieFromNameAsync(name));
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
    /// Get every audio files containing the parameter name
    /// </summary>
    /// <param name="name">Name to look for</param>
    /// <returns></returns>
    [HttpGet("getAudio")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAudioAsync(string name)
    {
        try
        {
            return Ok(await _mediaServices.GetAudioFromNameAsync(name));
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
    /// Get every image files containing the parameter name
    /// </summary>
    /// <param name="name">Name to look for</param>
    /// <returns></returns>
    [HttpGet("getImage")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetImageAsync(string name)
    {
        try
        {
            return Ok(await _mediaServices.GetImageFromNameAsync(name));
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