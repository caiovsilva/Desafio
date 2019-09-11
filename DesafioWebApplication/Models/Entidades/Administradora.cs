using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioWebApplication.Models.Entidades
{
    [Table("Administradora", Schema = "dbo")]
    public class AdministradoraEntity
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nome Administradora")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string NomeAdministradora { get; set; }
    }
}