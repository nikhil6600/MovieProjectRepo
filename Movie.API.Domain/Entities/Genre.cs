using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.API.Domain.Entities
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Title must not be empty.")]
        public string Title { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
    
}
