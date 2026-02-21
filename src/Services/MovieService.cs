using Microsoft.EntityFrameworkCore;
using MovieLibraryApi.Data;
using MovieLibraryApi.Models;

namespace MovieLibraryApi.Services;

public class MovieService : IMovieService
{
    private readonly AppDbContext _db;

    public MovieService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<Movie>> GetAllAsync(string? search)
    {
        var query = _db.Movies.AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var s = search.Trim().ToLower();
            query = query.Where(m => m.Title.ToLower().Contains(s));
        }

        return await query
            .AsNoTracking()
            .OrderByDescending(m => m.ReleaseDate)
            .ToListAsync();
    }

    public async Task<Movie?> GetByIdAsync(int id)
    {
        return await _db.Movies
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<Movie> CreateAsync(Movie movie)
    {
        _db.Movies.Add(movie);
        await _db.SaveChangesAsync();
        return movie;
    }

    public async Task<bool> UpdateAsync(int id, Movie updated)
    {
        var existing = await _db.Movies.FirstOrDefaultAsync(m => m.Id == id);
        if (existing is null) return false;

        existing.Title = updated.Title;
        existing.Description = updated.Description;
        existing.ReleaseDate = updated.ReleaseDate;

        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existing = await _db.Movies.FirstOrDefaultAsync(m => m.Id == id);
        if (existing is null) return false;

        _db.Movies.Remove(existing);
        await _db.SaveChangesAsync();
        return true;
    }
}