using Movie.API.Domain.Entities;
using Movie.API.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.API.Contracts.Interfaces
{
    public interface IMovieService
    {
        Task<IEnumerable<Movie.API.Domain.Entities.Movie>> GetMovies();
        Task<IEnumerable<SP_SearchMovie>> SearchMovies(string?SearchMovies);
        Task<IEnumerable<Genre>> GetGenres();
        Task<AddMovieViewModle> AddMovie(AddMovieViewModle addMovieViewModle);
        Task<MovieGenreRelation> AddMovieGenreRelation(MovieGenreRelation movie);

    }
}

