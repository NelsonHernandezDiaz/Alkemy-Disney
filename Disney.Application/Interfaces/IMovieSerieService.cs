using Disney.Domain.Common;
using Disney.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disney.Application.Interfaces
{
    public interface IMovieSerieService
    {
        Task<IEnumerable<MovieSerieDTO>> GetAllMoviesSeries();
        MovieSerieDTO GetMovieSerieByName(string name);
        Task<IEnumerable<MovieSerieDTO>> GetMovieSerieByGenre(string genre);
        Task<IEnumerable<MovieSerieDTO>> GetMovieSerieByOrder();
        Result CreateMovieSerie(MovieSerieDTO request);
        Result UpdateMovieSerie(MovieSerieDTO request);
        Result DeleteMovieSerie(MovieSerieDTO request);
    }
}
