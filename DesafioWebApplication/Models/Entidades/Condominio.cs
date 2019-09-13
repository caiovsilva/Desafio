using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioWebApplication.Models.Entidades
{
    [Table("Condominio", Schema = "dbo")]
    public class CondominioEntity
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nome Condomínio")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string NomeCondominio { get; set; }

        [Display(Name = "Administradora")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Administradora { get; set; }

        [Display(Name = "Responsável")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Responsavel { get; set; }

    }
}