namespace MediaChecker.Models.Media;

public record Movie: Media
{
    public enum MovieFormatType
    {
        Mp4, Avi, Mkv
    }
    public string Format { get; set; }

    
}