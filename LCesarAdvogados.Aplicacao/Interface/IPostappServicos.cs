using System;
using LCesarAdvogados.Dominio.Entidades;
using System.Collections.Generic;

namespace LCesarAdvogados.Aplicacao.Interface
{
    public interface IPostAppServicos : IAppServicoBase<Posts>
    {
        IEnumerable<Posts> GetAllForDate();
    }
}
