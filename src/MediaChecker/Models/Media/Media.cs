using System.ComponentModel.DataAnnotations;

namespace MediaChecker.Models.Media;

public record Media
{
    [Required] public string Name { get; set; }

    [Required] public long Size { get; set; }

    public string Year { get; set; }

}