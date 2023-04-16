using Microsoft.EntityFrameworkCore;
using Movie.API.Domain.Entities;
using Movie.API.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.API.Providers.DBContext
{
    public class MovieDBContext:DbContext
    {
        public MovieDBContext(DbContextOptions<MovieDBContext> options):base(options)
        {

        }
        public DbSet<Genre> genre { get; set; }
        public DbSet<Movie.API.Domain.Entities.Movie> movie { get; set; }
        public DbSet<SP_SearchMovie> sp_SearchMovie { get; set; }
        public DbSet<MovieGenreRelation> movieGenreRelation { get; set; }
    }
}
