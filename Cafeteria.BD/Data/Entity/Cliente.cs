using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafeteria.BD.Data.Entity
{
    [Index(nameof(Nombre), Name = "Cliente_UQ", IsUnique = true)]
    public class Cliente
    {
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [MaxLength(50, ErrorMessage = "Maximo numero de caracteres{1}.")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        [MaxLength(20, ErrorMessage = "Maximo numero de caracteres{1}.")]
        public string? Apelido { get; set; }

        [Required(ErrorMessage = "El email es obligatorio.")]
        [MaxLength(100, ErrorMessage = "Maximo numero de caracteres{1}.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "El telefono es obligatorio.")]
        [MaxLength(15, ErrorMessage = "Maximo numero de caracteres{1}.")]
        public string? Telefono { get; set; }

        [Required(ErrorMessage = "La direccion es obligatorio.")]
        [MaxLength(100, ErrorMessage = "Maximo numero de caracteres{1}.")]
        public string? Direccion { get; set; }      
        public List<Cliente> Clientes { get; set; }
        public DateTime Fecha { get; set; }
        public int Id { get; set; }
        public object Apellido { get; set; }
        public object Apelllido { get; set; }
        public object Activo { get; set; }
    }
}
