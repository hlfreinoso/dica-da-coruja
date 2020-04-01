using DicaDaCoruja.Negocios.Acesso;
using System;
using System.Data;
using System.Web;

namespace DicaDaCoruja.Interface.ofertas
{
    public partial class preço : System.Web.UI.Page
    {
        #region Declar Objects
        private LerSelect _ler;
        private LerAnuncioPesquisa _leranunciopesquisa;
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
            Pegar_Valor();
            _insert = new GravarLog();
            string ValIP = "";
            if (Request.UserHostAddress != null)
            {
                ValIP = Request.UserHostAddress;
            }
            string ValRequest = "Ord:" + ValOrd + " Cid:" + ValCid + " Loj:" + ValFor + " Cat:" + ValCla + " Pes:" + ValPes + " Pag:" + ValPag;
            _insert.InserirLog(ValIP, ValRequest);
            Refresh_Anuncios(ValOrd, ValCid, ValFor, ValCla, ValPes, ValPag);
        }

        protected void Pegar_Valor()
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
        }

        protected void Refresh_Anuncios(string Ordenar, string Cidade, string Fornecedor, string Classe, string Pesquisa, int NumPage)
        {
            BtnProximo.Enabled = true;
            if (ValPag == 0)
            {
                BtnAnterior.Enabled = false;
            }
            else
            {
                BtnAnterior.Enabled = true;
            }

            string ValString = "";
            if (ValCid != "")
            {
                ValString = ValString + " Cidade=" + ValCid;
            }
            if (ValCla != "")
            {
                ValString = ValString + " Categoria=" + ValCla;
            }
            if (ValFor != "")
            {
                ValString = ValString + " Loja=" + ValFor;
            }
            if (ValString == "")
            {
                ValString = "Sem filtros aplicados";
            }
            LabelFiltros.Text = "Filtrando por: " + ValString;
            if (ValPes == "")
            {
                ValString = "Sem pesquisa";
            }
            else
            {
                ValString = ValPes;
            }
            LabelPesquisa.Text = "Pesquisando por: " + ValString;
            _leranunciopesquisa = new LerAnuncioPesquisa();
            try
            {
                var SelectAnuncio = _leranunciopesquisa.LerAnuncio(Ordenar, Cidade, Fornecedor, Classe, Pesquisa, NumPage);
                if (SelectAnuncio.AnuncioTipo1 != null)
                {
                    if (SelectAnuncio.AnuncioTipo1 == "AZUL")
                    {
                        ImgLogo1.ImageUrl = "../Images/logo-azul.jpg";
                        LabelPreco1.CssClass = "TxtAzul";
                        this.FaixaAnuncio1.Attributes["class"] = "FaixaAnuncio FundoAzul TxtCenter";
                        Btn1.CssClass = "Btn Btn-Azl";
                    }
                    else if (SelectAnuncio.AnuncioTipo1 == "VERMELHO")
                    {
                        ImgLogo1.ImageUrl = "../Images/logo-vermelho.jpg";
                        LabelPreco1.CssClass = "TxtVermelho";
                        this.FaixaAnuncio1.Attributes["class"] = "FaixaAnuncio FundoVermelho TxtCenter";
                        Btn1.CssClass = "Btn Btn-Vrm";
                    }
                    LabelPreco1.Text = SelectAnuncio.AnuncioPreco1;
                    LabelTitulo1.Text = SelectAnuncio.AnuncioProduto1;
                    LabelValidade1.Text = SelectAnuncio.AnuncioDataFim1;
                    LabelLoja1.Text = SelectAnuncio.AnuncioFornecedor1;
                    Btn1.PostBackUrl = "";
                    Btn1.OnClientClick = "window.open('" + SelectAnuncio.AnuncioLink1 + "');";
                    Btn1.Text = "Ir para a loja";
                    ImgAnuncio1.ImageUrl = SelectAnuncio.AnuncioFoto1;
                    ImgAnuncio1.Attributes.Add("title", SelectAnuncio.AnuncioTitle1);
                }
                else
                {
                    ImgLogo1.ImageUrl = "../Images/logo-verde.jpg";
                    LabelPreco1.CssClass = "TxtVerde";
                    this.FaixaAnuncio1.Attributes["class"] = "FaixaAnuncio FundoVerde TxtCenter";
                    LabelPreco1.Text = "R$000000,00";
                    LabelTitulo1.Text = "Veja como é fácil";
                    LabelValidade1.Text = "Válido até: 31/12/9999";
                    LabelLoja1.Text = "Loja: DicaDaCoruja";
                    Btn1.CssClass = "Btn Btn-Vrd";
                    Btn1.Text = "Anuncie Já";
                    Btn1.PostBackUrl = "../Home/Anuncie.aspx";
                    Btn1.OnClientClick = "";
                    ImgAnuncio1.ImageUrl = "../Images/anuncio.jpg";
                }
                if (SelectAnuncio.AnuncioTipo2 != null)
                {
                    if (SelectAnuncio.AnuncioTipo2 == "AZUL")
                    {
                        ImgLogo2.ImageUrl = "../Images/logo-azul.jpg";
                        LabelPreco2.CssClass = "TxtAzul";
                        this.FaixaAnuncio2.Attributes["class"] = "FaixaAnuncio FundoAzul TxtCenter";
                        Btn2.CssClass = "Btn Btn-Azl";
                    }
                    else if (SelectAnuncio.AnuncioTipo2 == "VERMELHO")
                    {
                        ImgLogo2.ImageUrl = "../Images/logo-vermelho.jpg";
                        LabelPreco2.CssClass = "TxtVermelho";
                        this.FaixaAnuncio2.Attributes["class"] = "FaixaAnuncio FundoVermelho TxtCenter";
                        Btn2.CssClass = "Btn Btn-Vrm";
                    }
                    LabelPreco2.Text = SelectAnuncio.AnuncioPreco2;
                    LabelTitulo2.Text = SelectAnuncio.AnuncioProduto2;
                    LabelValidade2.Text = SelectAnuncio.AnuncioDataFim2;
                    LabelLoja2.Text = SelectAnuncio.AnuncioFornecedor2;
                    Btn2.PostBackUrl = "";
                    Btn2.OnClientClick = "window.open('" + SelectAnuncio.AnuncioLink2 + "');";
                    Btn2.Text = "Ir para a loja";
                    ImgAnuncio2.ImageUrl = SelectAnuncio.AnuncioFoto2;
                    ImgAnuncio2.Attributes.Add("title", SelectAnuncio.AnuncioTitle2);
                }
                else
                {
                    ImgLogo2.ImageUrl = "../Images/logo-verde.jpg";
                    LabelPreco2.CssClass = "TxtVerde";
                    this.FaixaAnuncio2.Attributes["class"] = "FaixaAnuncio FundoVerde TxtCenter";
                    LabelPreco2.Text = "R$000000,00";
                    LabelTitulo2.Text = "Veja como é fácil";
                    LabelValidade2.Text = "Válido até: 31/12/9999";
                    LabelLoja2.Text = "Loja: DicaDaCoruja";
                    Btn2.CssClass = "Btn Btn-Vrd";
                    Btn2.Text = "Anuncie Já";
                    Btn2.PostBackUrl = "../Home/Anuncie.aspx";
                    Btn2.OnClientClick = "";
                    ImgAnuncio2.ImageUrl = "../Images/anuncio.jpg";
                }
                if (SelectAnuncio.AnuncioTipo3 != null)
                {
                    if (SelectAnuncio.AnuncioTipo3 == "AZUL")
                    {
                        ImgLogo3.ImageUrl = "../Images/logo-azul.jpg";
                        LabelPreco3.CssClass = "TxtAzul";
                        this.FaixaAnuncio3.Attributes["class"] = "FaixaAnuncio FundoAzul TxtCenter";
                        Btn3.CssClass = "Btn Btn-Azl";
                    }
                    else if (SelectAnuncio.AnuncioTipo3 == "VERMELHO")
                    {
                        ImgLogo3.ImageUrl = "../Images/logo-vermelho.jpg";
                        LabelPreco3.CssClass = "TxtVermelho";
                        this.FaixaAnuncio3.Attributes["class"] = "FaixaAnuncio FundoVermelho TxtCenter";
                        Btn3.CssClass = "Btn Btn-Vrm";
                    }
                    LabelPreco3.Text = SelectAnuncio.AnuncioPreco3;
                    LabelTitulo3.Text = SelectAnuncio.AnuncioProduto3;
                    LabelValidade3.Text = SelectAnuncio.AnuncioDataFim3;
                    LabelLoja3.Text = SelectAnuncio.AnuncioFornecedor3;
                    Btn3.PostBackUrl = "";
                    Btn3.OnClientClick = "window.open('" + SelectAnuncio.AnuncioLink3 + "');";
                    Btn3.Text = "Ir para a loja";
                    ImgAnuncio3.ImageUrl = SelectAnuncio.AnuncioFoto3;
                    ImgAnuncio3.Attributes.Add("title", SelectAnuncio.AnuncioTitle3);
                }
                else
                {
                    ImgLogo3.ImageUrl = "../Images/logo-verde.jpg";
                    LabelPreco3.CssClass = "TxtVerde";
                    this.FaixaAnuncio3.Attributes["class"] = "FaixaAnuncio FundoVerde TxtCenter";
                    LabelPreco3.Text = "R$000000,00";
                    LabelTitulo3.Text = "Veja como é fácil";
                    LabelValidade3.Text = "Válido até: 31/12/9999";
                    LabelLoja3.Text = "Loja: DicaDaCoruja";
                    Btn3.CssClass = "Btn Btn-Vrd";
                    Btn3.Text = "Anuncie Já";
                    Btn3.PostBackUrl = "../Home/Anuncie.aspx";
                    Btn3.OnClientClick = "";
                    ImgAnuncio3.ImageUrl = "../Images/anuncio.jpg";
                }
                if (SelectAnuncio.AnuncioTipo4 != null)
                {
                    if (SelectAnuncio.AnuncioTipo4 == "AZUL")
                    {
                        ImgLogo4.ImageUrl = "../Images/logo-azul.jpg";
                        LabelPreco4.CssClass = "TxtAzul";
                        this.FaixaAnuncio4.Attributes["class"] = "FaixaAnuncio FundoAzul TxtCenter";
                        Btn4.CssClass = "Btn Btn-Azl";
                    }
                    else if (SelectAnuncio.AnuncioTipo4 == "VERMELHO")
                    {
                        ImgLogo4.ImageUrl = "../Images/logo-vermelho.jpg";
                        LabelPreco4.CssClass = "TxtVermelho";
                        this.FaixaAnuncio4.Attributes["class"] = "FaixaAnuncio FundoVermelho TxtCenter";
                        Btn4.CssClass = "Btn Btn-Vrm";
                    }
                    LabelPreco4.Text = SelectAnuncio.AnuncioPreco4;
                    LabelTitulo4.Text = SelectAnuncio.AnuncioProduto4;
                    LabelValidade4.Text = SelectAnuncio.AnuncioDataFim4;
                    LabelLoja4.Text = SelectAnuncio.AnuncioFornecedor4;
                    Btn4.PostBackUrl = "";
                    Btn4.OnClientClick = "window.open('" + SelectAnuncio.AnuncioLink4 + "');";
                    Btn4.Text = "Ir para a loja";
                    ImgAnuncio4.ImageUrl = SelectAnuncio.AnuncioFoto4;
                    ImgAnuncio4.Attributes.Add("title", SelectAnuncio.AnuncioTitle4);
                }
                else
                {
                    ImgLogo4.ImageUrl = "../Images/logo-verde.jpg";
                    LabelPreco4.CssClass = "TxtVerde";
                    this.FaixaAnuncio4.Attributes["class"] = "FaixaAnuncio FundoVerde TxtCenter";
                    LabelPreco4.Text = "R$000000,00";
                    LabelTitulo4.Text = "Veja como é fácil";
                    LabelValidade4.Text = "Válido até: 31/12/9999";
                    LabelLoja4.Text = "Loja: DicaDaCoruja";
                    Btn4.CssClass = "Btn Btn-Vrd";
                    Btn4.Text = "Anuncie Já";
                    Btn4.PostBackUrl = "../Home/Anuncie.aspx";
                    Btn4.OnClientClick = "";
                    ImgAnuncio4.ImageUrl = "../Images/anuncio.jpg";
                }
                if (SelectAnuncio.AnuncioTipo5 != null)
                {
                    if (SelectAnuncio.AnuncioTipo5 == "AZUL")
                    {
                        ImgLogo5.ImageUrl = "../Images/logo-azul.jpg";
                        LabelPreco5.CssClass = "TxtAzul";
                        this.FaixaAnuncio5.Attributes["class"] = "FaixaAnuncio FundoAzul TxtCenter";
                        Btn5.CssClass = "Btn Btn-Azl";
                    }
                    else if (SelectAnuncio.AnuncioTipo5 == "VERMELHO")
                    {
                        ImgLogo5.ImageUrl = "../Images/logo-vermelho.jpg";
                        LabelPreco5.CssClass = "TxtVermelho";
                        this.FaixaAnuncio5.Attributes["class"] = "FaixaAnuncio FundoVermelho TxtCenter";
                        Btn5.CssClass = "Btn Btn-Vrm";
                    }
                    LabelPreco5.Text = SelectAnuncio.AnuncioPreco5;
                    LabelTitulo5.Text = SelectAnuncio.AnuncioProduto5;
                    LabelValidade5.Text = SelectAnuncio.AnuncioDataFim5;
                    LabelLoja5.Text = SelectAnuncio.AnuncioFornecedor5;
                    Btn5.PostBackUrl = "";
                    Btn5.OnClientClick = "window.open('" + SelectAnuncio.AnuncioLink5 + "');";
                    Btn5.Text = "Ir para a loja";
                    ImgAnuncio5.ImageUrl = SelectAnuncio.AnuncioFoto5;
                    ImgAnuncio5.Attributes.Add("title", SelectAnuncio.AnuncioTitle5);
                }
                else
                {
                    ImgLogo5.ImageUrl = "../Images/logo-verde.jpg";
                    LabelPreco5.CssClass = "TxtVerde";
                    this.FaixaAnuncio5.Attributes["class"] = "FaixaAnuncio FundoVerde TxtCenter";
                    LabelPreco5.Text = "R$000000,00";
                    LabelTitulo5.Text = "Veja como é fácil";
                    LabelValidade5.Text = "Válido até: 31/12/9999";
                    LabelLoja5.Text = "Loja: DicaDaCoruja";
                    Btn5.CssClass = "Btn Btn-Vrd";
                    Btn5.Text = "Anuncie Já";
                    Btn5.PostBackUrl = "../Home/Anuncie.aspx";
                    Btn5.OnClientClick = "";
                    ImgAnuncio5.ImageUrl = "../Images/anuncio.jpg";
                }
                if (SelectAnuncio.AnuncioTipo6 != null)
                {
                    if (SelectAnuncio.AnuncioTipo6 == "AZUL")
                    {
                        ImgLogo6.ImageUrl = "../Images/logo-azul.jpg";
                        LabelPreco6.CssClass = "TxtAzul";
                        this.FaixaAnuncio6.Attributes["class"] = "FaixaAnuncio FundoAzul TxtCenter";
                        Btn6.CssClass = "Btn Btn-Azl";
                    }
                    else if (SelectAnuncio.AnuncioTipo6 == "VERMELHO")
                    {
                        ImgLogo6.ImageUrl = "../Images/logo-vermelho.jpg";
                        LabelPreco6.CssClass = "TxtVermelho";
                        this.FaixaAnuncio6.Attributes["class"] = "FaixaAnuncio FundoVermelho TxtCenter";
                        Btn6.CssClass = "Btn Btn-Vrm";
                    }
                    LabelPreco6.Text = SelectAnuncio.AnuncioPreco6;
                    LabelTitulo6.Text = SelectAnuncio.AnuncioProduto6;
                    LabelValidade6.Text = SelectAnuncio.AnuncioDataFim6;
                    LabelLoja6.Text = SelectAnuncio.AnuncioFornecedor6;
                    Btn6.PostBackUrl = "";
                    Btn6.OnClientClick = "window.open('" + SelectAnuncio.AnuncioLink6 + "');";
                    Btn6.Text = "Ir para a loja";
                    ImgAnuncio6.ImageUrl = SelectAnuncio.AnuncioFoto6;
                    ImgAnuncio6.Attributes.Add("title", SelectAnuncio.AnuncioTitle6);
                }
                else
                {
                    ImgLogo6.ImageUrl = "../Images/logo-verde.jpg";
                    LabelPreco6.CssClass = "TxtVerde";
                    this.FaixaAnuncio6.Attributes["class"] = "FaixaAnuncio FundoVerde TxtCenter";
                    LabelPreco6.Text = "R$000000,00";
                    LabelTitulo6.Text = "Veja como é fácil";
                    LabelValidade6.Text = "Válido até: 31/12/9999";
                    LabelLoja6.Text = "Loja: DicaDaCoruja";
                    Btn6.CssClass = "Btn Btn-Vrd";
                    Btn6.Text = "Anuncie Já";
                    Btn6.PostBackUrl = "../Home/Anuncie.aspx";
                    Btn6.OnClientClick = "";
                    ImgAnuncio6.ImageUrl = "../Images/anuncio.jpg";
                }
                if (SelectAnuncio.AnuncioTipo7 != null)
                {
                    if (SelectAnuncio.AnuncioTipo7 == "AZUL")
                    {
                        ImgLogo7.ImageUrl = "../Images/logo-azul.jpg";
                        LabelPreco7.CssClass = "TxtAzul";
                        this.FaixaAnuncio7.Attributes["class"] = "FaixaAnuncio FundoAzul TxtCenter";
                        Btn7.CssClass = "Btn Btn-Azl";
                    }
                    else if (SelectAnuncio.AnuncioTipo7 == "VERMELHO")
                    {
                        ImgLogo7.ImageUrl = "../Images/logo-vermelho.jpg";
                        LabelPreco7.CssClass = "TxtVermelho";
                        this.FaixaAnuncio7.Attributes["class"] = "FaixaAnuncio FundoVermelho TxtCenter";
                        Btn7.CssClass = "Btn Btn-Vrm";
                    }
                    LabelPreco7.Text = SelectAnuncio.AnuncioPreco7;
                    LabelTitulo7.Text = SelectAnuncio.AnuncioProduto7;
                    LabelValidade7.Text = SelectAnuncio.AnuncioDataFim7;
                    LabelLoja7.Text = SelectAnuncio.AnuncioFornecedor7;
                    Btn7.PostBackUrl = "";
                    Btn7.OnClientClick = "window.open('" + SelectAnuncio.AnuncioLink7 + "');";
                    Btn7.Text = "Ir para a loja";
                    ImgAnuncio7.ImageUrl = SelectAnuncio.AnuncioFoto7;
                    ImgAnuncio7.Attributes.Add("title", SelectAnuncio.AnuncioTitle7);
                }
                else
                {
                    ImgLogo7.ImageUrl = "../Images/logo-verde.jpg";
                    LabelPreco7.CssClass = "TxtVerde";
                    this.FaixaAnuncio7.Attributes["class"] = "FaixaAnuncio FundoVerde TxtCenter";
                    LabelPreco7.Text = "R$000000,00";
                    LabelTitulo7.Text = "Veja como é fácil";
                    LabelValidade7.Text = "Válido até: 31/12/9999";
                    LabelLoja7.Text = "Loja: DicaDaCoruja";
                    Btn7.CssClass = "Btn Btn-Vrd";
                    Btn7.Text = "Anuncie Já";
                    Btn7.PostBackUrl = "../Home/Anuncie.aspx";
                    Btn7.OnClientClick = "";
                    ImgAnuncio7.ImageUrl = "../Images/anuncio.jpg";
                }
                if (SelectAnuncio.AnuncioTipo8 != null)
                {
                    if (SelectAnuncio.AnuncioTipo8 == "AZUL")
                    {
                        ImgLogo8.ImageUrl = "../Images/logo-azul.jpg";
                        LabelPreco8.CssClass = "TxtAzul";
                        this.FaixaAnuncio8.Attributes["class"] = "FaixaAnuncio FundoAzul TxtCenter";
                        Btn8.CssClass = "Btn Btn-Azl";
                    }
                    else if (SelectAnuncio.AnuncioTipo8 == "VERMELHO")
                    {
                        ImgLogo8.ImageUrl = "../Images/logo-vermelho.jpg";
                        LabelPreco8.CssClass = "TxtVermelho";
                        this.FaixaAnuncio8.Attributes["class"] = "FaixaAnuncio FundoVermelho TxtCenter";
                        Btn8.CssClass = "Btn Btn-Vrm";
                    }
                    LabelPreco8.Text = SelectAnuncio.AnuncioPreco8;
                    LabelTitulo8.Text = SelectAnuncio.AnuncioProduto8;
                    LabelValidade8.Text = SelectAnuncio.AnuncioDataFim8;
                    LabelLoja8.Text = SelectAnuncio.AnuncioFornecedor8;
                    Btn8.PostBackUrl = "";
                    Btn8.OnClientClick = "window.open('" + SelectAnuncio.AnuncioLink8 + "');";
                    Btn8.Text = "Ir para a loja";
                    ImgAnuncio8.ImageUrl = SelectAnuncio.AnuncioFoto8;
                    ImgAnuncio8.Attributes.Add("title", SelectAnuncio.AnuncioTitle8);
                }
                else
                {
                    ImgLogo8.ImageUrl = "../Images/logo-verde.jpg";
                    LabelPreco8.CssClass = "TxtVerde";
                    this.FaixaAnuncio8.Attributes["class"] = "FaixaAnuncio FundoVerde TxtCenter";
                    LabelPreco8.Text = "R$000000,00";
                    LabelTitulo8.Text = "Veja como é fácil";
                    LabelValidade8.Text = "Válido até: 31/12/9999";
                    LabelLoja8.Text = "Loja: DicaDaCoruja";
                    Btn8.CssClass = "Btn Btn-Vrd";
                    Btn8.Text = "Anuncie Já";
                    Btn8.PostBackUrl = "../Home/Anuncie.aspx";
                    Btn8.OnClientClick = "";
                    ImgAnuncio8.ImageUrl = "../Images/anuncio.jpg";
                }
                if (SelectAnuncio.AnuncioTipo9 != null)
                {
                    if (SelectAnuncio.AnuncioTipo9 == "AZUL")
                    {
                        ImgLogo9.ImageUrl = "../Images/logo-azul.jpg";
                        LabelPreco9.CssClass = "TxtAzul";
                        this.FaixaAnuncio9.Attributes["class"] = "FaixaAnuncio FundoAzul TxtCenter";
                        Btn9.CssClass = "Btn Btn-Azl";
                    }
                    else if (SelectAnuncio.AnuncioTipo9 == "VERMELHO")
                    {
                        ImgLogo9.ImageUrl = "../Images/logo-vermelho.jpg";
                        LabelPreco9.CssClass = "TxtVermelho";
                        this.FaixaAnuncio9.Attributes["class"] = "FaixaAnuncio FundoVermelho TxtCenter";
                        Btn9.CssClass = "Btn Btn-Vrm";
                    }
                    LabelPreco9.Text = SelectAnuncio.AnuncioPreco9;
                    LabelTitulo9.Text = SelectAnuncio.AnuncioProduto9;
                    LabelValidade9.Text = SelectAnuncio.AnuncioDataFim9;
                    LabelLoja9.Text = SelectAnuncio.AnuncioFornecedor9;
                    Btn9.PostBackUrl = "";
                    Btn9.OnClientClick = "window.open('" + SelectAnuncio.AnuncioLink9 + "');";
                    Btn9.Text = "Ir para a loja";
                    ImgAnuncio9.ImageUrl = SelectAnuncio.AnuncioFoto9;
                    ImgAnuncio9.Attributes.Add("title", SelectAnuncio.AnuncioTitle9);
                }
                else
                {
                    ImgLogo9.ImageUrl = "../Images/logo-verde.jpg";
                    LabelPreco9.CssClass = "TxtVerde";
                    this.FaixaAnuncio9.Attributes["class"] = "FaixaAnuncio FundoVerde TxtCenter";
                    LabelPreco9.Text = "R$000000,00";
                    LabelTitulo9.Text = "Veja como é fácil";
                    LabelValidade9.Text = "Válido até: 31/12/9999";
                    LabelLoja9.Text = "Loja: DicaDaCoruja";
                    Btn9.CssClass = "Btn Btn-Vrd";
                    Btn9.Text = "Anuncie Já";
                    Btn9.PostBackUrl = "../Home/Anuncie.aspx";
                    Btn9.OnClientClick = "";
                    ImgAnuncio9.ImageUrl = "../Images/anuncio.jpg";
                }
                if (SelectAnuncio.AnuncioTipo10 != null)
                {
                    if (SelectAnuncio.AnuncioTipo10 == "AZUL")
                    {
                        ImgLogo10.ImageUrl = "../Images/logo-azul.jpg";
                        LabelPreco10.CssClass = "TxtAzul";
                        this.FaixaAnuncio10.Attributes["class"] = "FaixaAnuncio FundoAzul TxtCenter";
                        Btn10.CssClass = "Btn Btn-Azl";
                    }
                    else if (SelectAnuncio.AnuncioTipo10 == "VERMELHO")
                    {
                        ImgLogo10.ImageUrl = "../Images/logo-vermelho.jpg";
                        LabelPreco10.CssClass = "TxtVermelho";
                        this.FaixaAnuncio10.Attributes["class"] = "FaixaAnuncio FundoVermelho TxtCenter";
                        Btn10.CssClass = "Btn Btn-Vrm";
                    }
                    LabelPreco10.Text = SelectAnuncio.AnuncioPreco10;
                    LabelTitulo10.Text = SelectAnuncio.AnuncioProduto10;
                    LabelValidade10.Text = SelectAnuncio.AnuncioDataFim10;
                    LabelLoja10.Text = SelectAnuncio.AnuncioFornecedor10;
                    Btn10.PostBackUrl = "";
                    Btn10.OnClientClick = "window.open('" + SelectAnuncio.AnuncioLink10 + "');";
                    Btn10.Text = "Ir para a loja";
                    ImgAnuncio10.ImageUrl = SelectAnuncio.AnuncioFoto10;
                    ImgAnuncio10.Attributes.Add("title", SelectAnuncio.AnuncioTitle10);
                }
                else
                {
                    ImgLogo10.ImageUrl = "../Images/logo-verde.jpg";
                    LabelPreco10.CssClass = "TxtVerde";
                    this.FaixaAnuncio10.Attributes["class"] = "FaixaAnuncio FundoVerde TxtCenter";
                    LabelPreco10.Text = "R$000000,00";
                    LabelTitulo10.Text = "Veja como é fácil";
                    LabelValidade10.Text = "Válido até: 31/12/9999";
                    LabelLoja10.Text = "Loja: DicaDaCoruja";
                    Btn10.CssClass = "Btn Btn-Vrd";
                    Btn10.Text = "Anuncie Já";
                    Btn10.PostBackUrl = "../Home/Anuncie.aspx";
                    Btn10.OnClientClick = "";
                    ImgAnuncio10.ImageUrl = "../Images/anuncio.jpg";
                }
                if (SelectAnuncio.AnuncioTipo11 != null)
                {
                    if (SelectAnuncio.AnuncioTipo11 == "AZUL")
                    {
                        ImgLogo11.ImageUrl = "../Images/logo-azul.jpg";
                        LabelPreco11.CssClass = "TxtAzul";
                        this.FaixaAnuncio11.Attributes["class"] = "FaixaAnuncio FundoAzul TxtCenter";
                        Btn11.CssClass = "Btn Btn-Azl";
                    }
                    else if (SelectAnuncio.AnuncioTipo11 == "VERMELHO")
                    {
                        ImgLogo11.ImageUrl = "../Images/logo-vermelho.jpg";
                        LabelPreco11.CssClass = "TxtVermelho";
                        this.FaixaAnuncio11.Attributes["class"] = "FaixaAnuncio FundoVermelho TxtCenter";
                        Btn11.CssClass = "Btn Btn-Vrm";
                    }
                    LabelPreco11.Text = SelectAnuncio.AnuncioPreco11;
                    LabelTitulo11.Text = SelectAnuncio.AnuncioProduto11;
                    LabelValidade11.Text = SelectAnuncio.AnuncioDataFim11;
                    LabelLoja11.Text = SelectAnuncio.AnuncioFornecedor11;
                    Btn11.PostBackUrl = "";
                    Btn11.OnClientClick = "window.open('" + SelectAnuncio.AnuncioLink11 + "');";
                    Btn11.Text = "Ir para a loja";
                    ImgAnuncio11.ImageUrl = SelectAnuncio.AnuncioFoto11;
                    ImgAnuncio11.Attributes.Add("title", SelectAnuncio.AnuncioTitle11);
                }
                else
                {
                    ImgLogo11.ImageUrl = "../Images/logo-verde.jpg";
                    LabelPreco11.CssClass = "TxtVerde";
                    this.FaixaAnuncio11.Attributes["class"] = "FaixaAnuncio FundoVerde TxtCenter";
                    LabelPreco11.Text = "R$000000,00";
                    LabelTitulo11.Text = "Veja como é fácil";
                    LabelValidade11.Text = "Válido até: 31/12/9999";
                    LabelLoja11.Text = "Loja: DicaDaCoruja";
                    Btn11.CssClass = "Btn Btn-Vrd";
                    Btn11.Text = "Anuncie Já";
                    Btn11.PostBackUrl = "../Home/Anuncie.aspx";
                    Btn11.OnClientClick = "";
                    ImgAnuncio11.ImageUrl = "../Images/anuncio.jpg";
                }
                if (SelectAnuncio.AnuncioTipo12 != null)
                {
                    if (SelectAnuncio.AnuncioTipo12 == "AZUL")
                    {
                        ImgLogo12.ImageUrl = "../Images/logo-azul.jpg";
                        LabelPreco12.CssClass = "TxtAzul";
                        this.FaixaAnuncio12.Attributes["class"] = "FaixaAnuncio FundoAzul TxtCenter";
                        Btn12.CssClass = "Btn Btn-Azl";
                    }
                    else if (SelectAnuncio.AnuncioTipo12 == "VERMELHO")
                    {
                        ImgLogo12.ImageUrl = "../Images/logo-vermelho.jpg";
                        LabelPreco12.CssClass = "TxtVermelho";
                        this.FaixaAnuncio12.Attributes["class"] = "FaixaAnuncio FundoVermelho TxtCenter";
                        Btn12.CssClass = "Btn Btn-Vrm";
                    }
                    LabelPreco12.Text = SelectAnuncio.AnuncioPreco12;
                    LabelTitulo12.Text = SelectAnuncio.AnuncioProduto12;
                    LabelValidade12.Text = SelectAnuncio.AnuncioDataFim12;
                    LabelLoja12.Text = SelectAnuncio.AnuncioFornecedor12;
                    Btn12.PostBackUrl = "";
                    Btn12.OnClientClick = "window.open('" + SelectAnuncio.AnuncioLink12 + "');";
                    Btn12.Text = "Ir para a loja";
                    ImgAnuncio12.ImageUrl = SelectAnuncio.AnuncioFoto12;
                    ImgAnuncio12.Attributes.Add("title", SelectAnuncio.AnuncioTitle12);
                }
                else
                {
                    ImgLogo12.ImageUrl = "../Images/logo-verde.jpg";
                    LabelPreco12.CssClass = "TxtVerde";
                    this.FaixaAnuncio12.Attributes["class"] = "FaixaAnuncio FundoVerde TxtCenter";
                    LabelPreco12.Text = "R$000000,00";
                    LabelTitulo12.Text = "Veja como é fácil";
                    LabelValidade12.Text = "Válido até: 31/12/9999";
                    LabelLoja12.Text = "Loja: DicaDaCoruja";
                    Btn12.CssClass = "Btn Btn-Vrd";
                    Btn12.Text = "Anuncie Já";
                    Btn12.PostBackUrl = "../Home/Anuncie.aspx";
                    Btn12.OnClientClick = "";
                    ImgAnuncio12.ImageUrl = "../Images/anuncio.jpg";
                    BtnProximo.Enabled = false;
                }
            }
            catch (Exception)
            {

            }
            LabelPagina.Text = Convert.ToString(ValPag + 1);
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

        protected void BtnLimpar_Click(object sender, EventArgs e)
        {
            ValOrd = "";
            ValCid = "";
            ValFor = "";
            ValCla = "";
            ValPes = "";
            ValPag = 0;
            RedirectPage(ValOrd, ValCid, ValFor, ValCla, ValPes, ValPag);
        }

        protected void BtnAnterior_Click(object sender, EventArgs e)
        {
            Pegar_Valor();
            if (ValPag > 0)
            {
                ValPag = ValPag - 1;
                RedirectPage(ValOrd, ValCid, ValFor, ValCla, ValPes, ValPag);
            }
        }

        protected void BtnProximo_Click(object sender, EventArgs e)
        {
            Pegar_Valor();
            ValPag = ValPag + 1;
            RedirectPage(ValOrd, ValCid, ValFor, ValCla, ValPes, ValPag);
        }

        protected void Change_Ordenar(Object sender, EventArgs e)
        {
            if (DropOrdenar.SelectedItem.Value != "")
            {
                Pegar_Valor();
                ValOrd = DropOrdenar.SelectedItem.Value;
                ValPag = 0;
                RedirectPage(ValOrd, ValCid, ValFor, ValCla, ValPes, ValPag);
            }
        }

        protected void RedirectPage(string ValOrd, string ValCid, string ValFor, string ValCla, string ValPes, int ValPag)
        {
            RedirectUrl = "/ofertas/preco.aspx?ORDE=" + ValOrd + "&CIDA=" + ValCid + "&LOJA=" + ValFor + "&CLAS=" + ValCla + "&PESQ=" + ValPes + "&PAGE=" + ValPag.ToString();
            Response.Redirect(RedirectUrl);
        }
        #endregion
    }
}