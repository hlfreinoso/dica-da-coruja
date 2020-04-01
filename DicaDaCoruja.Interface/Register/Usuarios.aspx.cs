using DicaDaCoruja.Negocios.Acesso;
using System;

namespace DicaDaCoruja.Interface.Register
{
    public partial class Usuarios : System.Web.UI.Page
    {
        private GravarUsuario _gravar;
        private LerSelect _ler;
        private GeraUpdate _update;
        protected void Page_Load(object sender, EventArgs e)
        {
            Reload();
        }

        protected void Reload()
        {
            _ler = new LerSelect();
            var Dt = _ler.LerUsuarios();
            if (Dt != null)
            {
                GridUsuarios.DataSource = Dt.ValDataTable;
                GridUsuarios.DataBind();
            }
            _ler = new LerSelect();
            var DtLoja = _ler.LerDropLojaCad();
            if (DtLoja != null && DropFornecedor.Items.Count.ToString() == "0")
            {
                DropFornecedor.DataTextField = "Loja Des";
                DropFornecedor.DataValueField = "Loja Val";
                DropFornecedor.DataSource = DtLoja.ValDataTable;
                DropFornecedor.DataBind();
                DropFornecedor.AppendDataBoundItems = true;
            }
        }

        protected void BtnInserir_Click(object sender, EventArgs e)
        {
            if (DropFornecedor.SelectedValue.ToString() != "Lojas" && TextUsuario.Text != "" && TextSenha.Text != "")
            {
                LabelStatus.Text = "";
                _gravar = new GravarUsuario();
                var Gravar = _gravar.InserirUsuario(DropFornecedor.SelectedValue.ToString(), TextUsuario.Text, TextSenha.Text);
                LabelStatus.Text = Gravar.ValMenssage.ToString();
                if (LabelStatus.Text == "Registro inserido com sucesso")
                {
                    LabelStatus.CssClass = "TxtVerde";
                    TextUsuario.Text = "";
                    TextSenha.Text = "";
                }
                else
                {
                    LabelStatus.CssClass = "TxtVermelho";
                }
                Reload();
            }
            else
            {
                LabelStatus.Text = "É necessário preencher todos os campos";
                LabelStatus.CssClass = "TxtVermelho";
            }
        }

        protected void BtnAtivar_Click(object sender, EventArgs e)
        {
            if (DropUsuario.SelectedValue.ToString() != "Usuários")
            {
                _update = new GeraUpdate();
                var Update = _update.GerarUpdate("USUARIO", DropUsuario.SelectedValue.ToString(), "SUSU", "'A'");
                LabelStatus.Text = Update.ValMenssage.ToString();
                if (LabelStatus.Text == "Registro atualizado com sucesso")
                {
                    LabelStatus.CssClass = "TxtVerde";
                }
                else
                {
                    LabelStatus.CssClass = "TxtVermelho";
                }
                Reload();
            }
            else
            {
                LabelStatus.Text = "É necessário preencher ID";
                LabelStatus.CssClass = "TxtVermelho";
            }
        }

        protected void BtnInativar_Click(object sender, EventArgs e)
        {
            if (DropUsuario.SelectedValue.ToString() != "Usuários")
            {
                _update = new GeraUpdate();
                var Update = _update.GerarUpdate("USUARIO", DropUsuario.SelectedValue.ToString(), "SUSU", "'I'");
                LabelStatus.Text = Update.ValMenssage.ToString();
                if (LabelStatus.Text == "Registro atualizado com sucesso")
                {
                    LabelStatus.CssClass = "TxtVerde";
                }
                else
                {
                    LabelStatus.CssClass = "TxtVermelho";
                }
                Reload();
            }
            else
            {
                LabelStatus.Text = "É necessário preencher ID";
                LabelStatus.CssClass = "TxtVermelho";
            }
        }
    }
}