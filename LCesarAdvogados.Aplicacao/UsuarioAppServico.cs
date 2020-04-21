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
    public class UsuarioAppServico : AppServicoBase<Usuario>, IUsuarioAppServico
    {
        private readonly IUsuarioServico _usuarioServico;
        public UsuarioAppServico(IUsuarioServico usuarioServico)
            : base(usuarioServico)
        {
            _usuarioServico = usuarioServico;
        }
        public Usuario Login(Usuario usuario)
        {
            return _usuarioServico.Login(usuario);
        }
    }
}
