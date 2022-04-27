using MediaChecker.Interfaces;
using MediaChecker.Models;

namespace MediaChecker.Services;

public class MediaService : IMediaServices
{
    private readonly IFileService _fileService;
    private readonly ILogger<MediaService> _logger;

    public MediaService(ILogger<MediaService> logger, IFileService fileService)
    {
        _logger = logger;
        _fileService = fileService;
    }

    public Task<IEnumerable<Media>> GetAllMediasAsync()
    {
        var files = _fileService.GetAllFilesAsync();
        var task = files.ContinueWith(t =>
        {
            return t.Result.Select(file => new Media
            {
                Name = file.Name,
                Size = file.Length / 1000 / 1000
            });
        });
        files.Start();
        _logger.LogInformation($"Media retrieved: {files.Result.Count().ToString()}");
        return task;
    }

    public Task<IEnumerable<Movie>> GetAllMoviesAsync()
    {
        var files = _fileService.GetMovieFilesAsync();
        var task = files.ContinueWith(t =>
        {
            return t.Result.Select(file => new Movie
            {
                Name = file.Name,
                Size = file.Length / 1000 / 1000
            });
        });
        files.Start();
        _logger.LogInformation($"Movies retrieved: {files.Result.Count().ToString()}");
        return task;
    }

    public Task<IEnumerable<Audio>> GetAllAudiosAsync()
    {
        var files = _fileService.GetAudioFilesAsync();
        var task = files.ContinueWith(t =>
        {
            return t.Result.Select(file => new Audio
            {
                Name = file.Name,
                Size = file.Length / 1000 / 1000
            });
        });
        files.Start();
        _logger.LogInformation($"Audios retrieved: {files.Result.Count().ToString()}");
        return task;
    }

    public Task<IEnumerable<Image>> GetAllImagesAsync()
    {
        var files = _fileService.GetImageFilesAsync();
        var task = files.ContinueWith(t =>
        {
            return t.Result.Select(file => new Image
            {
                Name = file.Name,
                Size = file.Length / 1000 / 1000
            });
        });
        files.Start();
        _logger.LogInformation($"Images retrieved: {files.Result.Count().ToString()}");
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
        _logger.LogInformation($"Media(s) retrieved: {files.Result.Count().ToString()}");
        return task;
    }

    public Task<IEnumerable<Movie>> GetMovieFromNameAsync(string name)
    {
        var files = _fileService.GetMovieFilesAsync();
        var task = files.ContinueWith(t =>
        {
            return t.Result.Where(f => f.Name.ToLowerInvariant().Contains(name.ToLowerInvariant())).Select(file =>
                new Movie
                {
                    Name = file.Name,
                    Size = file.Length / 1000 / 1000
                });
        });
        files.Start();
        _logger.LogInformation($"Movie(s) retrieved: {files.Result.Count().ToString()}");
        return task;
    }

    public Task<IEnumerable<Audio>> GetAudioFromNameAsync(string name)
    {
        var files = _fileService.GetAudioFilesAsync();
        var task = files.ContinueWith(t =>
        {
            return t.Result.Where(f => f.Name.ToLowerInvariant().Contains(name.ToLowerInvariant())).Select(file =>
                new Audio
                {
                    Name = file.Name,
                    Size = file.Length / 1000 / 1000
                });
        });
        files.Start();
        _logger.LogInformation($"Audio(s) retrieved: {files.Result.Count().ToString()}");
        return task;
    }

    public Task<IEnumerable<Image>> GetImageFromNameAsync(string name)
    {
        var files = _fileService.GetImageFilesAsync();
        var task = files.ContinueWith(t =>
        {
            return t.Result.Where(f => f.Name.ToLowerInvariant().Contains(name.ToLowerInvariant())).Select(file =>
                new Image
                {
                    Name = file.Name,
                    Size = file.Length / 1000 / 1000
                });
        });
        files.Start();
        _logger.LogInformation($"Image(s) retrieved: {files.Result.Count().ToString()}");
        return task;
    }
}