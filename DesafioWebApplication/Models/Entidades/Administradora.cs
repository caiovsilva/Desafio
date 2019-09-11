using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioWebApplication.Models.Entidades
{
    [Table("Administradora", Schema = "dbo")]
    public class AdministradoraEntity
    {
        [Key]
        public int Id { get; set; }
        public string NomeAdministradora { get; set; }
    }
}