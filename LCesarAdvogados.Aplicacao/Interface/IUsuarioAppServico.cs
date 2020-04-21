using LCesarAdvogados.Dominio.Entidades;

namespace LCesarAdvogados.Aplicacao.Interface
{
    public interface IUsuarioAppServico : IAppServicoBase<Usuario>
    {
        Usuario Login(Usuario usuario);
    }
}
