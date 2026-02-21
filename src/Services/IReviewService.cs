using MovieLibraryApi.Models;

namespace MovieLibraryApi.Services;

public interface IReviewService
{
    Task<List<Review>> GetAllAsync(int? movieId);
    Task<Review?> GetByIdAsync(int id);
    Task<Review?> CreateAsync(Review review);   // null om MovieId ej finns
    Task<bool> UpdateAsync(int id, Review updated);
    Task<bool> DeleteAsync(int id);
}