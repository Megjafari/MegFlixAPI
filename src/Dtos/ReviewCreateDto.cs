using System.ComponentModel.DataAnnotations;

namespace MovieLibraryApi.Dtos;

public class ReviewCreateDto
{
    [Required]
    [MinLength(3)]
    public string Comment { get; set; } = string.Empty;

    [Range(1, 5)]
    public int Rating { get; set; }

    [Range(1, int.MaxValue)]
    public int MovieId { get; set; }
}