using LCesarAdvogados.Dominio.Entidades;
using LCesarAdvogados.Dominio.Interfaces.Repositorios;
using LCesarAdvogados.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCesarAdvogados.Dominio.Servicos
{
    public class PostServico : ServicoBase<Posts>, IPostServico
    {
        private IPostRepositorio _PostRepositorio;

        public PostServico(IPostRepositorio PostRepositorio)
            : base(PostRepositorio)
        {
            _PostRepositorio = PostRepositorio;
        }

        public IEnumerable<Posts> GetAllForDate()
        {
            return _PostRepositorio.GetAllForDate();
        }        
    }
}
