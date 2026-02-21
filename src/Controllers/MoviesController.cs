using Microsoft.AspNetCore.Mvc;
using MovieLibraryApi.Dtos;
using MovieLibraryApi.Models;
using MovieLibraryApi.Services;

namespace MovieLibraryApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MoviesController : ControllerBase
{
    private readonly IMovieService _service;

    public MoviesController(IMovieService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<MovieResponseDto>>> GetAll([FromQuery] string? search)
    {
        var movies = await _service.GetAllAsync(search);

        var dto = movies.Select(m => new MovieResponseDto
        {
            Id = m.Id,
            Title = m.Title,
            Description = m.Description,
            ReleaseDate = m.ReleaseDate
        }).ToList();

        return Ok(dto);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<MovieResponseDto>> GetById(int id)
    {
        var movie = await _service.GetByIdAsync(id);
        if (movie is null) return NotFound();

        return Ok(new MovieResponseDto
        {
            Id = movie.Id,
            Title = movie.Title,
            Description = movie.Description,
            ReleaseDate = movie.ReleaseDate
        });
    }

    [HttpPost]
    public async Task<ActionResult<MovieResponseDto>> Create(MovieCreateDto dto)
    {
        var entity = new Movie
        {
            Title = dto.Title,
            Description = dto.Description,
            ReleaseDate = dto.ReleaseDate
        };

        var created = await _service.CreateAsync(entity);

        var response = new MovieResponseDto
        {
            Id = created.Id,
            Title = created.Title,
            Description = created.Description,
            ReleaseDate = created.ReleaseDate
        };

        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, MovieUpdateDto dto)
    {
        var updated = new Movie
        {
            Title = dto.Title,
            Description = dto.Description,
            ReleaseDate = dto.ReleaseDate
        };

        var ok = await _service.UpdateAsync(id, updated);
        if (!ok) return NotFound();

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var ok = await _service.DeleteAsync(id);
        if (!ok) return NotFound();

        return NoContent();
    }
}