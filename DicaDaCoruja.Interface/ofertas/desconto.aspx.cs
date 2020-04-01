using DicaDaCoruja.Negocios.Acesso;
using System;
using System.Data;
using System.Web;

namespace DicaDaCoruja.Interface.ofertas
{
    public partial class desconto : System.Web.UI.Page
    {
        #region Declar Objects
        private LerSelect _ler;
        private LerPainelHome _lerpainelhome;
        private LerAnuncioHome _leranunciohome;
        private GravarLog _insert;
        public string ValOrd = "";
        public string ValCid = "";
        public string ValFor = "";
        public string ValCla = "";
        public string ValPes = "";
        public string RedirectUrl = "";
        public int ValPag = 0;
        #endregion

        #region Load Area
        protected void Page_Load(object sender, EventArgs e)
        {
            Reload();
        }

        protected void Reload()
        {
            ValOrd = Request.QueryString["ORDE"];
            if (ValOrd == null)
            {
                ValOrd = "";
            }
            ValCid = Request.QueryString["CIDA"];
            if (ValCid == null)
            {
                ValCid = "";
            }
            ValFor = Request.QueryString["LOJA"];
            if (ValFor == null)
            {
                ValFor = "";
            }
            ValCla = Request.QueryString["CLAS"];
            if (ValCla == null)
            {
                ValCla = "";
            }
            ValPes = Request.QueryString["PESQ"];
            if (ValPes == null)
            {
                ValPes = "";
            }
            if (Request.QueryString["PAGE"] == null)
            {
                ValPag = 0;
            }
            else
            {
                ValPag = Convert.ToInt32(Request.QueryString["PAGE"]);
            }
            _ler = new LerSelect();
            var DtLoja = _ler.LerDropLoja();
            if (DtLoja != null && DropFornecedor.Items.Count.ToString() == "0")
            {
                DropFornecedor.DataTextField = "Loja";
                DropFornecedor.DataSource = DtLoja.ValDataTable;
                DropFornecedor.DataBind();
                DropFornecedor.AppendDataBoundItems = true;
            }
            _ler = new LerSelect();
            var DtCategoria = _ler.LerDropCategoria();
            if (DtCategoria != null && DropCategoria.Items.Count.ToString() == "0")
            {
                DropCategoria.DataTextField = "Categoria";
                DropCategoria.DataSource = DtCategoria.ValDataTable;
                DropCategoria.DataBind();
                DropCategoria.AppendDataBoundItems = true;
            }
            _ler = new LerSelect();
            var DtCidade = _ler.LerDropCidade();
            if (DtCidade != null && DropCidade.Items.Count.ToString() == "0")
            {
                DropCidade.DataTextField = "Cidade";
                DropCidade.DataSource = DtCidade.ValDataTable;
                DropCidade.DataBind();
                DropCidade.AppendDataBoundItems = true;
            }
            _insert = new GravarLog();
            string ValIP = "";
            if (Request.UserHostAddress != null)
            {
                ValIP = Request.UserHostAddress;
            }
            string ValRequest = "Home";
            _insert.InserirLog(ValIP, ValRequest);
            _lerpainelhome = new LerPainelHome();
            try
            {
                var SelectPainel = _lerpainelhome.LerPainel();
                if (SelectPainel.PainelFoto1 != null)
                {
                    ImgPnl1.ImageUrl = SelectPainel.PainelFoto1;
                    ImgLink1.Attributes.Add("target", "_blank");
                    ImgLink1.Attributes.Add("onclick", "window.open('" + SelectPainel.PainelLink1 + "');return false;");
                    ImgLink1.NavigateUrl = "";
                }
                if (SelectPainel.PainelFoto2 != null)
                {
                    ImgPnl2.ImageUrl = SelectPainel.PainelFoto2;
                    ImgLink2.Attributes.Add("target", "_blank");
                    ImgLink2.Attributes.Add("onclick", "window.open('" + SelectPainel.PainelLink2 + "');return false;");
                    ImgLink2.NavigateUrl = "";
                }
                if (SelectPainel.PainelFoto3 != null)
                {
                    ImgPnl3.ImageUrl = SelectPainel.PainelFoto3;
                    ImgLink3.Attributes.Add("target", "_blank");
                    ImgLink3.Attributes.Add("onclick", "window.open('" + SelectPainel.PainelLink3 + "');return false;");
                    ImgLink3.NavigateUrl = "";
                }
                if (SelectPainel.PainelFoto4 != null)
                {
                    ImgPnl4.ImageUrl = SelectPainel.PainelFoto4;
                    ImgLink4.Attributes.Add("target", "_blank");
                    ImgLink4.Attributes.Add("onclick", "window.open('" + SelectPainel.PainelLink4 + "');return false;");
                    ImgLink4.NavigateUrl = "";
                }
                if (SelectPainel.PainelFoto5 != null)
                {
                    ImgPnl5.ImageUrl = SelectPainel.PainelFoto5;
                    ImgLink5.Attributes.Add("target", "_blank");
                    ImgLink5.Attributes.Add("onclick", "window.open('" + SelectPainel.PainelLink5 + "');return false;");
                    ImgLink5.NavigateUrl = "";
                }
                if (SelectPainel.PainelFoto6 != null)
                {
                    ImgPnl6.ImageUrl = SelectPainel.PainelFoto6;
                    ImgLink6.Attributes.Add("target", "_blank");
                    ImgLink6.Attributes.Add("onclick", "window.open('" + SelectPainel.PainelLink6 + "');return false;");
                    ImgLink6.NavigateUrl = "";
                }
            }
            catch (Exception)
            {

            }

            _leranunciohome = new LerAnuncioHome();
            var CorDoAnuncio = "AZUL";
            try
            {
                var SelectAnuncio = _leranunciohome.LerAnuncio(CorDoAnuncio);
                if (SelectAnuncio.AnuncioPreco1 != null)
                {
                    LabelPrecoAzul1.Text = SelectAnuncio.AnuncioPreco1;
                    LabelTituloAzul1.Text = SelectAnuncio.AnuncioProduto1;
                    LabelValidadeAzul1.Text = SelectAnuncio.AnuncioDataFim1;
                    LabelLojaAzul1.Text = SelectAnuncio.AnuncioFornecedor1;
                    BtnAzul1.PostBackUrl = "";
                    BtnAzul1.OnClientClick = "window.open('" + SelectAnuncio.AnuncioLink1 + "');";
                    BtnAzul1.Text = "Ir para a loja";
                    ImgHomeAzul1.ImageUrl = SelectAnuncio.AnuncioFoto1;
                    ImgHomeAzul1.Attributes.Add("title", SelectAnuncio.AnuncioTitle1);
                    ImgHomeAzul1.AlternateText = SelectAnuncio.AnuncioTitle1;
                }
                if (SelectAnuncio.AnuncioPreco2 != null)
                {
                    LabelPrecoAzul2.Text = SelectAnuncio.AnuncioPreco2;
                    LabelTituloAzul2.Text = SelectAnuncio.AnuncioProduto2;
                    LabelValidadeAzul2.Text = SelectAnuncio.AnuncioDataFim2;
                    LabelLojaAzul2.Text = SelectAnuncio.AnuncioFornecedor2;
                    BtnAzul2.PostBackUrl = "";
                    BtnAzul2.OnClientClick = "window.open('" + SelectAnuncio.AnuncioLink2 + "');";
                    BtnAzul2.Text = "Ir para a loja";
                    ImgHomeAzul2.ImageUrl = SelectAnuncio.AnuncioFoto2;
                    ImgHomeAzul2.Attributes.Add("title", SelectAnuncio.AnuncioTitle2);
                    ImgHomeAzul2.AlternateText = SelectAnuncio.AnuncioTitle2;
                }
                if (SelectAnuncio.AnuncioPreco3 != null)
                {
                    LabelPrecoAzul3.Text = SelectAnuncio.AnuncioPreco3;
                    LabelTituloAzul3.Text = SelectAnuncio.AnuncioProduto3;
                    LabelValidadeAzul3.Text = SelectAnuncio.AnuncioDataFim3;
                    LabelLojaAzul3.Text = SelectAnuncio.AnuncioFornecedor3;
                    BtnAzul3.PostBackUrl = "";
                    BtnAzul3.OnClientClick = "window.open('" + SelectAnuncio.AnuncioLink3 + "');";
                    BtnAzul3.Text = "Ir para a loja";
                    ImgHomeAzul3.ImageUrl = SelectAnuncio.AnuncioFoto3;
                    ImgHomeAzul3.Attributes.Add("title", SelectAnuncio.AnuncioTitle3);
                    ImgHomeAzul3.AlternateText = SelectAnuncio.AnuncioTitle3;
                }
                if (SelectAnuncio.AnuncioPreco4 != null)
                {
                    LabelPrecoAzul4.Text = SelectAnuncio.AnuncioPreco4;
                    LabelTituloAzul4.Text = SelectAnuncio.AnuncioProduto4;
                    LabelValidadeAzul4.Text = SelectAnuncio.AnuncioDataFim4;
                    LabelLojaAzul4.Text = SelectAnuncio.AnuncioFornecedor4;
                    BtnAzul4.PostBackUrl = "";
                    BtnAzul4.OnClientClick = "window.open('" + SelectAnuncio.AnuncioLink4 + "');";
                    BtnAzul4.Text = "Ir para a loja";
                    ImgHomeAzul4.ImageUrl = SelectAnuncio.AnuncioFoto4;
                    ImgHomeAzul4.Attributes.Add("title", SelectAnuncio.AnuncioTitle4);
                    ImgHomeAzul4.AlternateText = SelectAnuncio.AnuncioTitle4;
                }
            }
            catch (Exception)
            {

            }
            CorDoAnuncio = "VERMELHO";
            try
            {
                var SelectAnuncio = _leranunciohome.LerAnuncio(CorDoAnuncio);
                if (SelectAnuncio.AnuncioPreco1 != null)
                {
                    LabelPrecoVermelho1.Text = SelectAnuncio.AnuncioPreco1;
                    LabelTituloVermelho1.Text = SelectAnuncio.AnuncioProduto1;
                    LabelValidadeVermelho1.Text = SelectAnuncio.AnuncioDataFim1;
                    LabelLojaVermelho1.Text = SelectAnuncio.AnuncioFornecedor1;
                    BtnVermelho1.PostBackUrl = "";
                    BtnVermelho1.OnClientClick = "window.open('" + SelectAnuncio.AnuncioLink1 + "');";
                    BtnVermelho1.Text = "Ir para a loja";
                    ImgHomeVermelho1.ImageUrl = SelectAnuncio.AnuncioFoto1;
                    ImgHomeVermelho1.Attributes.Add("title", SelectAnuncio.AnuncioTitle1);
                    ImgHomeVermelho1.AlternateText = SelectAnuncio.AnuncioTitle1;
                }
                if (SelectAnuncio.AnuncioPreco2 != null)
                {
                    LabelPrecoVermelho2.Text = SelectAnuncio.AnuncioPreco2;
                    LabelTituloVermelho2.Text = SelectAnuncio.AnuncioProduto2;
                    LabelValidadeVermelho2.Text = SelectAnuncio.AnuncioDataFim2;
                    LabelLojaVermelho2.Text = SelectAnuncio.AnuncioFornecedor2;
                    BtnVermelho2.PostBackUrl = "";
                    BtnVermelho2.OnClientClick = "window.open('" + SelectAnuncio.AnuncioLink2 + "');";
                    BtnVermelho2.Text = "Ir para a loja";
                    ImgHomeVermelho2.ImageUrl = SelectAnuncio.AnuncioFoto2;
                    ImgHomeVermelho2.Attributes.Add("title", SelectAnuncio.AnuncioTitle2);
                    ImgHomeVermelho2.AlternateText = SelectAnuncio.AnuncioTitle2;
                }
                if (SelectAnuncio.AnuncioPreco3 != null)
                {
                    LabelPrecoVermelho3.Text = SelectAnuncio.AnuncioPreco3;
                    LabelTituloVermelho3.Text = SelectAnuncio.AnuncioProduto3;
                    LabelValidadeVermelho3.Text = SelectAnuncio.AnuncioDataFim3;
                    LabelLojaVermelho3.Text = SelectAnuncio.AnuncioFornecedor3;
                    BtnVermelho3.PostBackUrl = "";
                    BtnVermelho3.OnClientClick = "window.open('" + SelectAnuncio.AnuncioLink3 + "');";
                    BtnVermelho3.Text = "Ir para a loja";
                    ImgHomeVermelho3.ImageUrl = SelectAnuncio.AnuncioFoto3;
                    ImgHomeVermelho3.Attributes.Add("title", SelectAnuncio.AnuncioTitle3);
                    ImgHomeVermelho3.AlternateText = SelectAnuncio.AnuncioTitle3;
                }
                if (SelectAnuncio.AnuncioPreco4 != null)
                {
                    LabelPrecoVermelho4.Text = SelectAnuncio.AnuncioPreco4;
                    LabelTituloVermelho4.Text = SelectAnuncio.AnuncioProduto4;
                    LabelValidadeVermelho4.Text = SelectAnuncio.AnuncioDataFim4;
                    LabelLojaVermelho4.Text = SelectAnuncio.AnuncioFornecedor4;
                    BtnVermelho4.PostBackUrl = "";
                    BtnVermelho4.OnClientClick = "window.open('" + SelectAnuncio.AnuncioLink4 + "');";
                    BtnVermelho4.Text = "Ir para a loja";
                    ImgHomeVermelho4.ImageUrl = SelectAnuncio.AnuncioFoto4;
                    ImgHomeVermelho4.Attributes.Add("title", SelectAnuncio.AnuncioTitle4);
                    ImgHomeVermelho4.AlternateText = SelectAnuncio.AnuncioTitle4;
                }
            }
            catch (Exception)
            {

            }
            CorDoAnuncio = "VERDE";
            try
            {
                var SelectAnuncio = _leranunciohome.LerAnuncio(CorDoAnuncio);
                if (SelectAnuncio.AnuncioPreco1 != null)
                {
                    LabelPrecoVerde1.Text = SelectAnuncio.AnuncioPreco1;
                    LabelTituloVerde1.Text = SelectAnuncio.AnuncioProduto1;
                    LabelValidadeVerde1.Text = SelectAnuncio.AnuncioDataFim1;
                    LabelLojaVerde1.Text = SelectAnuncio.AnuncioFornecedor1;
                    BtnVerde1.PostBackUrl = "";
                    BtnVerde1.OnClientClick = "window.open('" + SelectAnuncio.AnuncioLink1 + "');";
                    BtnVerde1.Text = "Ir para a loja";
                    ImgHomeVerde1.ImageUrl = SelectAnuncio.AnuncioFoto1;
                    ImgHomeVerde1.Attributes.Add("title", SelectAnuncio.AnuncioTitle1);
                    ImgHomeVerde1.AlternateText = SelectAnuncio.AnuncioTitle1;
                }
                if (SelectAnuncio.AnuncioPreco2 != null)
                {
                    LabelPrecoVerde2.Text = SelectAnuncio.AnuncioPreco2;
                    LabelTituloVerde2.Text = SelectAnuncio.AnuncioProduto2;
                    LabelValidadeVerde2.Text = SelectAnuncio.AnuncioDataFim2;
                    LabelLojaVerde2.Text = SelectAnuncio.AnuncioFornecedor2;
                    BtnVerde2.PostBackUrl = "";
                    BtnVerde2.OnClientClick = "window.open('" + SelectAnuncio.AnuncioLink2 + "');";
                    BtnVerde2.Text = "Ir para a loja";
                    ImgHomeVerde2.ImageUrl = SelectAnuncio.AnuncioFoto2;
                    ImgHomeVerde2.Attributes.Add("title", SelectAnuncio.AnuncioTitle2);
                    ImgHomeVerde2.AlternateText = SelectAnuncio.AnuncioTitle2;
                }
                if (SelectAnuncio.AnuncioPreco3 != null)
                {
                    LabelPrecoVerde3.Text = SelectAnuncio.AnuncioPreco3;
                    LabelTituloVerde3.Text = SelectAnuncio.AnuncioProduto3;
                    LabelValidadeVerde3.Text = SelectAnuncio.AnuncioDataFim3;
                    LabelLojaVerde3.Text = SelectAnuncio.AnuncioFornecedor3;
                    BtnVerde3.PostBackUrl = "";
                    BtnVerde3.OnClientClick = "window.open('" + SelectAnuncio.AnuncioLink3 + "');";
                    BtnVerde3.Text = "Ir para a loja";
                    ImgHomeVerde3.ImageUrl = SelectAnuncio.AnuncioFoto3;
                    ImgHomeVerde3.Attributes.Add("title", SelectAnuncio.AnuncioTitle3);
                    ImgHomeVerde3.AlternateText = SelectAnuncio.AnuncioTitle3;
                }
                if (SelectAnuncio.AnuncioPreco4 != null)
                {
                    LabelPrecoVerde4.Text = SelectAnuncio.AnuncioPreco4;
                    LabelTituloVerde4.Text = SelectAnuncio.AnuncioProduto4;
                    LabelValidadeVerde4.Text = SelectAnuncio.AnuncioDataFim4;
                    LabelLojaVerde4.Text = SelectAnuncio.AnuncioFornecedor4;
                    BtnVerde4.PostBackUrl = "";
                    BtnVerde4.OnClientClick = "window.open('" + SelectAnuncio.AnuncioLink4 + "');";
                    BtnVerde4.Text = "Ir para a loja";
                    ImgHomeVerde4.ImageUrl = SelectAnuncio.AnuncioFoto4;
                    ImgHomeVerde4.Attributes.Add("title", SelectAnuncio.AnuncioTitle4);
                    ImgHomeVerde4.AlternateText = SelectAnuncio.AnuncioTitle4;
                }
            }
            catch (Exception)
            {

            }
        }
        #endregion

