using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafeteria.Shared.DTO
{
    public class CrearClienteDTO
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [MaxLength(50, ErrorMessage = "Maximo numero de caracteres{1}.")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        [MaxLength(20, ErrorMessage = "Maximo numero de caracteres{1}.")]
        public string? Apelido { get; set; }
        public string? Apellido { get; set; }
    }
}
