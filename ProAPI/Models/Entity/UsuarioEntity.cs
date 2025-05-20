using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace RestAPI.Models.Entity
{
    public class UsuarioEntity
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Rol { get; set; }

        [Required]
        public string TipoAutenticacion { get; set; }

        public ICollection<ReservaEntity> Reservas { get; set; }
    }
}
