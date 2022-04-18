namespace MediaChecker.Interfaces;

public interface IFileServices
{
    Task<IEnumerable<FileInfo>> GetAllFiles();
    Task<IEnumerable<FileInfo>> GetMovieFiles();
    Task<IEnumerable<FileInfo>> GetAudioFiles();
    Task<IEnumerable<FileInfo>> GetImageFiles();
}