using Microsoft.AspNetCore.Mvc;
using Cafeteria.BD.Data.Entity;
using Cafeteria.BD.Data;
using Microsoft.EntityFrameworkCore;
using Cafeteria.Shared.DTO;
using AutoMapper;

namespace Cafeteria.Server.Controllers
{
    [ApiController]
    [Route("api/Clientes")]
    public class ClientesControllers
    {
        private readonly Context context;
        public readonly IMaper maper;
        private object entidad;

        public ClientesControllers(Context context, 
                                   IMaper maper)
        {
            this.context = context;
            this.maper = maper;
        }

        [HttpGet] //api/Clientes
        public async Task<ActionResult<List<Cliente>>> Get()
        {
            return await context.Clientes.ToListAsync();
        }

        [HttpGet("{id:int}")] //api/Clientes2
        public async Task<ActionResult<Cliente>> Get(int id)
        {
            Cliente? rocio = await context.Clientes.FirstOrDefaultAsync(x => x.Id == id);
            if (rocio == null)
            {
                return NotFound();
            }
            return rocio;
        }

        [HttpGet("GetByFech{fech}")] //api/Clientes/GetByFech/Año-Mes-Dia
        public async Task<ActionResult<Cliente>> GetByFecha(DateTime fech)
        {
            Cliente? rocio = await context.Clientes
                              .FirstOrDefaultAsync(x => x.Fecha == fech);
            if (rocio == null)
            {
                return NotFound();
            }
            return rocio;
        }

        private ActionResult<Cliente> NotFound()
        {
            throw new NotImplementedException();
        }

        [HttpGet("existe/{id:int}")] //api/Clientes/existe/2
        public async Task<ActionResult<bool>> Existe(int id)
        {
            var existe = await context.Clientes.AnyAsync(x => x.Id == id);
            return existe;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearClienteDTO entidadDTO)
        {
            try
            {
                var rocio = maper.Map<Cliente>(entidad);
                //Cliente rocio = new Cliente()
                //{
                //   Nombre= entidadDTO.Nombre,
                //   Apelido= entidadDTO.Apellido
                //};
                context.Clientes.Add(rocio);
                await context.SaveChangesAsync();
                return rocio.Id;
            }
            catch (Exception err)
            {
                return BadRequest(err.InnerException.Message);
            }
        }

        [HttpPut("{Id:int}")] //api/Clientes2
        public async Task<ActionResult> Put(int id, [FromBody] Cliente entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos incorrectos");
            }
            var rocio = await context.Clientes
                                  .Where(reg => reg.Id == id)
                                  .FirstOrDefaultAsync();
            if (rocio == null)
            {
                return NotFound("No existe la Cliente buscado");
            }

            rocio.Nombre = entidad.Nombre;
            rocio.Apelllido = entidad.Apellido;
            rocio.Email = entidad.Email;
            rocio.Telefono = entidad.Telefono;
            rocio.Direccion = entidad.Direccion;
            rocio.Activo = entidad.Activo;
            try
            {
                context.Clientes.Update(rocio);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        private ActionResult NotFound(string v)
        {
            throw new NotImplementedException();
        }

        private ActionResult BadRequest(string v)
        {
            throw new NotImplementedException();
        }

        private ActionResult Ok()
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id:int}")] //api/Clientes2
        public async Task<ActionResult> Delate(int id)
        {
            var existe = await context.Clientes.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound($"La oreden {id} no existe");
            }
            Cliente EntidadABorrar = new Cliente();
            EntidadABorrar.Id = id;

            context.Remove(EntidadABorrar);
            await context.SaveChangesAsync();
            return Ok();

        }
    }
}
