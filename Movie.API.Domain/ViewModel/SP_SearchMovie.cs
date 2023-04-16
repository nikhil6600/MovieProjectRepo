using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.API.Domain.ViewModel
{
    public class SP_SearchMovie
    {
        [Key]
        public int MovieId { get; set; }
        public string MovieTitle { get; set; }
        public string ReleasYear { get; set; }
        public string? PhotoPath { get; set; }
        public string GenreTitle { get; set; }
    }
}
