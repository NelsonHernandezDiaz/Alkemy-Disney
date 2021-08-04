using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Disney.Domain.Entities
{
    public class User : IdentityUser
    {
        [Required(ErrorMessage ="Nombre de usuario es necesario")]
        [StringLength(20, ErrorMessage ="Debe contener minimo 8 caracteres", MinimumLength =8)]
        [Column(TypeName ="VARCHAR (20)")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Correo electronico es necesario")]
        [StringLength(16, ErrorMessage = "Debe contener entre 5 y 10 caracteres", MinimumLength = 5)]
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "Debe ser un email valido")]
        [Column (TypeName ="VARCHAR")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Contraseña es requerida")]
        [StringLength(255, ErrorMessage = "Debe de tener minimo 8 caracteres", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }                
        public bool Status { get; set; }
    }
}
