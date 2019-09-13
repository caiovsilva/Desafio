using DesafioWebApplication.Models.Entidades;
using System.Data.Entity;

namespace DesafioWebApplication.Models
{
    public class ContextApi : DbContext
    {
        public ContextApi() : base("name=ContextApi")
        {
        }

        public DbSet<CondominioEntity> Condominios { get; set; }
        public DbSet<UsuarioEntity> Usuarios { get; set; }
        public DbSet<AssuntoEntity> AssuntoEntities { get; set; }
        public DbSet<AdministradoraEntity> AdministradoraEntities { get; set; }
        public DbSet<ComunicadoEntity> ComunicadoEntities { get; set; }
    }
}