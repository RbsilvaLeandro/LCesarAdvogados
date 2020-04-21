using LCesarAdvogados.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCesarAdvogados.Dominio.Interfaces.Servicos
{
    public interface IPostServico : IServicoBase<Posts>
    {
        IEnumerable<Posts> GetAllForDate();
    }
}
