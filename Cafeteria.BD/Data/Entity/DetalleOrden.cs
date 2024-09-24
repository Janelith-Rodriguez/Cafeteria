using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Cafeteria.BD.Data.Entity
{
    [Index(nameof(Cantidad), Name = "DetalleOrden_UQ", IsUnique = true)]
    public class DetalleOrden : EntityBase
    {
        public int OrdenId { get; set; }

        [Required(ErrorMessage = "La orden es obligatorio.")]
        [MaxLength(50, ErrorMessage = "Maximo numero de caracteres{1}.")]
        public Orden? Orden { get; set; }
        public int ProductoId { get; set; }

        [Required(ErrorMessage = "El producto es obligatorio.")]
        [MaxLength(50, ErrorMessage = "Maximo numero de caracteres{1}.")]
        public Producto? Producto { get; set; }

        [Required(ErrorMessage = "La cantidad es obligatorio.")]
        [MaxLength(20, ErrorMessage = "Maximo numero de caracteres{1}.")]
        public int Cantidad { get; set; }
    }
}
