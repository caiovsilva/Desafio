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

        [Display(Name = "Nome Usuário")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string NomeUsuario { get; set; }

        [Display(Name = "Tipo do Assunto")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string TipoAssunto { get; set; }

        [Display(Name = "Destinatário")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Destinatario { get; set; }

        [Display(Name = "Comunicado")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string TextoComunicado { get; set; }

        public DateTime DataHoraEnvio { get; set; }
    }
}