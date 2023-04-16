using Microsoft.AspNetCore.Http;
using Movie.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.API.Domain.ViewModel
{
    public class AddMovieViewModle
    {
        public MovieGenreRelation movieGenreRelation { get; set; } = new();
        public Movie.API.Domain.Entities.Movie movie { get; set; }
        public Genre genre { get; set; }=new();
        public IEnumerable<Genre> genreList { get; set; }
    }
}
