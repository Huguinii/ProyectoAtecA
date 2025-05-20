using RestAPI.Models.DTOs.UserDto;
using RestAPI.Models.Entity;

namespace RestAPI.Repository.IRepository
{
    public interface IUsuarioRepository
    {
        Task<UsuarioEntity?> GetByEmailAsync(string email);
        Task<bool> ExistsAsync(string id);
        Task<bool> CreateAsync(UsuarioEntity usuario);
        Task<ICollection<UsuarioEntity>> GetAllAsync();
    }
}
