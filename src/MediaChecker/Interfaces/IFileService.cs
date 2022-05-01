namespace MediaChecker.Interfaces;

public interface IFileService
{
    Task<IEnumerable<FileInfo>> GetAllFilesAsync();
    Task<IEnumerable<FileInfo>> GetMovieFilesAsync();
    Task<IEnumerable<FileInfo>> GetAudioFilesAsync();
    Task<IEnumerable<FileInfo>> GetImageFilesAsync();
}