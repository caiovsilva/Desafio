using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioWebApplication.Models.Entidades
{
    [Table("Usuario", Schema = "dbo")]
    public class UsuarioEntity
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Email { get; set; }

        [Display(Name = "Condomínio")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Condominio { get; set; }

        [Display(Name = "Tipo do Usuário")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string TipoUsuario { get; set; }
    }
}