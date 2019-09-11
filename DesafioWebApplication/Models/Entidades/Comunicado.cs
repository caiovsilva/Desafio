using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioWebApplication.Models.Entidades
{
    [Table("Comunicado", Schema = "dbo")]
    public class ComunicadoEntity
    {
        [Key]
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdAssunto { get; set; }
        public string TextoComunicado { get; set; }
    }
}