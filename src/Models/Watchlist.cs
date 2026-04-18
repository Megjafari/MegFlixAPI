namespace MovieLibraryApi.Models;

public class WatchList
{
    public int Id { get; set; }
    public string UserId { get; set; } = string.Empty;
    public int MovieId { get; set; }
    public Movie Movie { get; set; } = null!;
}