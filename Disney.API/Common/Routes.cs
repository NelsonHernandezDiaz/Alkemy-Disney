using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Disney.API.Common
{
    public static class Routes
    {
        public const string Root = "Alkemy";
        public const string Version = "Disney";
        public const string Base = Root + "/" + Version;

        #region Characters
        public static class Character
        {
            public const string GetAllCharacters = Base + "/characters";
            public const string GetCharacterByName = Base + "/characters?name=nombre";
            public const string GetCharacterByAge = Base + "/characters?age=edad";
            public const string GetCharacterByMovieSerie = Base + "/characters?movies=idMovie";
            public const string CreateCharacter = Base + "/create-Character";
            public const string UpdateCharacter = Base + "/create-Character";
            public const string DeleteCharacter = Base + "/delete-Character";
        }
        #endregion

        #region MoviesSeries
        public static class Genre
        {
            public const string GetAllGenres = Base + "/genres";
            public const string CreateGenre = Base + "/create-Genre";
            public const string UpdateGenre = Base + "/create-Genre";
            public const string DeleteGenre = Base + "/delete-Genre";
        }
        #endregion

        #region MoviesSeries
        public static class MovieSerie
        {
            public const string GetAllMoviesSeries = Base + "/moviess";
            public const string GetMovieSerieByName = Base + "/movies?name=nombre";
            public const string GetMovieSerieByGenre = Base + "/movies?genre=idGenero";
            public const string GetMovieSerieByOrder = Base + "/movies?order=ASC | DESC";
            public const string CreateMovieSerie = Base + "/create-MoviesSerie";
            public const string UpdateMovieSerie = Base + "/create-MoviesSerie";
            public const string DeleteMovieSerie = Base + "/delete-MoviesSerie";
        }
        #endregion

        #region Users
        public static class User
        {
            public const string GetAllUsers = Base + "/users";
            public const string Login = Base + "/Auth/login";
            public const string Register = Base + "/Auth/register";
            public const string Delete = Base + "/delete-User";
            public const string SendMail = Base + "/SendMail";
        }
        #endregion
    }
}