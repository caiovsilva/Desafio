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

        public System.Data.Entity.DbSet<DesafioWebApplication.Models.Entidades.AssuntoEntity> AssuntoEntities { get; set; }

        public System.Data.Entity.DbSet<DesafioWebApplication.Models.Entidades.AdministradoraEntity> AdministradoraEntities { get; set; }
    }
}