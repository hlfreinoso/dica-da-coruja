using DicaDaCoruja.Dados;
using DicaDaCoruja.Entidades;
using DicaDaCoruja.Negocios.Exceptions;

namespace DicaDaCoruja.Negocios.Acesso
{
    public class LoginBo
    {
        private CadUsuario _cadusuario;
        public RegisterAcesso UsuarioCadastrado(string nomeusuario, string senha)
        {
            _cadusuario = new CadUsuario();
            var usuario = _cadusuario.ObterUsuarioESenha(nomeusuario, senha);
            if (usuario == null)
            {
                throw new UsuarioNaoCadastradoException();
            }
            else
            {
                return usuario;
            }
        }
    }
}
