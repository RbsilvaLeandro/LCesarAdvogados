using LCesarAdvogados.Dominio.Entidades;
using System.Collections.Generic;

namespace LCesarAdvogados.Dominio.Interfaces.Repositorios
{
    public interface IPostRepositorio : IRepositorioBase<Posts>
    {
        IEnumerable<Posts> GetAllForDate();  
    }
}
