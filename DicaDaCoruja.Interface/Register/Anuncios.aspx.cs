using DicaDaCoruja.Negocios.Acesso;
using System;

namespace DicaDaCoruja.Interface.Register
{
    public partial class Anuncios : System.Web.UI.Page
    {
        private GravarAnuncio _gravar;
        private LerSelect _ler;
        private GeraUpdate _update;
        private DateTime resultado;
        private string DataFim;
        protected void Page_Load(object sender, EventArgs e)
        {
            Reload();
        }

        protected void Reload()
        {
            _ler = new LerSelect();
            var Dt = _ler.LerAnuncio(Request.ServerVariables["AUTH_USER"].ToString());
            if (Dt != null)
            {
                GridAnuncios.DataSource = Dt.ValDataTable;
                GridAnuncios.DataBind();
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
            _ler = new LerSelect();
            var DtCatePai = _ler.LerDropCategoriaPai();
            if (DtCatePai != null && DropCategoriaPai.Items.Count.ToString() == "0")
            {
                DropCategoriaPai.DataTextField = "Categoria";
                DropCategoriaPai.DataSource = DtCatePai.ValDataTable;
                DropCategoriaPai.DataBind();
                DropCategoriaPai.AppendDataBoundItems = true;
            }
            _ler = new LerSelect();
            var DtID = _ler.LerDropIDAnuncio();
            if (DtID != null && DropID.Items.Count.ToString() == "0")
            {
                DropID.DataTextField = "ID Des";
                DropID.DataValueField = "ID Val";
                DropID.DataSource = DtID.ValDataTable;
                DropID.DataBind();
                DropID.AppendDataBoundItems = true;
            }
            this.TextDataInicio.Attributes.Add("autocomplete", "off");
            this.TextDataFim.Attributes.Add("autocomplete", "off");
            this.TextPreco.Attributes.Add("autocomplete", "off");
        }

        protected void Change_Fornecedor(Object sender, EventArgs e)
        {
            DropTipo.Items.Clear();
            _ler = new LerSelect();
            var DtTipo = _ler.LerDropTipo(DropFornecedor.SelectedValue.ToString());
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

        protected void Change_CategoriaPai(Object sender, EventArgs e)
        {
            DropCategoriaFilho.Items.Clear();
            DropProduto.Items.Clear();
            _ler = new LerSelect();
            var DtCateFilho = _ler.LerDropCategoriaFilho(DropCategoriaPai.SelectedValue.ToString());
            if (DtCateFilho != null)
            {
                DropCategoriaFilho.DataTextField = "Categoria Des";
                DropCategoriaFilho.DataValueField = "Categoria Val";
                DropCategoriaFilho.DataSource = DtCateFilho.ValDataTable;
                DropCategoriaFilho.DataBind();
                DropCategoriaFilho.AppendDataBoundItems = true;
            }
        }

        protected void Change_CategoriaFilho(Object sender, EventArgs e)
        {
            DropProduto.Items.Clear();
            _ler = new LerSelect();
            var DtProd = _ler.LerDropProduto(DropCategoriaFilho.SelectedValue.ToString());
            if (DtProd != null)
            {
                DropProduto.DataTextField = "Produto Des";
                DropProduto.DataValueField = "Produto Val";
                DropProduto.DataSource = DtProd.ValDataTable;
                DropProduto.DataBind();
                DropProduto.AppendDataBoundItems = true;
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
            if (DropProduto.SelectedValue.ToString() != "" && DropProduto.SelectedValue.ToString() != "Produtos" && TextDataInicio.Text != "" && TextDataFim.Text != "" && TextPreco.Text != "" && DropFornecedor.SelectedValue.ToString() != "Lojas")
            {
                LabelStatus.Text = "";
                _gravar = new GravarAnuncio();
                var Gravar = _gravar.InserirAnuncio(DropProduto.SelectedValue.ToString(), TextDataInicio.Text, TextDataFim.Text, TextPreco.Text, DropFornecedor.SelectedValue.ToString(), DropTipo.SelectedValue.ToString(), TextLink.Text);
                LabelStatus.Text = Gravar.ValMenssage.ToString();
                if (LabelStatus.Text == "Registro inserido com sucesso")
                {
                    LabelStatus.CssClass = "TxtVerde";
                    TextDataInicio.Text = "";
                    TextDataFim.Text = "";
                    TextPreco.Text = "";
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
            if (DropID.SelectedValue.ToString() != "")
            {
                _update = new GeraUpdate();
                var Update = _update.GerarUpdate("ANUNCIOS", DropID.SelectedValue.ToString(), "SANU", "'I'");
                Update = _update.GerarUpdate("ANUNCIOS", DropID.SelectedValue.ToString(), "DFIM", "CAST(CAST(GETDATE() AS DATE) AS DATETIME)+1");
                LabelStatus.Text = Update.ValMenssage.ToString();
                if (LabelStatus.Text == "Registro alterado com sucesso")
                {
                    LabelStatus.CssClass = "TxtVerde";
                    TextDataInicio.Text = "";
                    TextDataFim.Text = "";
                    DropProduto.Text = "";
                    TextPreco.Text = "";
                    DropTipo.Text = "";
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
        protected void BtnAltera_Click(object sender, EventArgs e)
        {
            if (DropID.SelectedValue.ToString() != "" && TextPrecoAlt.Text != "")
            {
                _update = new GeraUpdate();
                var Update = _update.GerarUpdate("ANUNCIOS", DropID.SelectedValue.ToString(), "PREC", TextPrecoAlt.Text);
                LabelStatus.Text = Update.ValMenssage.ToString();
                if (LabelStatus.Text == "Registro atualizado com sucesso")
                {
                    LabelStatus.CssClass = "TxtVerde";
                    TextPrecoAlt.Text = "";
                }
                else
                {
                    LabelStatus.CssClass = "TxtVermelho";
                }
                Reload();
            }
            else
            {
                LabelStatus.Text = "É necessário preencher o ID e o preço";
                LabelStatus.CssClass = "TxtVermelho";
            }
        }
    }
}