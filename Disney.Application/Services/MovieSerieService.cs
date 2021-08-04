using AutoMapper;
using Disney.Application.Interfaces;
using Disney.Domain.Common;
using Disney.Domain.DTOs;
using Disney.Domain.Entities;
using Disney.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disney.Application.Services
{
    public class MovieSerieService : IMovieSerieService
    {
        #region Obj and Constructor
        private readonly IMovieSerieRepository ImovieSerieRepository;
        private readonly IMapper mapper;
        public MovieSerieService(IMapper mapper, IMovieSerieRepository ImovieSerieRepository)
        {
            this.ImovieSerieRepository = ImovieSerieRepository;
            this.mapper = mapper;
        }
        #endregion

        public async Task<IEnumerable<MovieSerieDTO>> GetAllMoviesSeries()
        {
            var result = await ImovieSerieRepository.GetAllMoviesSeries();
            var response = mapper.Map<IEnumerable<MovieSerieDTO>>(result);

            return response;
        }
        public MovieSerieDTO GetMovieSerieByName(string name)
        {
            var entity = ImovieSerieRepository.GetMovieSerieByName(name);
            var response = mapper.Map<MovieSerieDTO>(entity);

            return response;
        }
        public async Task<IEnumerable<MovieSerieDTO>> GetMovieSerieByGenre(string genre)
        {
            var result = await ImovieSerieRepository.GetMovieSerieByGenre(genre);
            var response = mapper.Map<IEnumerable<MovieSerieDTO>>(result);

            return response;
        }
        public async Task<IEnumerable<MovieSerieDTO>> GetMovieSerieByOrder()
        {
            var result = await ImovieSerieRepository.GetMovieSerieByOrder();
            var response = mapper.Map<IEnumerable<MovieSerieDTO>>(result);

            return response;
        }
        public Result CreateMovieSerie(MovieSerieDTO request)
        {
            bool exists = ImovieSerieRepository.MovieSerieExists(request.Name);
            if (exists)
                return new Result().Fail("Ya Existe un Registro de esta Movie/Serie");

            var entity = mapper.Map<MovieSerie>(request);
            ImovieSerieRepository.CreateMovieSerie(entity);

            return new Result().Success($"Se ha agregado correctamente la Movie/Serie {entity.Name} al sistema");
        }
        public Result UpdateMovieSerie(MovieSerieDTO request)
        {
            var update = ImovieSerieRepository.MovieSerieExists(request.Name);
            if (update == null)
                return new Result().NotFound();

            var entity = mapper.Map<MovieSerie>(request);
            ImovieSerieRepository.UpdateMovieSerie(entity);

            return new Result().Success($"Se han aplicado los cambios correctamente a la Movie/Serie {entity.Name}");

        }
        public Result DeleteMovieSerie(MovieSerieDTO request)
        {
            MovieSerie delete = ImovieSerieRepository.GetMovieSerieByName(request.Name);
            if (delete == null)
                return new Result().NotFound();

            request.Status = false;
            var entity = mapper.Map<MovieSerie>(delete);

            ImovieSerieRepository.UpdateMovieSerie(entity);
            return new Result().Success($"Se eliminó la Movie/Serie {entity.Name}");
        }
    }
}
