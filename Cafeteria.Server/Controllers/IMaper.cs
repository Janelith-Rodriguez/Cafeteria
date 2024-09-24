namespace Cafeteria.Server.Controllers
{
    public interface IMaper
    {
        T Map<T>(object entidad);
    }
}