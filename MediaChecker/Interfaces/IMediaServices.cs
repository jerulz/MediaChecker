using MediaChecker.Models;

namespace MediaChecker.Interfaces;

public interface IMediaServices
{
    Task<IEnumerable<Media>> GetAllMedias();
    Task<IEnumerable<Movie>> GetAllMovies();
    Task<IEnumerable<Audio>> GetAllAudios();
    Task<IEnumerable<Image>> GetAllImages();

    Task<IEnumerable<Media>> GetMediaFromName(string name);
    Task<IEnumerable<Movie>> GetMovieFromName(string name);
    Task<IEnumerable<Audio>> GetAudioFromName(string name);
    Task<IEnumerable<Image>> GetImageFromName(string name);
}