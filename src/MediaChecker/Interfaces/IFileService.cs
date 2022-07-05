namespace MediaChecker.Interfaces;

public interface IFileService
{
    Task<IEnumerable<FileInfo>> GetAllFilesAsync();
}