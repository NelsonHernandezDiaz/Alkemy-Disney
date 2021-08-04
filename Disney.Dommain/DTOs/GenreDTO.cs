using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disney.Domain.DTOs
{
    public class GenreDTO 
    {
        public string URLImage { get; set; }
        public string Name { get; set; }
        public virtual MovieSerieDTO associatedMovieSerie { get; set; }
        public bool Status { get; set; }
    }
}
