using MovieLibrary.Database.Models;

namespace MovieLibrary.Interfaces
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieDTO>> GetMoviesAsync();
        Task<MovieDTO> GetMovieAsync(int id);
        Task<MovieDTO> AddMovieAsync(MovieDTO movieDto);
        Task UpdateMovieAsync(int id, MovieDTO movieDto);
        Task DeleteMovieAsync(int id);
    }
}
