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
    public class GenreService : IGenreService
    {
        #region Obj and Constructor
        private readonly IGenreRepository IgenreRepository;
        private readonly IMapper mapper;
        public GenreService(IMapper mapper, IGenreRepository IgenreRepository)
        {
            this.IgenreRepository = IgenreRepository;
            this.mapper = mapper;
        }
        #endregion

        public async Task<IEnumerable<GenreDTO>> GetAllGenres()
        {
            var result = await IgenreRepository.GetAllGenres();
            var response = mapper.Map<IEnumerable<GenreDTO>>(result);

            return response;
        }
        public Result CreateGenre(GenreDTO request)
        {
            bool exists = IgenreRepository.GenreExists(request.Name);
            if (exists)
                return new Result().Fail("Ya Existe un Registro de este Genre");

            var entity = mapper.Map<Genre>(request);

            return new Result().Success($"Se ha agregado correctamente la Genre {entity.Name} al sistema");
        }
        public Result UpdateGenre(GenreDTO request)
        {
            var update = IgenreRepository.GenreExists(request.Name);
            if (update == null)
                return new Result().NotFound();

            var entity = mapper.Map<Genre>(request);
            IgenreRepository.UpdateGenre(entity);

            return new Result().Success($"Se han aplicado los cambios correctamente al Genre {entity.Name}");
        }
        public Result DeleteGenre(GenreDTO request)
        {
            Genre delete = IgenreRepository.GetGenreByName(request.Name);
            if (delete == null)
                return new Result().NotFound();

            request.Status = true;
            var entity = mapper.Map<Genre>(delete);

            IgenreRepository.UpdateGenre(entity);
            return new Result().Success($"Se eliminó el Genre {entity.Name}");
        }        
    }
}
