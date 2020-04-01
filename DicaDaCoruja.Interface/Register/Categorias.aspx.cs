using DicaDaCoruja.Negocios.Acesso;
using System;

namespace DicaDaCoruja.Interface.Register
{
    public partial class Categorias : System.Web.UI.Page
    {
        private GravarCategoria _gravar;
        private LerSelect _ler;
        private GeraUpdate _update;
        protected void Page_Load(object sender, EventArgs e)
        {
            Reload();
        }
        protected void Reload()
        {
            TextCategoria.MaxLength = 20;
            TextCatePai.MaxLength = 20;
            _ler = new LerSelect();
            var Dt = _ler.LerCategoria();
            if (Dt != null)
            {
                GridCategoria.DataSource = Dt.ValDataTable;
                GridCategoria.DataBind();
            }
        }
        protected void BtnInserir_Click(object sender, EventArgs e)
        {
            if (TextCategoria.Text != "" && TextCatePai.Text != "")
            {
                LabelStatus.Text = "";
                _gravar = new GravarCategoria();
                var Gravar = _gravar.InserirCategoria(TextCategoria.Text, TextCatePai.Text);
                LabelStatus.Text = Gravar.ValMenssage.ToString();
                if (LabelStatus.Text == "Registro inserido com sucesso")
                {
                    LabelStatus.CssClass = "TxtVerde";
                    TextCategoria.Text = "";
                    TextCatePai.Text = "";
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
            if (TextID.Text != "")
            {
                _update = new GeraUpdate();
                var Update = _update.GerarUpdate("CATEGORIA", TextID.Text, "SCAT", "'A'");
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
            if (TextID.Text != "")
            {
                _update = new GeraUpdate();
                var Update = _update.GerarUpdate("CATEGORIA", TextID.Text, "SCAT", "'I'");
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