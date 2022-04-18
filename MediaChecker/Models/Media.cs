using System.ComponentModel.DataAnnotations;

namespace MediaChecker.Models;

public record Media
{
    [Required]
    public string Name { get; set; }
    
    [Required]
    public long Size { get; set; }

    public DateTime Year { get; set; }
}