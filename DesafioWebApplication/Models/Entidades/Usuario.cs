using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioWebApplication.Models.Entidades
{
    [Table("Usuario", Schema = "dbo")]
    public class UsuarioEntity
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Condominio { get; set; }
        public string TipoUsuario { get; set; }
    }
}