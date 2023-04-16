using Movie.API.Domain.ViewModel;

namespace Movie.Web.Models
{
    public class MovieViewModel
    {
        public IEnumerable<Movie.API.Domain.Entities.Movie> movies { get; set; }
        public IEnumerable<SP_SearchMovie> searchMovie { get; set; }
    }
}
