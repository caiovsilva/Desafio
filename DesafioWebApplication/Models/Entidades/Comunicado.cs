using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioWebApplication.Models.Entidades
{
    [Table("Comunicado", Schema = "dbo")]
    public class ComunicadoEntity
    {
        [Key]
        public int Id { get; set; }
        public string NomeUsuario { get; set; }
        public string TipoAssunto { get; set; }
        public string Destinatario { get; set; }
        public string TextoComunicado { get; set; }
        public DateTime DataHoraEnvio { get; set; }
    }
}