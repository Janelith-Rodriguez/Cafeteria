using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafeteria.BD.Data.Entity
{
    [Index(nameof(Nombre), Name = "Producto_UQ", IsUnique = true)]
    public class Producto : EntityBase
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [MaxLength(100, ErrorMessage = "Maximo numero de caracteres{1}.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio.")]
        [MaxLength(50, ErrorMessage = "Maximo numero de caracteres{1}.")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "La cantidad es obligatorio.")]
        [MaxLength(50, ErrorMessage = "Maximo numero de caracteres{1}.")]
        public int Cantidad { get; set; }
        
    }
}
