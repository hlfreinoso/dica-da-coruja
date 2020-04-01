using DicaDaCoruja.Negocios.Acesso;
using System;

namespace DicaDaCoruja.Interface.Register
{
    public partial class Lojas : System.Web.UI.Page
    {
        private GravarFornecedor _gravar;
        private LerSelect _ler;
        private GeraUpdate _update;
        protected void Page_Load(object sender, EventArgs e)
        {
            Reload();
        }
        protected void Reload()
        {
            TextGrupo.MaxLength = 20;
            TextFornecedor.MaxLength = 20;
            TextCNPJ.MaxLength = 20;
            TextCEP.MaxLength = 50;
            TextRua.MaxLength = 100;
            TextRazao.MaxLength = 100;
            _ler = new LerSelect();
            var Dt = _ler.LerFornecedor();
            if (Dt != null)
            {
                GridFornecedor.DataSource = Dt.ValDataTable;
                GridFornecedor.DataBind();
            }
            _ler = new LerSelect();
            var DtEstado = _ler.LerDropEstado();
            if (DtEstado != null && DropEstado.Text == "")
            {
                DropEstado.DataTextField = "Estados";
                DropEstado.DataSource = DtEstado.ValDataTable;
                DropEstado.DataBind();
                DropEstado.AppendDataBoundItems = true;
            }
        }
        protected void Change_Estado(Object sender, EventArgs e)
        {
            DropCidade.Items.Clear();
            _ler = new LerSelect();
            var DtCateFilho = _ler.LerDropCidadeCad(DropEstado.SelectedItem.Value);
            if (DtCateFilho != null)
            {
                DropCidade.DataTextField = "Cidades";
                DropCidade.DataSource = DtCateFilho.ValDataTable;
                DropCidade.DataBind();
                DropCidade.AppendDataBoundItems = true;
            }
        }
        protected void BtnInserir_Click(object sender, EventArgs e)
        {
            if (TextFornecedor.Text != "" && TextLoja.Text != "" && TextCNPJ.Text != "" && TextRazao.Text != "" && TextCEP.Text != "" && DropCidade.Text != "" && DropEstado.Text != "" && TextLink.Text != "")
            {
                LabelStatus.Text = "";
                _gravar = new GravarFornecedor();
                var Gravar =  _gravar.InserirFornecedor(TextGrupo.Text, TextFornecedor.Text, TextLoja.Text, TextCNPJ.Text, TextRazao.Text, TextCEP.Text, TextRua.Text, TextNumero.Text, TextBairro.Text, DropCidade.Text, DropEstado.Text, TextLink.Text, DropContrato.Text);
                LabelStatus.Text = Gravar.ValMenssage.ToString();
                if (LabelStatus.Text == "Registro inserido com sucesso")
                {
                    LabelStatus.CssClass = "TxtVerde";
                    TextGrupo.Text = "";
                    TextFornecedor.Text = "";
                    TextLoja.Text = "";
                    TextCNPJ.Text = "";
                    TextRazao.Text = "";
                    TextCEP.Text = "";
                    TextRua.Text = "";
                    TextNumero.Text = "";
                    TextBairro.Text = "";
                    TextLink.Text = "";
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
                var Update = _update.GerarUpdate("FORNECEDOR", TextID.Text, "SFOR", "'A'");
                LabelStatus.Text = Update.ValMenssage.ToString();
                if (LabelStatus.Text == "Registro atualizado com sucesso")
                {
                    LabelStatus.CssClass = "TxtVerde";
                    TextGrupo.Text = "";
                    TextFornecedor.Text = "";
                    TextLoja.Text = "";
                    TextCNPJ.Text = "";
                    TextRazao.Text = "";
                    TextCEP.Text = "";
                    TextRua.Text = "";
                    TextNumero.Text = "";
                    TextBairro.Text = "";
                    TextLink.Text = "";
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
        protected void BtnDesativar_Click(object sender, EventArgs e)
        {
            if (TextID.Text != "")
            {
                _update = new GeraUpdate();
                var Update = _update.GerarUpdate("FORNECEDOR", TextID.Text, "SFOR", "'I'");
                LabelStatus.Text = Update.ValMenssage.ToString();
                if (LabelStatus.Text == "Registro atualizado com sucesso")
                {
                    LabelStatus.CssClass = "TxtVerde";
                    TextGrupo.Text = "";
                    TextFornecedor.Text = "";
                    TextLoja.Text = "";
                    TextCNPJ.Text = "";
                    TextRazao.Text = "";
                    TextCEP.Text = "";
                    TextRua.Text = "";
                    TextNumero.Text = "";
                    TextBairro.Text = "";
                    TextLink.Text = "";
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