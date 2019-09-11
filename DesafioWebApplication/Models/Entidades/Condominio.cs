using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioWebApplication.Models.Entidades
{
    [Table("Condominio", Schema = "dbo")]
    public class CondominioEntity
    {
        [Key]
        public int Id { get; set; }
        public string NomeAdministrador { get; set; }
        public string Administrador { get; set; }
        public string Responsavel { get; set; }

    }
}