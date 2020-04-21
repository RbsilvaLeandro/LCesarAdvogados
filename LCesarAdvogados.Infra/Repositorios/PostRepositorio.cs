using LCesarAdvogados.Dominio.Entidades;
using LCesarAdvogados.Dominio.Interfaces.Repositorios;
using LCesarAdvogados.Infra.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCesarAdvogados.Infra.Repositorios
{
    public class PostRepositorio : RepositorioBase<Posts>, IPostRepositorio
    {
        public IEnumerable<Posts> GetAllForDate()
        {
            return Db.Set<Posts>().ToList().OrderByDescending(p => p.DataCadastro);
        }
    }
}
