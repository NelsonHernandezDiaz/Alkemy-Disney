using Disney.Domain.Common;
using Disney.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disney.Application.Interfaces
{
    public interface IGenreService
    {
        Task<IEnumerable<GenreDTO>> GetAllGenres();
        Result CreateGenre(GenreDTO request);
        Result UpdateGenre(GenreDTO request);
        Result DeleteGenre(GenreDTO request);
    }
}
