using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieLibrary.Database.Context;
using MovieLibrary.Database.Entities;
using MovieLibrary.Database.Models;
using MovieLibrary.Interfaces;

namespace MovieLibrary.Services
{
    public class MovieService : IMovieService
    {
        private readonly MovieLibraryContext _context;
        private readonly IMapper _mapper;

        public MovieService(MovieLibraryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        async public Task<IEnumerable<MovieDTO>> GetMoviesAsync()
        {
            var movies = await _context.Movies.ToListAsync();
            return _mapper.Map<IEnumerable<MovieDTO>>(movies);
        }

        async public Task<MovieDTO> GetMovieAsync(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            return _mapper.Map<MovieDTO>(movie);
        }

        async public Task<MovieDTO> AddMovieAsync(MovieDTO movieDto)
        {
            var movie = _mapper.Map<Movie>(movieDto);
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
            return _mapper.Map<MovieDTO>(movie);
        }

        async public Task UpdateMovieAsync(int id, MovieDTO movieDto)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                throw new InvalidOperationException("Movie wasn't not found");
            }
            _mapper.Map(movieDto, movie);
            await _context.SaveChangesAsync();
        }

        async public Task DeleteMovieAsync(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                throw new InvalidOperationException("Movie wasn't not found");
            }

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
        }
    }
}
