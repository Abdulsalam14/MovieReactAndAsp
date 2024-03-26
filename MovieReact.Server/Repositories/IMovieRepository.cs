using MovieReact.Server.Entities;

namespace MovieReact.Server.Repositories
{
    public interface IMovieRepository
    {
        Task<List<Movie>> GetMoviesAsync();
        Task DeleteAsync(int id);
        Task AddAsync(Movie movie);
        Task<Movie> GetByIdAsync(int id);

    }
}
