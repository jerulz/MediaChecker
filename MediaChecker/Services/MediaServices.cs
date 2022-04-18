using MediaChecker.Interfaces;
using MediaChecker.Models;

namespace MediaChecker.Services;

public class MediaServices : IMediaServices
{
    private readonly IFileServices _fileServices;
    private readonly ILogger<MediaServices> _logger;

    public MediaServices(ILogger<MediaServices> logger, IFileServices fileServices)
    {
        _logger = logger;
        _fileServices = fileServices;
    }

    public Task<IEnumerable<Media>> GetAllMedias()
    {
        var files = _fileServices.GetAllFiles();
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

    public Task<IEnumerable<Movie>> GetAllMovies()
    {
        var files = _fileServices.GetMovieFiles();
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

    public Task<IEnumerable<Audio>> GetAllAudios()
    {
        var files = _fileServices.GetAudioFiles();
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

    public Task<IEnumerable<Image>> GetAllImages()
    {
        var files = _fileServices.GetImageFiles();
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

    public Task<IEnumerable<Media>> GetMediaFromName(string name)
    {
        var files = _fileServices.GetAllFiles();
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

    public Task<IEnumerable<Movie>> GetMovieFromName(string name)
    {
        var files = _fileServices.GetMovieFiles();
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

    public Task<IEnumerable<Audio>> GetAudioFromName(string name)
    {
        var files = _fileServices.GetAudioFiles();
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

    public Task<IEnumerable<Image>> GetImageFromName(string name)
    {
        var files = _fileServices.GetImageFiles();
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