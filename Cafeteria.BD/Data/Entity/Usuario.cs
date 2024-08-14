using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafeteria.BD.Data.Entity
{
    public class Usuario : EntityBase
    {
        public string Nombre { get; set; }
        public string Rol { get; set; }
         public string Email { get; set; }
        public string Password {  get; set; }
    }
}
