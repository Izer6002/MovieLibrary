using Microsoft.AspNetCore.Mvc;
using MovieLibrary.Database.Models;
using MovieLibrary.Interfaces;

namespace MovieLibrary.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDTO>>> GetMoviesAsync()
        {
            var movies = await _movieService.GetMoviesAsync();
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDTO>> GetMovieAsync(int id)
        {
            var movie = await _movieService.GetMovieAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }

        [HttpPost]
        public async Task<ActionResult<MovieDTO>> AddMovieAsync(MovieDTO movieDTO)
        {
            var movie = await _movieService.AddMovieAsync(movieDTO);
            return CreatedAtAction(nameof(GetMovieAsync), new { id = movie.Id }, movie);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovieAsync(int id, MovieDTO movieDTO)
        {
            if (id != movieDTO.Id)
            {
                return BadRequest();
            }

            var existingMovie = await _movieService.GetMovieAsync(id);
            if (existingMovie == null)
            {
                return NotFound();
            }

            await _movieService.UpdateMovieAsync(id,movieDTO);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovieAsync(int id)
        {
            var existingMovie = await _movieService.GetMovieAsync(id);
            if (existingMovie == null)
            {
                return NotFound();
            }

            await _movieService.DeleteMovieAsync(id);

            return NoContent();
        }
    }
}
