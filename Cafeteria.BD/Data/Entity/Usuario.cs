using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafeteria.BD.Data.Entity
{
    [Index(nameof(Nombre), Name = "Usuario_UQ", IsUnique = true)]
    public class Usuario : EntityBase
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [MaxLength(100, ErrorMessage = "Maximo numero de caracteres{1}.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El rol es obligatorio.")]
        [MaxLength(100, ErrorMessage = "Maximo numero de caracteres{1}.")]
        public string Rol { get; set; }

        [Required(ErrorMessage = "El email es obligatorio.")]
        [MaxLength(100, ErrorMessage = "Maximo numero de caracteres{1}.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El password es obligatorio.")]
        [MaxLength(12, ErrorMessage = "Maximo numero de caracteres{1}.")]
        public string Password {  get; set; }
    }
}
