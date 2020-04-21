using LCesarAdvogados.Dominio.Entidades;
using LCesarAdvogados.Dominio.Interfaces.Repositorios;
using LCesarAdvogados.Dominio.Interfaces.Servicos;

namespace LCesarAdvogados.Dominio.Servicos
{
    public class UsuarioServico : ServicoBase<Usuario>, IUsuarioServico
    {
        private IUsuarioRepositorio _UsuarioRepositorio;

        public UsuarioServico(IUsuarioRepositorio UsarioRepositorio)
            : base(UsarioRepositorio)
        {
            _UsuarioRepositorio = UsarioRepositorio;
        }

        public Usuario Login(Usuario usuario)
        {
            return _UsuarioRepositorio.Login(usuario);
        }
    }
}
