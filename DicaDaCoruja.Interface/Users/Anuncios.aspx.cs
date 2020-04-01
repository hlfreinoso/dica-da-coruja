using DicaDaCoruja.Negocios.Acesso;
using System;

namespace DicaDaCoruja.Interface.Users
{
    public partial class Anuncios : System.Web.UI.Page
    {
        private GravarAnuncio _gravar;
        private LerSelect _ler;
        private GeraUpdate _update;
        private DateTime resultado_ini;
        private DateTime resultado_fim;
        protected void Page_Load(object sender, EventArgs e)
        {
            Reload();
            if (Request.ServerVariables["AUTH_USER"].ToUpper().ToString() == "ADMIN")
            {
                Response.Redirect("../Register/Home.aspx");
            }
            _ler = new LerSelect();
            var Dt = _ler.LerEmpresa(Request.ServerVariables["AUTH_USER"].ToString());
            LabelLojaPopup.Text = Dt.ValDataTable.Rows[0]["1"].ToString();
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
            this.TextPrecoAlt.Attributes.Add("autocomplete", "off");
        }

        protected void Change_Tipo(Object sender, EventArgs e)
        {
            if (DropTipo.SelectedValue == "VERMELHO")
            {
                ImgLogoPopup.ImageUrl = "../Images/logo-vermelho.jpg";
                LabelPrecoPopup.CssClass = "TxtVermelho";
                BtnPopup.CssClass = "Btn Btn-Vrm";
                this.FaixaPopup.Attributes["class"] = "FaixaAnuncio FundoVermelho TxtCenter";
            }
            else if (DropTipo.SelectedValue == "AZUL")
            {
                ImgLogoPopup.ImageUrl = "../Images/logo-azul.jpg";
                LabelPrecoPopup.CssClass = "TxtAzul";
                BtnPopup.CssClass = "Btn Btn-Azl";
                this.FaixaPopup.Attributes["class"] = "FaixaAnuncio FundoAzul TxtCenter";
            }
            else
            {
                ImgLogoPopup.ImageUrl = "../Images/logo-verde.jpg";
                LabelPrecoPopup.CssClass = "TxtVerde";
                BtnPopup.CssClass = "Btn Btn-Vrd";
                this.FaixaPopup.Attributes["class"] = "FaixaAnuncio FundoVerde TxtCenter";
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
                DropCategoriaFilho.Enabled = true;
            }
            LabelTituloPopup.Text = "Veja como é fácil";
            ImgPopup.Attributes.Add("title", "Anuncie agora mesmo");
            ImgPopup.ImageUrl = "../Images/anuncio.jpg";
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
                DropProduto.Enabled = true;
            }
            LabelTituloPopup.Text = "Veja como é fácil";
            ImgPopup.Attributes.Add("title", "Anuncie agora mesmo");
            ImgPopup.ImageUrl = "../Images/anuncio.jpg";
        }

        protected void Change_Produto(Object sender, EventArgs e)
        {
            if (DropProduto.SelectedItem.ToString() != "Tipo")
            {
                _ler = new LerSelect();
                var Dt = _ler.LerProduto(DropProduto.SelectedValue.ToString());
                LabelTituloPopup.Text = Dt.ValDataTable.Rows[0]["0"].ToString();
                ImgPopup.Attributes.Add("title", Dt.ValDataTable.Rows[0]["1"].ToString());
                ImgPopup.ImageUrl = Dt.ValDataTable.Rows[0]["2"].ToString();
               /* ImgPopup.Attributes.Add("src", Dt.ValDataTable.Rows[0]["2"].ToString());*/
            }
            else
            {
                LabelTituloPopup.Text = "Veja como é fácil";
                ImgPopup.Attributes.Add("title", "Anuncie agora mesmo");
                ImgPopup.ImageUrl = "../Images/anuncio.jpg";
            }
        }

        protected void TextDataInicio_Changed(object sender, EventArgs e)
        {
            resultado_ini = DateTime.MinValue;
            resultado_fim = DateTime.MinValue;
            if (DateTime.TryParse(TextDataInicio.Text, out resultado_ini))
            {
                if (resultado_ini < DateTime.Today)
                {
                    TextDataInicio.Text = DateTime.Today.ToString().Substring(0, 10);
                    resultado_ini = DateTime.Today;
                }
                if (DateTime.TryParse(TextDataFim.Text, out resultado_fim))
                {
                    if (resultado_fim < resultado_ini)
                    {
                        TextDataFim.Text = resultado_ini.ToString().Substring(0, 10);
                    }
                    if (resultado_fim > resultado_ini.AddDays(30))
                    {
                        TextDataFim.Text = resultado_ini.AddDays(30).ToString().Substring(0, 10);
                    }
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
            resultado_ini = DateTime.MinValue;
            resultado_fim = DateTime.MinValue;
            if (DateTime.TryParse(TextDataInicio.Text, out resultado_ini))
            {
                if (DateTime.TryParse(TextDataFim.Text, out resultado_fim))
                {
                    if (resultado_fim < resultado_ini)
                    {
                        TextDataFim.Text = resultado_ini.ToString().Substring(0, 10);
                    }
                    if (resultado_fim > resultado_ini.AddDays(30))
                    {
                        TextDataFim.Text = resultado_ini.AddDays(30).ToString().Substring(0, 10);
                    }
                    LabelValidadePopup.Text = "Válido até: " + TextDataFim.Text;
                }
                else
                {
                    Response.Write("<script>alert('Data Fim Inválida');</script>");
                    TextDataFim.Text = "";
                    LabelValidadePopup.Text = "Válido até: 31/12/9999";
                }
            }
            else
            {
                Response.Write("<script>alert('Data Início Inválida');</script>");
                TextDataInicio.Text = "";
                TextDataFim.Text = "";
                LabelValidadePopup.Text = "Válido até: 31/12/9999";
            }
        }
        
        public void BtnInserir_Click(object sender, EventArgs e)
        {
            if (DropTipo.SelectedValue != "" && DropProduto.SelectedValue.ToString() != "" && DropProduto.SelectedValue.ToString() != "Produtos" && TextDataInicio.Text != "" && TextDataFim.Text != "" && TextPreco.Text != "")
            {
                LabelStatus.Text = "";
                _gravar = new GravarAnuncio();
                var Gravar = _gravar.InserirAnuncio(DropProduto.SelectedValue.ToString(), TextDataInicio.Text, TextDataFim.Text, TextPreco.Text, DropTipo.SelectedValue.ToString(), Request.ServerVariables["AUTH_USER"].ToString(), "");
                LabelStatus.Text = Gravar.ValMenssage.ToString();
                if (LabelStatus.Text == "Registro inserido com sucesso")
                {
                    LabelStatus.CssClass = "TxtVerde";
                    TextDataInicio.Text = "";
                    TextDataFim.Text = "";
                    TextPreco.Text = "";
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