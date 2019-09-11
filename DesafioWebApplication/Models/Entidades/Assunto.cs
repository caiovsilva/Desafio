using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioWebApplication.Models.Entidades
{
    [Table("Assunto", Schema = "dbo")]
    public class AssuntoEntity
    {
        [Key]
        public int Id { get; set; }
        public string TipoAssunto { get; set; }
    }
}