        #region Action Area
        protected void BtnPesquisa_Click(object sender, EventArgs e)
        {
            ValPes = TxtPesquisa.Text;
            ValOrd = "";
            ValCla = "";
            ValCid = "";
            ValFor = "";
            ValPag = 0;
            RedirectPage(ValOrd, ValCid, ValFor, ValCla, ValPes, ValPag);
        }

        protected void Change_Categoria(Object sender, EventArgs e)
        {
            ValCla = DropCategoria.SelectedItem.Value;
            ValOrd = "";
            ValPag = 0;
            ValPes = "";
            RedirectPage(ValOrd, ValCid, ValFor, ValCla, ValPes, ValPag);
        }

        protected void Change_Cidade(Object sender, EventArgs e)
        {
            ValCid = DropCidade.SelectedItem.Value;
            ValOrd = "";
            ValPag = 0;
            ValPes = "";
            RedirectPage(ValOrd, ValCid, ValFor, ValCla, ValPes, ValPag);
        }

        protected void Change_Fornecedor(Object sender, EventArgs e)
        {
            ValFor = DropFornecedor.SelectedItem.Value;
            ValOrd = "";
            ValPag = 0;
            ValPes = "";
            RedirectPage(ValOrd, ValCid, ValFor, ValCla, ValPes, ValPag);
        }

        protected void RedirectPage(string ValOrd, string ValCid, string ValFor, string ValCla, string ValPes, int ValPag)
        {
            RedirectUrl = "/ofertas/preco.aspx?ORDE=" + ValOrd + "&CIDA=" + ValCid + "&LOJA=" + ValFor + "&CLAS=" + ValCla + "&PESQ=" + ValPes + "&PAGE=" + ValPag.ToString();
            Response.Redirect(RedirectUrl);
        }
        #endregion
    }
}