using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.API.Domain.Entities
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Title must not be empty.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Release Year must not be empty.")]
        public string ReleasYear { get; set; }
        public DateTime CreatedDateTime { get; set ; }=DateTime.Now;
        public string PhotoPath { get; set; }

    }
}
