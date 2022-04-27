using MediaChecker.Interfaces;

namespace MediaChecker.Services;

public class FileService : IFileService
{
    private readonly ILogger<FileService> _logger;
    private readonly IConfiguration _configuration;

    public FileService(ILogger<FileService> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
    }

    public Task<IEnumerable<FileInfo>> GetAllFilesAsync()
    {
        string path = _configuration["MediaDirectory:Path"];
        if (String.IsNullOrEmpty(path))
        {
            throw new ArgumentException("No path found in the config file for Media directory");
        }
        return new Task<IEnumerable<FileInfo>>(() =>
        {
                DirectoryInfo rootDirectory = new DirectoryInfo(path);
                IEnumerable<DirectoryInfo> directories = rootDirectory.GetDirectories();
                List<FileInfo> files = new List<FileInfo>();
                foreach (var directory in directories)
                {
                    _logger.LogDebug($"Directory: {directory.Name}");
                    var filesPerDirectory = directory.GetFiles();
                    _logger.LogDebug($"Files Retrieved: {filesPerDirectory.Length}");
                    files.AddRange(filesPerDirectory);
                }

                _logger.LogDebug($"Total files Retrieved: {files.Count}");
                return files;
        });
    }

    public Task<IEnumerable<FileInfo>> GetMovieFilesAsync()
    {
        string path = _configuration["MovieDirectory:Path"];
        return GetFilesFromPath(path);
    }

    public Task<IEnumerable<FileInfo>> GetAudioFilesAsync()
    {
        string path = _configuration["AudioDirectory:Path"];
        return GetFilesFromPath(path);
    }

    public Task<IEnumerable<FileInfo>> GetImageFilesAsync()
    {
        string path = _configuration["ImageDirectory:Path"];
        return GetFilesFromPath(path);
    }

    private Task<IEnumerable<FileInfo>> GetFilesFromPath(string path)
    {
        if (String.IsNullOrEmpty(path))
        {
            throw new ArgumentException("No path found in the config file for this directory");
        }
        return new Task<IEnumerable<FileInfo>>(() =>
        {
            DirectoryInfo rootDirectory = new DirectoryInfo(path);
            _logger.LogDebug($"Directory: {rootDirectory.Name}");
            List<FileInfo> files = new List<FileInfo>();
            var filesPerDirectory = rootDirectory.GetFiles();
            files.AddRange(filesPerDirectory);
            _logger.LogDebug($"Files Retrieved: {files.Count}");
            return files;
        });
    }
}