using LCesarAdvogados.Dominio.Entidades;
using LCesarAdvogados.Dominio.Interfaces.Repositorios;
using LCesarAdvogados.Infra.Contexto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LCesarAdvogados.Infra.Repositorios
{
    public class UsuarioRepositorio : RepositorioBase<Usuario>, IUsuarioRepositorio
    {
        public Usuario Login(Usuario usuario)
        {
            using (var contexto = new LCesarAdvogadosContexto())
            {
                return contexto.Usuario.FirstOrDefault(u => u.Login == usuario.Login && u.Senha == usuario.Senha);
            }
        }
    }
}
