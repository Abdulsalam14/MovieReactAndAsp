using Microsoft.EntityFrameworkCore;
using MovieReact.Server.Data;
using MovieReact.Server.Entities;

namespace MovieReact.Server.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieContext _context;

        public MovieRepository(MovieContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Movie movie)
        {
            await _context.AddAsync(movie);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var movie = await _context.Movies.FirstOrDefaultAsync(x => x.Id == id);
            if (movie != null)
            {
                _context.Remove(movie);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Movie> GetByIdAsync(int id)
        {
            return await _context.Movies.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Movie>> GetMoviesAsync()
        {
            return await _context.Movies.ToListAsync();
        }
    }
}
