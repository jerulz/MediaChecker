using System.Text.RegularExpressions;
using MediaChecker.Interfaces;
using MediaChecker.Models.Media;

namespace MediaChecker.Services;

public class MediaService : IMediaServices
{
    private readonly IFileService _fileService;
    private readonly ILogger<MediaService> _logger;
    private readonly Regex _regex;

    public MediaService(ILogger<MediaService> logger, IFileService fileService)
    {
        _logger = logger;
        _fileService = fileService;
        _regex = new Regex(@"^[1-9]\d{3,}$");
    }
    
    // TODO modifier la regex
    public Task<IEnumerable<Media>> GetAllMediasAsync()
    {
        var files = _fileService.GetAllFilesAsync();
        var task = files.ContinueWith(t =>
        {
            return t.Result.Select(file => new Media
            {
                Name = file.Name,
                Size = file.Length / 1000 / 1000,
                Year = _regex.Match(file.Name).Value
            });
        });
        files.Start();
        _logger.LogInformation($"Media retrieved: {task.Result.Count().ToString()}");
        return task;
    }

    public Task<IEnumerable<Media>> GetMediaFromNameAsync(string name)
    {
        var files = _fileService.GetAllFilesAsync();
        var task = files.ContinueWith(t =>
        {
            return t.Result.Where(f => f.Name.ToLowerInvariant().Contains(name.ToLowerInvariant())).Select(file =>
                new Media
                {
                    Name = file.Name,
                    Size = file.Length / 1000 / 1000
                });
        });
        files.Start();
        _logger.LogInformation($"Media(s) retrieved: {task.Result.Count().ToString()}");
        return task;
    }

  
}