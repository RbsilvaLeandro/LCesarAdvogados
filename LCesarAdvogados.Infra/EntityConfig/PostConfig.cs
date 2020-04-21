using LCesarAdvogados.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCesarAdvogados.Infra.EntityConfig
{
    public class PostConfig : EntityTypeConfiguration<Posts>
    {
        public PostConfig()
        {        
            HasKey(p => p.IdPost);
            Property(p => p.TituloPost).IsRequired().HasMaxLength(100);
            Property(p => p.ResumoPost).IsRequired().HasMaxLength(200);
            Property(p => p.ConteudoPost).IsMaxLength();
            Property(p => p.DataCadastro).IsRequired();
            Property(p => p.Status).IsRequired();   
     
        }
    }
}
