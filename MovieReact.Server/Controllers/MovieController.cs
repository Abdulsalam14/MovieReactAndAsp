using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieReact.Server.Entities;
using MovieReact.Server.Repositories;

namespace MovieReact.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;

        public MovieController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }


        [HttpGet("{id}", Name = "GetMovieById")]
        public async Task<IActionResult> Get(int id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }

        [HttpGet(Name = "GetMovies")]
        public async Task<IEnumerable<Movie>> Get()
        {
            var movies= await _movieRepository.GetMoviesAsync();
            return movies;
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _movieRepository.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost(Name = "AddMovie")]
        public async Task<IActionResult> Post([FromBody] Movie movie)
        {
            if (movie == null)
            {
                return BadRequest("Movie object is null");
            }

            try
            {
                await _movieRepository.AddAsync(movie);
                return CreatedAtRoute("GetMovieById", new { id = movie.Id }, movie);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
