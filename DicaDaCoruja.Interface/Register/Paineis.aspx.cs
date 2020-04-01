using DicaDaCoruja.Negocios.Acesso;
using System;
using System.IO;

namespace DicaDaCoruja.Interface.Register
{
    public partial class Paineis : System.Web.UI.Page
    {
        private GravarPainel _gravar;
        private LerSelect _ler;
        private GeraUpdate _update;
        private DateTime resultado;
        private LerNumPainel _numpnl;
        private string DataFim;
        protected void Page_Load(object sender, EventArgs e)
        {
            Reload();
        }

        protected void Reload()
        {
            TextDescricao.MaxLength = 30;
            _ler = new LerSelect();
            var Dt = _ler.LerPainel();
            if (Dt != null)
            {
                GridPainel.DataSource = Dt.ValDataTable;
                GridPainel.DataBind();
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
            this.TextDataInicio.Attributes.Add("autocomplete", "off");
            this.TextDataFim.Attributes.Add("autocomplete", "off");
        }

        protected void Change_Fornecedor(Object sender, EventArgs e)
        {
            DropTipo.Items.Clear();
            _ler = new LerSelect();
            var DtTipo = _ler.LerDropTipoPnl(DropFornecedor.SelectedValue.ToString());
            if (DtTipo != null)
            {
                DropTipo.DataTextField = "Tipo Des";
                DropTipo.DataValueField = "Tipo Val";
                DropTipo.DataSource = DtTipo.ValDataTable;
                DropTipo.DataBind();
                DropTipo.AppendDataBoundItems = true;
            }
        }

        protected void Change_Tipo(Object sender, EventArgs e)
        {
            if (DropTipo.SelectedValue.Substring(0, 3).ToString() == "MÊS")
            {
                TextDataInicio.Enabled = true;
                TextDataFim.Enabled = false;
                resultado = DateTime.MinValue;
                if (DateTime.TryParse(TextDataInicio.Text, out resultado))
                {
                    DataFim = resultado.AddDays(-1).AddMonths(1).ToString();
                    TextDataFim.Text = DataFim.Substring(0, 10);
                }
            }
            else
            {
                TextDataInicio.Enabled = true;
                TextDataFim.Enabled = true;
            }
        }

        protected void TextDataInicio_Changed(object sender, EventArgs e)
        {
            resultado = DateTime.MinValue;
            if (DateTime.TryParse(TextDataInicio.Text, out resultado))
            {
                if (resultado < DateTime.Today)
                {
                    resultado = DateTime.Today;
                    TextDataInicio.Text = DateTime.Today.ToString();
                    TextDataInicio.Text = TextDataInicio.Text.Substring(0, 10);
                }
                if (DropTipo.SelectedValue.Substring(0, 3).ToString() == "MÊS")
                {
                    DataFim = resultado.AddDays(-1).AddMonths(1).ToString();
                    TextDataFim.Text = DataFim.Substring(0, 10);
                }
            }
            else
            {
                Response.Write("<script>alert('Data Início Inválida');</script>");
                TextDataInicio.Text = "";
            }
        }

        protected void TextDataFim_Changed(object sender, EventArgs e)
        {
            resultado = DateTime.MinValue;
            if (DateTime.TryParse(TextDataFim.Text, out resultado))
            {
                if (resultado < DateTime.Today)
                {
                    resultado = DateTime.Today;
                    TextDataFim.Text = DateTime.Today.ToString();
                    TextDataFim.Text = TextDataFim.Text.Substring(0, 10);
                }
            }
            else
            {
                Response.Write("<script>alert('Data Fim Inválida');</script>");
                TextDataFim.Text = "";
            }
        }

        protected void BtnInserir_Click(object sender, EventArgs e)
        {
            if (TextDataInicio.Text != "" && TextDataFim.Text != "" && DropFornecedor.SelectedValue.ToString() != "Lojas" && UpldFoto.PostedFile.ToString() != "")
            {
                _numpnl = new LerNumPainel();
                var NumeroPainel = _numpnl.LerNumeroPnl();
                if (NumeroPainel.ValMenssage != null)
                {
                    LabelStatus.Text = "";
                    _gravar = new GravarPainel();
                    UpldFoto.PostedFile.SaveAs(Server.MapPath("~/Uploaded/" + NumeroPainel.ValMenssage.Trim() + ".jpg"));
                    var Gravar = _gravar.InserirPainel(TextDataInicio.Text, TextDataFim.Text, DropFornecedor.SelectedValue.ToString(), TextDescricao.Text, "../Uploaded/" + NumeroPainel.ValMenssage.Trim() + ".jpg", TextLink.Text, DropTipo.SelectedValue.ToString());
                    LabelStatus.Text = Gravar.ValMenssage.ToString();
                }
                if (LabelStatus.Text == "Registro inserido com sucesso")
                {
                    LabelStatus.CssClass = "TxtVerde";
                    TextDataInicio.Text = "";
                    TextDataFim.Text = "";
                    TextDescricao.Text = "";
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
        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            if (TextID.Text != "")
            {
                _update = new GeraUpdate();
                var Update = _update.GerarUpdate("PAINEL", TextID.Text, "SPNL", "'I'");
                LabelStatus.Text = Update.ValMenssage.ToString();
                if (LabelStatus.Text == "Registro atualizado com sucesso")
                {
                    LabelStatus.CssClass = "TxtVerde";
                    TextDataInicio.Text = "";
                    TextDataFim.Text = "";
                    TextDescricao.Text = "";
                    TextLink.Text = "";
                }
                else
                {
                    LabelStatus.CssClass = "TxtVermelho";
                }
            }
            else
            {
                LabelStatus.Text = "É necessário preencher ID";
                LabelStatus.CssClass = "TxtVermelho";
            }
        }
    }
}