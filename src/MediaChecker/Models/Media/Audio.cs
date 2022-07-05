namespace MediaChecker.Models.Media;

public record Audio: Media
{
    public enum AudioFormatType
    {
        Mp3, Ogg, Wave, Flac
    }
    public AudioFormatType Format { get; set; }
}