using DicaDaCoruja.Negocios.Acesso;
using System;

namespace DicaDaCoruja.Interface.Register
{
    public partial class Cidades : System.Web.UI.Page
    {
        private LerSelect _ler;
        private GravarCidade _gravar;
        private GeraUpdate _update;
        protected void Page_Load(object sender, EventArgs e)
        {
            Reload();
        }
        protected void Reload()
        {
            TextCidade.MaxLength = 50;
            TextEstado.MaxLength = 2;
            _ler = new LerSelect();
            var Dt = _ler.LerCidade();
            if (Dt != null)
            {
                GridCidades.DataSource = Dt.ValDataTable;
                GridCidades.DataBind();
            }
        }
        protected void BtnInserir_Click(object sender, EventArgs e)
        {
            string ValCidade = TextCidade.Text;
            string ValEstado = TextEstado.Text;
            if (ValCidade != "")
            {
                LabelStatus.Text = "";
                _gravar = new GravarCidade();
                var Gravar = _gravar.InserirCidade(ValCidade, ValEstado);
                LabelStatus.Text = Gravar.ValMenssage.ToString();
                if (LabelStatus.Text == "Registro inserido com sucesso")
                {
                    LabelStatus.CssClass = "TxtVerde";
                    TextCidade.Text = "";
                    TextEstado.Text = "";
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
                var Update = _update.GerarUpdate("CIDADE", TextID.Text, "SCID", "A");
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
                var Update = _update.GerarUpdate("CIDADE", TextID.Text, "SCID", "'I'");
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