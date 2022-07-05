namespace MediaChecker.Models.Media;

public record Image: Media
{
    public enum ImageFormatType
    {
        Jpeg, Gif
    }
    public ImageFormatType Format { get; set; }
}