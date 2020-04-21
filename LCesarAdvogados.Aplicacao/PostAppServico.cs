using LCesarAdvogados.Aplicacao.Interface;
using LCesarAdvogados.Dominio.Entidades;
using LCesarAdvogados.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCesarAdvogados.Aplicacao
{
    public class PostAppServico : AppServicoBase<Posts>, IPostAppServicos
    {
        private readonly IPostServico _postServico;
        public PostAppServico(IPostServico postServico)
            : base(postServico)
        {
            _postServico = postServico;
        }

        IEnumerable<Posts> IPostAppServicos.GetAllForDate()
        {
            return _postServico.GetAllForDate();
        }
    }



}
