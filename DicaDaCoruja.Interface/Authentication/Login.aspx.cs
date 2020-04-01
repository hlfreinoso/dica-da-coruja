using DicaDaCoruja.Negocios.Acesso;
using DicaDaCoruja.Negocios.Exceptions;
using System;
using System.Web.Security;

namespace DicaDaCoruja.Interface.Register
{
    public partial class Login : System.Web.UI.Page
    {
        public string NomeUsuario;
        private LoginBo _loginbo;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnEntrar_Click(object sender, EventArgs e)
        {
            _loginbo = new LoginBo();
            var nomeusuario = TxtUsuario.Text;
            var senha = TxtSenha.Text;
            LblStatus.Text = "";
            try
            {
                var usuario = _loginbo.UsuarioCadastrado(nomeusuario, senha);
                FormsAuthentication.RedirectFromLoginPage(nomeusuario, false);
                NomeUsuario = usuario.ToString();
            }
            catch (UsuarioNaoCadastradoException)
            {
                LblStatus.Text = "Usuário ou senha incorreto";
            }
            catch (Exception)
            {
                LblStatus.Text = "Erro, contate o administrador!";
            }
        }
    }
}