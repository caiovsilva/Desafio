using DesafioEntidades.Entidades;
using System.Data.Entity;

namespace DesafioEntidades
{
    public class ContextApi : DbContext
    {
        public ContextApi() : base("name=ContextApi")
        {
        }

        public DbSet<CondominioEntity> Condominios { get; set; }
        public DbSet<UsuarioEntity> Usuarios { get; set; }
    }
}
