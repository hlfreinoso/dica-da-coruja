<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="desconto.aspx.cs" Inherits="DicaDaCoruja.Interface.ofertas.desconto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ofertas dia a dia, melhores preços, descontos e promoções</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="content-language" content="pt-br" />
    <meta name="description" content="Onde comprar produtos com ofertas dia a dia, desconto, preços baixos e promoções. O Dica da Coruja trás descontos, promoção e dicas de Piracicaba e região."/>
    <meta name="keywords" content="comprar, produtos, ofertas, desconto, preços, promoção, dica, piracicaba, produto, oferta, descontos" />
    <meta name="robots" content="index, follow" />
    <meta name="googletbot" content="index, follow" />
    <meta name="author" content="Heitor Reinoso" />
    <meta name="distribution" content="Global" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <link href="../Images/logo-icone.ico" rel="shortcut icon"  type="image/x-icon" />
    <link href="../Content/jquery-ui.min.css" rel="stylesheet" />
    <link href="../Content/jquery-ui.structure.min.css" rel="stylesheet" />
    <link href="../Content/jquery-ui.theme.min.css" rel="stylesheet" />
    <link href="../Content/style-common.css" rel="stylesheet" />
    <link href="../Content/style-desconto-screen.css" rel="stylesheet" media="screen" />
    <link href="../Content/style-desconto.css" rel="stylesheet" />
    <link href="www.dicadacoruja.com/ofertas/desconto.aspx" rel="canonical" />
