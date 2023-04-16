using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie.API.Contracts.Interfaces;
using Movie.API.Domain.Entities;
using Movie.API.Domain.ViewModel;

namespace Movie.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        [HttpGet]  
        public async Task<ActionResult> GetMovies()
        {
            try
            {
                return Ok(await _movieService.GetMovies());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
        [HttpGet("{SearchMovies}")]
        public async Task<ActionResult<IEnumerable<SP_SearchMovie>>>SearchMovies(string? SearchMovies) 
        {
            try
            {
                var result = await _movieService.SearchMovies(SearchMovies);
                if (result.Any())
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
        [Route("[action]")]
        [HttpPost]
        public async Task<ActionResult> AddMovie(AddMovieViewModle model)
        {
            try
            {
                if (model==null)
                {
                    return BadRequest("Employee is null");
                }

                //return await _movieService.AddMovie(model);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while adding movie data from the database");
            }
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<ActionResult> GetGenres()
        {
            try
            {
                return Ok(await _movieService.GetGenres());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
    }
}
