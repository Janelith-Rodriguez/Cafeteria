using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafeteria.BD.Data.Entity
{
    [Index(nameof(UsuarioId), nameof (Fecha), Name = "Orden_UQ", IsUnique = true)]
    [Index(nameof(Detalles), nameof(Total), Name = "Orden_Detalles_Total", IsUnique = false)]
    public class Orden : EntityBase
    {
        [Required(ErrorMessage = "La fecha es obligatorio.")]
        [MaxLength(12, ErrorMessage = "Maximo numero de caracteres{1}.")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Los detalles son obligatorios.")]
        [MaxLength(150, ErrorMessage = "Maximo numero de caracteres{1}.")]
        public string Detalles { get; set; }

        [Required(ErrorMessage = "El total es obligatorio.")]
        [MaxLength(20, ErrorMessage = "Maximo numero de caracteres{1}.")]
        public decimal Total { get; set; }

        [Required(ErrorMessage = "El usuario es obligatorio.")]
        [MaxLength(150, ErrorMessage = "Maximo numero de caracteres{1}.")]
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }
        public List<Orden> Ordenes { get; set; }
    }
}
