using MovieLibraryApi.Models;

namespace MovieLibraryApi.Services;

public interface IMovieService
{
    Task<List<Movie>> GetAllAsync(string? search);
    Task<Movie?> GetByIdAsync(int id);
    Task<Movie> CreateAsync(Movie movie);
    Task<bool> UpdateAsync(int id, Movie updated);
    Task<bool> DeleteAsync(int id);
}