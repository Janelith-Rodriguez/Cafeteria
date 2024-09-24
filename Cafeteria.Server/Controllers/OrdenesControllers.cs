using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cafeteria.BD.Data;
using Cafeteria.BD.Data.Entity;

namespace Cafeteria.Server.Controllers
{
    [ApiController]
    [Route("api/Ordenes")]
    public class OrdenesControllers : ControllerBase
    {
        private readonly Context context;

        public OrdenesControllers(Context context)
        {
            this.context = context;
        }

        [HttpGet] //api/Ordenes
        public async Task<ActionResult<List<Orden>>> Get()
        {
            return await context.Ordenes.ToListAsync();
        }

        [HttpGet("{id:int}")] //api/Ordenes2
        public async Task<ActionResult<Orden>> Get(int id)
        {
            Orden? rocio = await context.Ordenes
                              .FirstOrDefaultAsync(x => x.Id == id);
            if (rocio == null)
            {
                return NotFound();
            }
            return rocio;
        }

        [HttpGet("{fech}")] //api/Ordenes/Año-Mes-Dia
        public async Task<ActionResult<Orden>> GetByFecha(DateTime fech)
        {
            Orden? rocio = await context.Ordenes
                              .FirstOrDefaultAsync(x => x.Fecha == fech);
            if (rocio == null)
            {
                return NotFound();
            }
            return rocio;
        }

        [HttpGet("existe/{id:int}")] //api/Ordenes/existe/2
        public async Task<ActionResult<bool>> Existe(int id)
        {
            var existe = await context.Ordenes.AnyAsync(x => x.Id == id);
            return existe;           
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Orden entidad)
        {
            try
            {
                context.Ordenes.Add(entidad);
                await context.SaveChangesAsync();
                return entidad.Id;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }

        
        [HttpPut("{Id:int}")] //api/Ordenes2
        public async Task<ActionResult> Put(int id, [FromBody] Orden entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos incorrectos");
            }
            var rocio = await context.Ordenes
                                  .Where(reg => reg.Id == id)
                                  .FirstOrDefaultAsync();
            if (rocio == null)
            {
                return NotFound("No existe la orden buscado");
            }

            rocio.Fecha = entidad.Fecha;
            rocio.Detalles = entidad.Detalles;
            rocio.Total = entidad.Total;
            rocio.Activo = entidad.Activo;
            try
            {
                context.Ordenes.Update(rocio);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        
        [HttpDelete("{id:int}")] //api/Ordenes2
        public async Task<ActionResult> Delate(int id)
        {
            var existe = await context.Ordenes.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound($"La oreden {id} no existe");
            }
            Orden EntidadABorrar = new Orden();
            EntidadABorrar.Id = id;

            context.Remove(EntidadABorrar);
            await context.SaveChangesAsync();
            return Ok();

        }
    }
}
