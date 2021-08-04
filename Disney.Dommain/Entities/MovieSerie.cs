using Disney.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Disney.Domain.Entities
{
    public class MovieSerie : EntityBase
    {
        [Required(ErrorMessage = "Ingrese una imagen valida")]
        [Url]
        [Column(TypeName = "VARCHAR")]
        public string URLImage { get; set; }

        [Required(ErrorMessage = "Nombre de la pelicula/serie requerido")]
        [Column(TypeName = "VARCHAR (500)")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Fecha de publicacion requerido")]
        [Column(TypeName = "DATE")]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = "Puntuacion requerida")]
        [Column(TypeName = "ENUM(1, 2, 3, 4, 5)")]
        public eRating Rating { get; set; }
        public virtual Character associatedCharacter { get; set; }
        public bool Status { get; set; }
    }
}
