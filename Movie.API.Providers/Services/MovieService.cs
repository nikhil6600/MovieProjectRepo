using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Movie.API.Contracts.Interfaces;
using Movie.API.Domain.Entities;
using Movie.API.Domain.ViewModel;
using Movie.API.Providers.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Movie.API.Providers.Services
{
    public class MovieService : IMovieService
    {
        private readonly MovieDBContext _movieDBContext;   
        public MovieService(MovieDBContext movieDBContext)
        {
            _movieDBContext = movieDBContext;   
        }

        public async Task<AddMovieViewModle> AddMovie(AddMovieViewModle viewModle)
        {
            try
            {
               
                await _movieDBContext.movie.AddAsync(viewModle.movie);
                var result=await _movieDBContext.SaveChangesAsync();

                //returnModle.movie = (await _movieDBContext.movie.AddAsync(viewModle.movie)).Entity;
                viewModle.movieGenreRelation.movieId = viewModle.movie.Id;
                
                await AddMovieGenreRelation(viewModle.movieGenreRelation);
                //returnModle.movieGenreRelation = (await AddMovieGenreRelation(viewModle.movieGenreRelation));
                return viewModle;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<MovieGenreRelation> AddMovieGenreRelation(MovieGenreRelation movieGenreRelation)
        {
            try
            {
                var result = await _movieDBContext.movieGenreRelation.AddAsync(movieGenreRelation);
                await _movieDBContext.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Domain.Entities.Movie>> GetMovies()
        {
            try
            {
                return await _movieDBContext.movie.ToListAsync(); 
            }
            catch (Exception ex) 
            {

                throw;
            }
        }
        public async Task<IEnumerable<SP_SearchMovie>> SearchMovies(string? SearchMovies)
        {
            try
            {
                if (string.IsNullOrEmpty(SearchMovies))
                {
                    SearchMovies = "";
                }
                List<SqlParameter>parameter = new List<SqlParameter>{
                    new SqlParameter{ParameterName="@SearchMovies",Value=SearchMovies}
                };
                var result = _movieDBContext.sp_SearchMovie.FromSqlRaw("SP_SearchMovie @SearchMovies", parameter.ToArray());
                return await result.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        public async Task<IEnumerable<Genre>> GetGenres()
        {
            try
            {
                return await _movieDBContext.genre.ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
