using MediaChecker.Models.Media;

namespace MediaChecker.Interfaces;

public interface IMediaServices
{
    Task<IEnumerable<Media>> GetAllMediasAsync();

    Task<IEnumerable<Media>> GetMediaFromNameAsync(string name);
}