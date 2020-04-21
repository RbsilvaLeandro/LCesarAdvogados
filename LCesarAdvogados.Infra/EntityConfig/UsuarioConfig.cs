
using LCesarAdvogados.Dominio.Entidades;
using System.Data.Entity.ModelConfiguration;
namespace LCesarAdvogados.Infra.EntityConfig
{
    public class UsuarioConfig : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfig()
        {        
            HasKey(c => c.IdUsuario);
            Property(c => c.Nome).IsRequired().HasMaxLength(50);
            Property(c => c.Login).IsRequired().HasMaxLength(20);
            Property(c => c.Senha).IsRequired().HasMaxLength(15);
            Property(c => c.Email).IsRequired();
            Property(c => c.Status).IsRequired();
        }
    }
}
