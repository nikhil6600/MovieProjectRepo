using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.API.Domain.Entities
{
    public class MovieGenreRelation
    {
        [Key]
        public int Id { get; set; }
        public int movieId { get; set; }
        public int genreId { get; set; }
    }
}
