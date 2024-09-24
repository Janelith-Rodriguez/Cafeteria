using AutoMapper;
using Cafeteria.BD.Data.Entity;
using Cafeteria.Shared.DTO;

namespace Cafeteria.Server.Util
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<CrearClienteDTO, Cliente>();
        }
    }
}
