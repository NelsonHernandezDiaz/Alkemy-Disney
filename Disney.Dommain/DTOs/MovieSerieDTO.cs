using Disney.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disney.Domain.DTOs
{
    public class MovieSerieDTO
    {        
        public string URLImage { get; set; }
        public string Name { get; set; }    
        public DateTime ReleaseDate { get; set; }
        public eRating Rating { get; set; }
        public virtual CharacterDTO associatedCharacter { get; set; }
        public bool Status { get; set; }
    }
}
