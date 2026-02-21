namespace MovieLibraryApi.Dtos;

public class ReviewResponseDto
{
    public int Id { get; set; }
    public string Comment { get; set; } = string.Empty;
    public int Rating { get; set; }
    public int MovieId { get; set; }
}