</head>
<body>
    <form id="Home" runat="server">
        <div id="Top">
            <div class="ImgAlgTopo">
                <img src="../Images/topo.jpg" class="ImgResponse" alt="Logo Dica da Coruja" />
            </div>
        </div>
        <div id="Bar">
            <ul>
                <li><a href="../ofertas/desconto.aspx">Home</a></li>
                <li><a href="../ofertas/sobre.aspx">Sobre</a></li>
                <li><a href="../ofertas/anuncie.aspx">Anuncie Já</a></li>
                <li><a><asp:DropDownList ID="DropCategoria" CssClass="DropDownBar Drop-Cat" AutoPostBack="True" OnSelectedIndexChanged="Change_Categoria" runat="server" /></a></li>
                <li><a><asp:DropDownList ID="DropCidade" CssClass="DropDownBar Drop-Cid" AutoPostBack="True" OnSelectedIndexChanged="Change_Cidade" runat="server" /></a></li>
                <li><a><asp:DropDownList ID="DropFornecedor" CssClass="DropDownBar Drop-For" AutoPostBack="True" OnSelectedIndexChanged="Change_Fornecedor" runat="server" /></a></li>
                <li><a href="../ofertas/contato.aspx">Contato</a></li>
                <li><div class="DivPesquisa">
                        <asp:TextBox ID="TxtPesquisa" placeholder=" O que você procura?" runat="server" CssClass="BoxPesquisa" onkeypress="EnterEvent(BtnPesquisa_Click)" />
                        <asp:button ID="BtnPesquisa" Text="" runat="server" OnClick="BtnPesquisa_Click" CssClass="Btn Btn-Pes" />
                </div></li>
            </ul>
        </div>
        <div id="Center">
            <h1>As melhores <em>ofertas</em>, <em>promoções</em> e <em>descontos</em> de <em>Piracicaba</em> e região</h1>
            <div class="carousel" data-autoplay="" data-transition="fade">
                <div><asp:hyperlink id="ImgLink1" runat="server" NavigateUrl="../ofertas/anuncie.aspx"><asp:image id="ImgPnl1" runat="server" imageurl="../Images/pnl1.jpg" AlternateText="Painel de ofertas, promoções e desconto de piracicaba e região" /></asp:hyperlink></div>
                <div><asp:hyperlink id="ImgLink2" runat="server" NavigateUrl="../ofertas/anuncie.aspx"><asp:image id="ImgPnl2" runat="server" imageurl="../Images/pnl2.jpg" AlternateText="Painel de ofertas, promoções e desconto de piracicaba e região" /></asp:hyperlink></div>
                <div><asp:hyperlink id="ImgLink3" runat="server" NavigateUrl="../ofertas/anuncie.aspx"><asp:image id="ImgPnl3" runat="server" imageurl="../Images/pnl3.jpg" AlternateText="Painel de ofertas, promoções e desconto de piracicaba e região" /></asp:hyperlink></div>
                <div><asp:hyperlink id="ImgLink4" runat="server" NavigateUrl="../ofertas/anuncie.aspx"><asp:image id="ImgPnl4" runat="server" imageurl="../Images/pnl4.jpg" AlternateText="Painel de ofertas, promoções e desconto de piracicaba e região"/></asp:hyperlink></div>
                <div><asp:hyperlink id="ImgLink5" runat="server" NavigateUrl="../ofertas/anuncie.aspx"><asp:image id="ImgPnl5" runat="server" imageurl="../Images/pnl5.jpg" AlternateText="Painel de ofertas, promoções e desconto de piracicaba e região"/></asp:hyperlink></div>
                <div><asp:hyperlink id="ImgLink6" runat="server" NavigateUrl="../ofertas/anuncie.aspx"><asp:image id="ImgPnl6" runat="server" imageurl="../Images/pnl6.jpg" AlternateText="Painel de ofertas, promoções e desconto de piracicaba e região"/></asp:hyperlink></div>
            </div>
        </div>
            <div class="MarginTop1">
                <h2 class="TxtAzul Margin0"><em>Ofertas</em> Relampago</h2>
                <h3 class="TxtAzul Margin0">As <em>ofertas</em> em destaque com muito <em>desconto</em> para você <em>comprar</em> em <em>Piracicaba</em> e região</h3>
            </div>
            <div class="BordaAzul Alt420 Larg100" >
                <div class="BoxAnuncio MarginTop1">
                    <div class="col-sm-6 col-md-3">
                        <div class="thumbnail">
                            <div class="Margin1 Larg100" >
                                <div class="ImgAlgOferta">
                                    <img src="../Images/logo-azul.jpg" class="ImgResponse" alt="Logo azul coruja preço anuncio e ofertas dica da coruja"/>
                                </div>
                                <div class="VerAlg ImgAlgPreco">
                                    <header>
                                    <h4 class="TxtAzul" id="fitText1"><asp:Label ID="LabelPrecoAzul1" Text="R$000000,00" runat="server" /></h4>
                                    </header>
                                </div>
                            </div>
                            <div class="ImgAlgProduto">
                                <asp:Image ID="ImgHomeAzul1" runat="server" CssClass="ImgResponse" ImageUrl="../Images/anuncio.jpg" />
                            </div>
                            <div class="caption">
                                <div class="FaixaAnuncio FundoAzul TxtCenter">
                                    <asp:Label ID="LabelTituloAzul1" Text="Veja como é fácil" runat="server" />
                                </div>
                                <div class="TxtCenter">
                                    <asp:Label ID="LabelValidadeAzul1" Text="Válido até: 31/12/9999" runat="server" />
                                    <br />
                                    <asp:Label ID="LabelLojaAzul1" Text="Loja: DicaDaCoruja" runat="server" CssClass="Txt14px"/>
                                    <div>
                                        <asp:LinkButton ID="BtnAzul1" Text="Anuncie já" PostBackUrl="~/ofertas/anuncie.aspx" class="Btn Btn-Azl" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="thumbnail">
                            <div class="Margin1 Larg100">
                                <div class="ImgAlgOferta">
                                    <img src="../Images/logo-azul.jpg" class="ImgResponse" alt="Logo azul coruja preço anuncio e ofertas dica da coruja" />
                                </div>
                                <div class="VerAlg ImgAlgPreco">
                                    <header>
                                    <h4 class="TxtAzul" id="fitText2"><asp:Label ID="LabelPrecoAzul2" Text="R$000000,00" runat="server" /></h4>
                                    </header>
                                </div>
                            </div>
                            <div class="ImgAlgProduto">
                                <asp:Image ID="ImgHomeAzul2" runat="server" CssClass="ImgResponse" ImageUrl="../Images/anuncio.jpg" />
                            </div>
                            <div class="caption">
                                <div class="FaixaAnuncio FundoAzul TxtCenter">
                                    <asp:Label ID="LabelTituloAzul2" Text="Veja como é fácil" runat="server" />
                                </div> 
                                <div class="TxtCenter">
                                    <asp:Label ID="LabelValidadeAzul2" Text="Válido até: 31/12/9999" runat="server" />
                                    <br />
                                    <asp:Label ID="LabelLojaAzul2" Text="Loja: DicaDaCoruja" runat="server" CssClass="Txt14px"/>
                                    <div>
                                        <asp:LinkButton ID="BtnAzul2" Text="Anuncie já" PostBackUrl="~/ofertas/anuncie.aspx" class="Btn Btn-Azl" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="thumbnail">
                            <div class="Margin1 Larg100">
                                <div class="ImgAlgOferta">
                                    <img src="../Images/logo-azul.jpg" class="ImgResponse" alt="Logo azul coruja preço anuncio e ofertas dica da coruja"/>
                                </div>
                                <div class="VerAlg ImgAlgPreco">
                                    <header>
                                    <h4 class="TxtAzul" id="fitText3"><asp:Label ID="LabelPrecoAzul3" Text="R$000000,00" runat="server" /></h4>
                                    </header>
                                </div>
                            </div>
                            <div class="ImgAlgProduto">
                                <asp:Image ID="ImgHomeAzul3" runat="server" CssClass="ImgResponse" ImageUrl="../Images/anuncio.jpg" />
                            </div>
                            <div class="caption">
                                <div class="FaixaAnuncio FundoAzul TxtCenter">
                                    <asp:Label ID="LabelTituloAzul3" Text="Veja como é fácil" runat="server" />
                                </div> 
                                <div class="TxtCenter">
                                    <asp:Label ID="LabelValidadeAzul3" Text="Válido até: 31/12/9999" runat="server" />
                                    <br />
                                    <asp:Label ID="LabelLojaAzul3" Text="Loja: DicaDaCoruja" runat="server" CssClass="Txt14px"/>
                                    <div>
                                        <asp:LinkButton ID="BtnAzul3" Text="Anuncie já" PostBackUrl="~/ofertas/anuncie.aspx" class="Btn Btn-Azl" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="thumbnail">
                            <div class="Margin1 Larg100">
                                <div class="ImgAlgOferta">
                                    <img src="../Images/logo-azul.jpg" class="ImgResponse" alt="Logo azul coruja preço anuncio e ofertas dica da coruja"/>
                                </div>
                                <div class="VerAlg ImgAlgPreco">
                                    <header>
                                    <h4 class="TxtAzul" id="fitText4"><asp:Label ID="LabelPrecoAzul4" Text="R$000000,00" runat="server" /></h4>
                                    </header>
                                </div>
                            </div>
                            <div class="ImgAlgProduto">
                                <asp:Image ID="ImgHomeAzul4" runat="server" CssClass="ImgResponse" ImageUrl="../Images/anuncio.jpg" />
                            </div>
                            <div class="caption">
                                <div class="FaixaAnuncio FundoAzul TxtCenter">
                                    <asp:Label ID="LabelTituloAzul4" Text="Veja como é fácil" runat="server" />
                                </div> 
                                <div class="TxtCenter">
                                    <asp:Label ID="LabelValidadeAzul4" Text="Válido até: 31/12/9999" runat="server" />
                                    <br />
                                    <asp:Label ID="LabelLojaAzul4" Text="Loja: DicaDaCoruja" runat="server" CssClass="Txt14px"/>
                                    <div>
                                        <asp:LinkButton ID="BtnAzul4" Text="Anuncie já" PostBackUrl="~/ofertas/anuncie.aspx" class="Btn Btn-Azl" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="BordaAzul MarginTop1 TxtCenter Larg100 BtnVejaMaisOfertas">
                <asp:Button ID="BtnVMO1" runat="server" PostBackUrl="~/ofertas/preco.aspx" Text="Veja Mais Ofertas!" CssClass="Transparente Larg100 Alt100 TxtAzul TxtVejaMais"/>
            </div>
            <div class="MarginTop1">
                <h2 class="TxtVermelho Margin0">Super <em>Ofertas</em></h2>
                <h3 class="TxtVermelho Margin0"><em>Dicas</em> de <em>produtos</em> com ótimos <em>preços</em> e <em>descontos</em> em <em>Piracicaba</em> e região</h3>
            </div>
            <div class="BordaVermelho Alt420 Larg100">
                <div class="BoxAnuncio MarginTop1">
                    <div class="col-sm-6 col-md-3">
                        <div class="thumbnail">
                            <div class="Margin1 Larg100">
                                <div class="ImgAlgOferta">
                                    <img src="../Images/logo-vermelho.jpg" class="ImgResponse" alt="Logo vermelho coruja preço anuncio e ofertas dica da coruja"/>
                                </div>
                                <div class="VerAlg ImgAlgPreco">
                                    <header>
                                    <h4 class="TxtVermelho" id="fitText5"><asp:Label ID="LabelPrecoVermelho1" Text="R$000000,00" runat="server" /></h4>
                                    </header>
                                </div>
                            </div>
                            <div class="ImgAlgProduto">
                                <asp:Image ID="ImgHomeVermelho1" runat="server" CssClass="ImgResponse" ImageUrl="../Images/anuncio.jpg" />
                            </div>
                            <div class="caption">
                                <div class="FaixaAnuncio FundoVermelho TxtCenter">
                                    <asp:Label ID="LabelTituloVermelho1" Text="Veja como é fácil" runat="server" />
                                </div> 
                                <div class="TxtCenter">
                                    <asp:Label ID="LabelValidadeVermelho1" Text="Válido até: 31/12/9999" runat="server" />
                                    <br />
                                    <asp:Label ID="LabelLojaVermelho1" Text="Loja: DicaDaCoruja" runat="server" CssClass="Txt14px"/>
                                    <div>
                                        <asp:LinkButton ID="BtnVermelho1" Text="Anuncie já" PostBackUrl="~/ofertas/anuncie.aspx" class="Btn Btn-Vrm" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="thumbnail">
                            <div class="Margin1 Larg100">
                                <div class="ImgAlgOferta">
                                    <img src="../Images/logo-vermelho.jpg" class="ImgResponse" alt="Logo vermelho coruja preço anuncio e ofertas dica da coruja"/>
                                </div>
                                <div class="VerAlg ImgAlgPreco">
                                    <header>
                                    <h4 class="TxtVermelho" id="fitText6"><asp:Label ID="LabelPrecoVermelho2" Text="R$000000,00" runat="server" /></h4>
                                    </header>
                                </div>
                            </div>
                            <div class="ImgAlgProduto">
                                <asp:Image ID="ImgHomeVermelho2" runat="server" CssClass="ImgResponse" ImageUrl="../Images/anuncio.jpg" />
                            </div>
                            <div class="caption">
                                <div class="FaixaAnuncio FundoVermelho TxtCenter">
                                    <asp:Label ID="LabelTituloVermelho2" Text="Veja como é fácil" runat="server" />
                                </div> 
                                <div class="TxtCenter">
                                    <asp:Label ID="LabelValidadeVermelho2" Text="Válido até: 31/12/9999" runat="server" />
                                    <br />
                                    <asp:Label ID="LabelLojaVermelho2" Text="Loja: DicaDaCoruja" runat="server" CssClass="Txt14px"/>
                                    <div>
                                        <asp:LinkButton ID="BtnVermelho2" Text="Anuncie já" PostBackUrl="~/ofertas/anuncie.aspx" class="Btn Btn-Vrm" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="thumbnail">
                            <div class="Margin1 Larg100">
                                <div class="ImgAlgOferta">
                                    <img src="../Images/logo-vermelho.jpg" class="ImgResponse" alt="Logo vermelho coruja preço anuncio e ofertas dica da coruja"/>
                                </div>
                                <div class="VerAlg ImgAlgPreco TxtVermelho">
                                    <header>
                                    <h4 class="TxtVermelho" id="fitText7"><asp:Label ID="LabelPrecoVermelho3" Text="R$000000,00" runat="server" /></h4>
                                    </header>
                                </div>
                            </div>
                            <div class="ImgAlgProduto">
                                <asp:Image ID="ImgHomeVermelho3" runat="server" CssClass="ImgResponse" ImageUrl="../Images/anuncio.jpg" />
                            </div>
                            <div class="caption">
                                <div class="FaixaAnuncio FundoVermelho TxtCenter">
                                    <asp:Label ID="LabelTituloVermelho3" Text="Veja como é fácil" runat="server" />
                                </div> 
                                <div class="TxtCenter">
                                    <asp:Label ID="LabelValidadeVermelho3" Text="Válido até: 31/12/9999" runat="server" />
                                    <br />
                                    <asp:Label ID="LabelLojaVermelho3" Text="Loja: DicaDaCoruja" runat="server" CssClass="Txt14px"/>
                                    <div>
                                        <asp:LinkButton ID="BtnVermelho3" Text="Anuncie já" PostBackUrl="~/ofertas/anuncie.aspx" class="Btn Btn-Vrm" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="thumbnail">
                            <div class="Margin1 Larg100">
                                <div class="ImgAlgOferta">
                                    <img src="../Images/logo-vermelho.jpg" class="ImgResponse" alt="Logo vermelho coruja preço anuncio e ofertas dica da coruja"/>
                                </div>
                                <div class="VerAlg ImgAlgPreco">
                                    <header>
                                    <h4 class="TxtVermelho" id="fitText8"><asp:Label ID="LabelPrecoVermelho4" Text="R$000000,00" runat="server" /></h4>
                                    </header>
                                </div>
                            </div>
                            <div class="ImgAlgProduto">
                                <asp:Image ID="ImgHomeVermelho4" runat="server" CssClass="ImgResponse" ImageUrl="../Images/anuncio.jpg" />
                            </div>
                            <div class="caption">
                                <div class="FaixaAnuncio FundoVermelho TxtCenter">
                                    <asp:Label ID="LabelTituloVermelho4" Text="Veja como é fácil" runat="server" />
                                </div> 
                                <div class="TxtCenter">
                                    <asp:Label ID="LabelValidadeVermelho4" Text="Válido até: 31/12/9999" runat="server" />
                                    <br />
                                    <asp:Label ID="LabelLojaVermelho4" Text="Loja: DicaDaCoruja" runat="server" CssClass="Txt14px"/>
                                    <div>
                                        <asp:LinkButton ID="BtnVermelho4" Text="Anuncie já" PostBackUrl="~/ofertas/anuncie.aspx" class="Btn Btn-Vrm" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="BordaVermelho MarginTop1 TxtCenter Larg100 BtnVejaMaisOfertas">
                <asp:Button ID="BtnVMO2" runat="server" PostBackUrl="~/ofertas/preco.aspx" Text="Veja Mais Ofertas!" CssClass="Transparente Larg100 Alt100 TxtVermelho TxtVejaMais"/>
            </div>
            <div class="MarginTop1">
                <h2 class="TxtVerde Margin0"><em>Ofertas</em> em Destaque</h2>
                <h3 class="TxtVerde Margin0">Encontre as <em>ofertas</em> e <em>promoções</em> que estão em destaque em <em>Piracicaba</em> e região</h3>
            </div>
            <div class="BordaVerde Alt420 Larg100">
                <div class="BoxAnuncio Margin1">
                    <div class="col-sm-6 col-md-3">
                        <div class="thumbnail">
                            <div class="Margin1 Larg100">
                                <div class="ImgAlgOferta">
                                    <img src="../Images/logo-verde.jpg" class="ImgResponse" alt="Logo verde coruja preço anuncio e ofertas dica da coruja"/>
                                </div>
                                <div class="VerAlg ImgAlgPreco">
                                    <header>
                                    <h4 class="TxtVerde" id="fitText9"><asp:Label ID="LabelPrecoVerde1" Text="R$000000,00" runat="server" /></h4>
                                    </header>
                                </div>
                            </div>
                            <div class="ImgAlgProduto">
                                <asp:Image ID="ImgHomeVerde1" runat="server" CssClass="ImgResponse" ImageUrl="../Images/anuncio.jpg" />
                            </div>
                            <div class="caption">
                                <div class="FaixaAnuncio FundoVerde TxtCenter">
                                    <asp:Label ID="LabelTituloVerde1" Text="Veja como é fácil" runat="server" />
                                </div> 
                                <div class="TxtCenter">
                                    <asp:Label ID="LabelValidadeVerde1" Text="Válido até: 31/12/9999" runat="server" />
                                    <br />
                                    <asp:Label ID="LabelLojaVerde1" Text="Loja: DicaDaCoruja" runat="server" CssClass="Txt14px"/>
                                    <div>
                                        <asp:LinkButton ID="BtnVerde1" Text="Anuncie já" PostBackUrl="~/ofertas/anuncie.aspx" class="Btn Btn-Vrd" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="thumbnail">
                            <div class="Margin1 Larg100">
                                <div class="ImgAlgOferta">
                                    <img src="../Images/logo-verde.jpg" class="ImgResponse" alt="Logo verde coruja preço anuncio e ofertas dica da coruja"/>
                                </div>
                                <div class="VerAlg ImgAlgPreco">
                                    <header>
                                    <h4 class="TxtVerde" id="fitText10"><asp:Label ID="LabelPrecoVerde2" Text="R$000000,00" runat="server" /></h4>
                                    </header>
                                </div>
                            </div>
                            <div class="ImgAlgProduto">
                                <asp:Image ID="ImgHomeVerde2" runat="server" CssClass="ImgResponse" ImageUrl="../Images/anuncio.jpg" />
                            </div>
                            <div class="caption">
                                <div class="FaixaAnuncio FundoVerde TxtCenter">
                                    <asp:Label ID="LabelTituloVerde2" Text="Veja como é fácil" runat="server" />
                                </div> 
                                <div class="TxtCenter">
                                    <asp:Label ID="LabelValidadeVerde2" Text="Válido até: 31/12/9999" runat="server" />
                                    <br />
                                    <asp:Label ID="LabelLojaVerde2" Text="Loja: DicaDaCoruja" runat="server" CssClass="Txt14px"/>
                                    <div>
                                        <asp:LinkButton ID="BtnVerde2" Text="Anuncie já" PostBackUrl="~/ofertas/anuncie.aspx" class="Btn Btn-Vrd" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="thumbnail">
                            <div class="Margin1 Larg100">
                                <div class="ImgAlgOferta">
                                    <img src="../Images/logo-verde.jpg" class="ImgResponse" alt="Logo verde coruja preço anuncio e ofertas dica da coruja"/>
                                </div>
                                <div class="VerAlg ImgAlgPreco">
                                    <header>
                                    <h4 class="TxtVerde" id="fitText11"><asp:Label ID="LabelPrecoVerde3" Text="R$000000,00" runat="server" /></h4>
                                    </header>
                                </div>
                            </div>
                            <div class="ImgAlgProduto">
                                <asp:Image ID="ImgHomeVerde3" runat="server" CssClass="ImgResponse" ImageUrl="../Images/anuncio.jpg" />
                            </div>
                            <div class="caption">
                                <div class="FaixaAnuncio FundoVerde TxtCenter">
                                    <asp:Label ID="LabelTituloVerde3" Text="Veja como é fácil" runat="server" />
                                </div> 
                                <div class="TxtCenter">
                                    <asp:Label ID="LabelValidadeVerde3" Text="Válido até: 31/12/9999" runat="server" />
                                    <br />
                                    <asp:Label ID="LabelLojaVerde3" Text="Loja: DicaDaCoruja" runat="server" CssClass="Txt14px"/>
                                    <div>
                                        <asp:LinkButton ID="BtnVerde3" Text="Anuncie já" PostBackUrl="~/ofertas/anuncie.aspx" class="Btn Btn-Vrd" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="thumbnail">
                            <div class="Margin1 Larg100">
                                <div class="ImgAlgOferta">
                                    <img src="../Images/logo-verde.jpg" class="ImgResponse" alt="Logo verde coruja preço anuncio e ofertas dica da coruja"/>
                                </div>
                                <div class="VerAlg ImgAlgPreco">
                                    <header>
                                    <h4 class="TxtVerde" id="fitText12"><asp:Label ID="LabelPrecoVerde4" Text="R$000000,00" runat="server" /></h4>
                                    </header>
                                </div>
                            </div>
                            <div class="ImgAlgProduto">
                                <asp:Image ID="ImgHomeVerde4" runat="server" CssClass="ImgResponse" ImageUrl="../Images/anuncio.jpg" />
                            </div>
                            <div class="caption">
                                <div class="FaixaAnuncio FundoVerde TxtCenter">
                                    <asp:Label ID="LabelTituloVerde4" Text="Veja como é fácil" runat="server" />
                                </div> 
                                <div class="TxtCenter">
                                    <asp:Label ID="LabelValidadeVerde4" Text="Válido até: 31/12/9999" runat="server" />
                                    <br />
                                    <asp:Label ID="LabelLojaVerde4" Text="Loja: DicaDaCoruja" runat="server" CssClass="Txt14px"/>
                                    <div>
                                        <asp:LinkButton ID="BtnVerde4" Text="Anuncie já" PostBackUrl="~/ofertas/anuncie.aspx" class="Btn Btn-Vrd" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        <div class="BordaVerde MarginTop1 TxtCenter Larg100 BtnVejaMaisOfertas">
            <asp:Button ID="BtnVMO3" runat="server" PostBackUrl="~/ofertas/preco.aspx" Text="Veja Mais Ofertas!" CssClass="Transparente Larg100 Alt100 TxtVerde TxtVejaMais"/>
        </div>
        <h2 class="TxtCenter">Veja mais <em>ofertas</em>, <em>promoções</em>, <em>desconto</em> com os melhores <em>preços</em> de <em>piracicaba</em> e região <asp:HyperLink id="HyperLink1" runat="server" NavigateUrl="../ofertas/preco.aspx">aqui</asp:HyperLink></h2>
        <div id="Footer">
            <asp:hyperlink id="LinkFacebook" runat="server" NavigateUrl="https://www.facebook.com/Dica-da-Coruja-329861277475453/"><asp:image id="LogoFacebook" runat="server" imageurl="../Images/btn-facebook.jpg" AlternateText="Botão FaceBook Dica da Coruja Piracicaba e região" /></asp:hyperlink>
            <asp:hyperlink id="LinkTwitter" runat="server" NavigateUrl="https://twitter.com/Dicadacoruja"><asp:image id="LogoTwitter" runat="server" imageurl="../Images/btn-twitter.jpg" AlternateText="Botão Twitter Dica da Coruja Piracicaba e região" /></asp:hyperlink>
            <asp:hyperlink id="LinkGooglePlus" runat="server" NavigateUrl="https://plus.google.com/105080310387510152605"><asp:image id="LogoGooglePlus" runat="server" imageurl="../Images/btn-google-plus.jpg" AlternateText="Botão Google Plus Dica da Coruja Piracicaba e região" /></asp:hyperlink>
            <h5>Desenvolvido por heitor.suporte@hotmail.com</h5>
        </div>
    </form>
    <script type="text/javascript" src="../Scripts/jquery.js"></script>
    <script type="text/javascript" src="../Scripts/jquery-ui.min.js"></script>
    <script type="text/javascript" src="../Scripts/java-common.js"></script>
    <script type="text/javascript" src="../Scripts/java-desconto.js"></script>
    <script>
        (function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date(); a = s.createElement(o),
                m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
        })(window, document, 'script', 'https://www.google-analytics.com/analytics.js', 'ga');
        ga('create', 'UA-105384906-1', 'auto');
        ga('send', 'pageview');
    </script>
    <script type="text/javascript">
        $("#fitText1").fitText(0.75);
        $("#fitText2").fitText(0.75);
        $("#fitText3").fitText(0.75);
        $("#fitText4").fitText(0.75);
        $("#fitText5").fitText(0.75);
        $("#fitText6").fitText(0.75);
        $("#fitText7").fitText(0.75);
        $("#fitText8").fitText(0.75);
        $("#fitText9").fitText(0.75);
        $("#fitText10").fitText(0.75);
        $("#fitText11").fitText(0.75);
        $("#fitText12").fitText(0.75);
    </script>
</body>
</html>
