using Microsoft.AspNetCore.Mvc;
using Movie.API.Domain.ViewModel;
using Movie.Web.Contracts.Interfaces;
using Movie.Web.Models;
using System.Net.WebSockets;

namespace Movie.Web.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieConsumeService _movieConsumeService;

        public MovieController(IMovieConsumeService movieConsumeService)
        {
            _movieConsumeService = movieConsumeService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                MovieViewModel model = new MovieViewModel();
                var result = (await _movieConsumeService.GetMovies()).ToList();
                model.movies = result;
                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet]
        public async Task<IActionResult> Search(string? SearchMovies)
        {
            try
            {
                MovieViewModel model = new MovieViewModel();
                var result = (await _movieConsumeService.SearchMovies(SearchMovies)).ToList();
                model.searchMovie = result;
                return PartialView("_Search", model);
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpGet]
        public async Task<IActionResult> AddMovie()
        {
            try
            {
                AddMovieViewModle model = new AddMovieViewModle();
                var result= (await _movieConsumeService.GetGenres()).ToList();
                model.genreList= result.AsEnumerable();  
                return View(model);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddMovie(AddMovieViewModle model)
        {
            try
            {
                model.movieGenreRelation.genreId = model.genre.Id;
                var result=await _movieConsumeService.AddMovie(model);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
