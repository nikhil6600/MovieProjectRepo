 using Movie.API.Domain.Entities;
using Movie.API.Domain.ViewModel;
using Movie.Web.Contracts.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace Movie.Web.Providers.Services
{
    public class MovieConsumeService : IMovieConsumeService
    {
        private readonly HttpClient _httpClient;

        public MovieConsumeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<AddMovieViewModle> AddMovie(AddMovieViewModle addMovieViewModle)
        {
            try
            {

                //var response = await _httpClient.PostAsJsonAsync<AddMovieViewModle>("api/Movie/AddMovie", addMovieViewModle);

                //var content = await response.Content.ReadAsStringAsync();
                //var model  = JsonSerializer.Deserialize<AddMovieViewModle>(content);
                _httpClient.DefaultRequestHeaders.Add("application-type", "REST");
                //var newJsonObj = JsonConvert.SerializeObject(addMovieViewModle);
                //StringContent stringContent=new StringContent(newJsonObj,System.Text.Encoding.UTF8,"application/json");
                //var response = await _httpClient.PostAsync("api/Movie/AddMovie", stringContent);
                var response = await _httpClient.PostAsJsonAsync<AddMovieViewModle>("api/Movie/AddMovie", addMovieViewModle);
                return addMovieViewModle;
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }

        public Task<MovieGenreRelation> AddMovieGenreRelation(MovieGenreRelation movie)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Genre>> GetGenres()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Genre[]>("api/Movie/GetGenres");
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public async Task<IEnumerable<API.Domain.Entities.Movie>> GetMovies()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<API.Domain.Entities.Movie[]>("api/Movie");
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public async Task<IEnumerable<SP_SearchMovie>> SearchMovies(string? SearchMovies)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<SP_SearchMovie[]>($"api/Movie/{SearchMovies}");
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
