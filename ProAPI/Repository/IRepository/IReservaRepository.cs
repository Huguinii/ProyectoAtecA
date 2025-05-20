using RestAPI.Models.Entity;

namespace RestAPI.Repository.IRepository
{
    public interface IReservaRepository : IRepository<ReservaEntity>
    {
        Task<ICollection<ReservaEntity>> GetByProfesorAsync(string profesorId);
        Task<ICollection<ReservaEntity>> GetReservasPendientesAsync();
        Task<bool> ExisteReserva(DateTime fecha, TimeOnly inicio, TimeOnly fin);
    }
}
