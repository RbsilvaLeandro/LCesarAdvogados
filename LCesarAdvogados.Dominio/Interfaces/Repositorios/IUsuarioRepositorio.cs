using LCesarAdvogados.Dominio.Entidades;

namespace LCesarAdvogados.Dominio.Interfaces.Repositorios
{
    public interface IUsuarioRepositorio : IRepositorioBase<Usuario>
    {
        Usuario Login(Usuario usuario);
    }
}