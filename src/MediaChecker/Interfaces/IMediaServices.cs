using MediaChecker.Models;

namespace MediaChecker.Interfaces;

public interface IMediaServices
{
    Task<IEnumerable<Media>> GetAllMediasAsync();
    Task<IEnumerable<Movie>> GetAllMoviesAsync();
    Task<IEnumerable<Audio>> GetAllAudiosAsync();
    Task<IEnumerable<Image>> GetAllImagesAsync();

    Task<IEnumerable<Media>> GetMediaFromNameAsync(string name);
    Task<IEnumerable<Movie>> GetMovieFromNameAsync(string name);
    Task<IEnumerable<Audio>> GetAudioFromNameAsync(string name);
    Task<IEnumerable<Image>> GetImageFromNameAsync(string name);
}