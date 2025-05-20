using RestAPI.Models.DTOs;
using RestAPI.Models.Entity;

namespace RestAPI.Models.DTOs.UserDto
{
    public class UsuarioDTO
    {
       public string Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Rol { get; set; }
        public string TipoAutenticacion { get; set; }



    }
}
