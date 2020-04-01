<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="preco.aspx.cs" Inherits="DicaDaCoruja.Interface.ofertas.preço" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ofertas dia a dia, melhores precos, descontos e promocoes</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta http-equiv="content-language" content="pt-br" />
    <meta name="description" content="Onde comprar produtos com ofertas dia a dia e desconto, preços baixos e promoção. Dicas imperdíveis no Dica da Coruja"/>
    <meta name="keywords" content="comprar, produtos, ofertas, desconto, preços, promoção, dicas, piracicaba, produto, oferta, descontos, preço, promoções, dica" />
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
    <link href="../Content/style-preco.css" rel="stylesheet" />
</head>
<body>
    <form id="Home" runat="server">
        <div id="Top">
            <div class="ImgAlgTopo">
                <img src="../Images/topo.jpg" class="ImgResponse" />
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
            <div style="min-height: 30px; width: 100%; display: table; margin-top: -10px;">
                <div style="float: left; height: 100%;">
                    <div style="float:left; margin-right: 5px; display: table;">
                        <asp:Button ID="BtnLimpar" runat="server" CssClass="Transparente" style="border: 1px solid black; margin-top: -2px;" OnClick="BtnLimpar_Click" Text="Limpar" />
                    </div>
                    <div style="float:left; margin-right: 5px;">
                        <asp:Label ID="LabelPesquisa" runat="server" Text=""/>
                    </div>
                    <div style="float:left;">
                        <asp:Label ID="LabelFiltros" runat="server" Text=""/>
                    </div>
                </div>
                <div style="float: right!important; height: 100%; right: auto; margin-bottom: 5px;">
                    <asp:DropDownList ID="DropOrdenar" AutoPostBack="True" OnSelectedIndexChanged="Change_Ordenar" runat="server">
                        <asp:ListItem Selected="True" Value="">Ordenar</asp:ListItem>
                        <asp:ListItem Value="ASCE">Pelo menor preço</asp:ListItem>
                        <asp:ListItem Value="DESC">Pelo maior preço</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="BordaAzulEsc Alt1250" style="width:100%;text-align:center">
                <div class="BoxAnuncio MarginTop1">
                    <div class="col-sm-6 col-md-3">
                        <div class="thumbnail">
                            <div class="Margin1" style="display: table; width: 100%;">
                                <div class="ImgAlgOferta">
                                    <asp:Image ID="ImgLogo1" runat="server" CssClass="ImgResponse" ImageUrl="../Images/logo-verde.jpg" />
                                </div>
                                <div class="VerAlg ImgAlgPreco">
                                    <header>
                                    <h4 class="TxtVerde" id="fitText1"><asp:Label ID="LabelPreco1" Text="R$000000,00" runat="server" /></h4>
                                    </header>
                                </div>
                            </div>
                            <div class="ImgAlgProduto">
                                <asp:Image ID="ImgAnuncio1" runat="server" CssClass="ImgResponse" ImageUrl="../Images/anuncio.jpg" />
                            </div>
                            <div class="caption">
                                <div id="FaixaAnuncio1" runat="server" class="FaixaAnuncio FundoVerde TxtCenter">
                                    <asp:Label ID="LabelTitulo1" Text="Veja como é fácil" runat="server" />
                                </div> 
                                <div class="TxtCenter">
                                    <asp:Label ID="LabelValidade1" Text="Válido até: 31/12/9999" runat="server" />
                                    <br />
                                    <asp:Label ID="LabelLoja1" Text="Loja: DicaDaCoruja" runat="server" style="font-size: 14px;"/>
                                    <div>
                                        <asp:LinkButton ID="Btn1" Text="Anuncie já" PostBackUrl="~/ofertas/anuncie.aspx" class="Btn Btn-Vrd" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="thumbnail">
                            <div class="Margin1" style="display: table; width: 100%;">
                                <div class="ImgAlgOferta">
                                    <asp:Image ID="ImgLogo2" runat="server" CssClass="ImgResponse" ImageUrl="../Images/logo-verde.jpg" />
                                </div>
                                <div class="VerAlg ImgAlgPreco">
                                    <header>
                                    <h4 class="TxtVerde" id="fitText2"><asp:Label ID="LabelPreco2" Text="R$000000,00" runat="server" /></h4>
                                    </header>
                                </div>
                            </div>
                            <div class="ImgAlgProduto">
                                <asp:Image ID="ImgAnuncio2" runat="server" CssClass="ImgResponse" ImageUrl="../Images/anuncio.jpg" />
                            </div>
                            <div class="caption">
                                <div id="FaixaAnuncio2" runat="server" class="FaixaAnuncio FundoVerde TxtCenter">
                                    <asp:Label ID="LabelTitulo2" Text="Veja como é fácil" runat="server" />
                                </div> 
                                <div class="TxtCenter">
                                    <asp:Label ID="LabelValidade2" Text="Válido até: 31/12/9999" runat="server" />
                                    <br />
                                    <asp:Label ID="LabelLoja2" Text="Loja: DicaDaCoruja" runat="server" style="font-size: 14px;"/>
                                    <div>
                                        <asp:LinkButton ID="Btn2" Text="Anuncie já" PostBackUrl="~/ofertas/anuncie.aspx" class="Btn Btn-Vrd" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="thumbnail">
                            <div class="Margin1" style="display: table; width: 100%;">
                                <div class="ImgAlgOferta">
                                    <asp:Image ID="ImgLogo3" runat="server" CssClass="ImgResponse" ImageUrl="../Images/logo-verde.jpg" />
                                </div>
                                <div class="VerAlg ImgAlgPreco">
                                    <header>
                                    <h4 class="TxtVerde" id="fitText3"><asp:Label ID="LabelPreco3" Text="R$000000,00" runat="server" /></h4>
                                    </header>
                                </div>
                            </div>
                            <div class="ImgAlgProduto">
                                <asp:Image ID="ImgAnuncio3" runat="server" CssClass="ImgResponse" ImageUrl="../Images/anuncio.jpg" />
                            </div>
                            <div class="caption">
                                <div id="FaixaAnuncio3" runat="server" class="FaixaAnuncio FundoVerde TxtCenter">
                                    <asp:Label ID="LabelTitulo3" Text="Veja como é fácil" runat="server" />
                                </div> 
                                <div class="TxtCenter">
                                    <asp:Label ID="LabelValidade3" Text="Válido até: 31/12/9999" runat="server" />
                                    <br />
                                    <asp:Label ID="LabelLoja3" Text="Loja: DicaDaCoruja" runat="server" style="font-size: 14px;"/>
                                    <div>
                                        <asp:LinkButton ID="Btn3" Text="Anuncie já" PostBackUrl="~/ofertas/anuncie.aspx" class="Btn Btn-Vrd" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="thumbnail">
                            <div class="Margin1" style="display: table; width: 100%;">
                                <div class="ImgAlgOferta">
                                    <asp:Image ID="ImgLogo4" runat="server" CssClass="ImgResponse" ImageUrl="../Images/logo-verde.jpg" />
                                </div>
                                <div class="VerAlg ImgAlgPreco">
                                    <header>
                                    <h4 class="TxtVerde" id="fitText4"><asp:Label ID="LabelPreco4" Text="R$000000,00" runat="server" /></h4>
                                    </header>
                                </div>
                            </div>
                            <div class="ImgAlgProduto">
                                <asp:Image ID="ImgAnuncio4" runat="server" CssClass="ImgResponse" ImageUrl="../Images/anuncio.jpg" />
                            </div>
                            <div class="caption">
                                <div id="FaixaAnuncio4" runat="server" class="FaixaAnuncio FundoVerde TxtCenter">
                                    <asp:Label ID="LabelTitulo4" Text="Veja como é fácil" runat="server" />
                                </div> 
                                <div class="TxtCenter">
                                    <asp:Label ID="LabelValidade4" Text="Válido até: 31/12/9999" runat="server" />
                                    <br />
                                    <asp:Label ID="LabelLoja4" Text="Loja: DicaDaCoruja" runat="server" style="font-size: 14px;"/>
                                    <div>
                                        <asp:LinkButton ID="Btn4" Text="Anuncie já" PostBackUrl="~/ofertas/anuncie.aspx" class="Btn Btn-Vrd" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="thumbnail">
                            <div class="Margin1" style="display: table; width: 100%;">
                                <div class="ImgAlgOferta">
                                    <asp:Image ID="ImgLogo5" runat="server" CssClass="ImgResponse" ImageUrl="../Images/logo-verde.jpg" />
                                </div>
                                <div class="VerAlg ImgAlgPreco">
                                    <header>
                                    <h4 class="TxtVerde" id="fitText5"><asp:Label ID="LabelPreco5" Text="R$000000,00" runat="server" /></h4>
                                    </header>
                                </div>
                            </div>
                            <div class="ImgAlgProduto">
                                <asp:Image ID="ImgAnuncio5" runat="server" CssClass="ImgResponse" ImageUrl="../Images/anuncio.jpg" />
                            </div>
                            <div class="caption">
                                <div id="FaixaAnuncio5" runat="server" class="FaixaAnuncio FundoVerde TxtCenter">
                                    <asp:Label ID="LabelTitulo5" Text="Veja como é fácil" runat="server" />
                                </div> 
                                <div class="TxtCenter">
                                    <asp:Label ID="LabelValidade5" Text="Válido até: 31/12/9999" runat="server" />
                                    <br />
                                    <asp:Label ID="LabelLoja5" Text="Loja: DicaDaCoruja" runat="server" style="font-size: 14px;"/>
                                    <div>
                                        <asp:LinkButton ID="Btn5" Text="Anuncie já" PostBackUrl="~/ofertas/anuncie.aspx" class="Btn Btn-Vrd" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="thumbnail">
                            <div class="Margin1" style="display: table; width: 100%;">
                                <div class="ImgAlgOferta">
                                    <asp:Image ID="ImgLogo6" runat="server" CssClass="ImgResponse" ImageUrl="../Images/logo-verde.jpg" />
                                </div>
                                <div class="VerAlg ImgAlgPreco">
                                    <header>
                                    <h4 class="TxtVerde" id="fitText6"><asp:Label ID="LabelPreco6" Text="R$000000,00" runat="server" /></h4>
                                    </header>
                                </div>
                            </div>
                            <div class="ImgAlgProduto">
                                <asp:Image ID="ImgAnuncio6" runat="server" CssClass="ImgResponse" ImageUrl="../Images/anuncio.jpg" />
                            </div>
                            <div class="caption">
                                <div id="FaixaAnuncio6" runat="server" class="FaixaAnuncio FundoVerde TxtCenter">
                                    <asp:Label ID="LabelTitulo6" Text="Veja como é fácil" runat="server" />
                                </div> 
                                <div class="TxtCenter">
                                    <asp:Label ID="LabelValidade6" Text="Válido até: 31/12/9999" runat="server" />
                                    <br />
                                    <asp:Label ID="LabelLoja6" Text="Loja: DicaDaCoruja" runat="server" style="font-size: 14px;"/>
                                    <div>
                                        <asp:LinkButton ID="Btn6" Text="Anuncie já" PostBackUrl="~/ofertas/anuncie.aspx" class="Btn Btn-Vrd" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="thumbnail">
                            <div class="Margin1" style="display: table; width: 100%;">
                                <div class="ImgAlgOferta">
                                    <asp:Image ID="ImgLogo7" runat="server" CssClass="ImgResponse" ImageUrl="../Images/logo-verde.jpg" />
                                </div>
                                <div class="VerAlg ImgAlgPreco">
                                    <header>
                                    <h4 class="TxtVerde" id="fitText7"><asp:Label ID="LabelPreco7" Text="R$000000,00" runat="server" /></h4>
                                    </header>
                                </div>
                            </div>
                            <div class="ImgAlgProduto">
                                <asp:Image ID="ImgAnuncio7" runat="server" CssClass="ImgResponse" ImageUrl="../Images/anuncio.jpg" />
                            </div>
                            <div class="caption">
                                <div id="FaixaAnuncio7" runat="server" class="FaixaAnuncio FundoVerde TxtCenter">
                                    <asp:Label ID="LabelTitulo7" Text="Veja como é fácil" runat="server" />
                                </div> 
                                <div class="TxtCenter">
                                    <asp:Label ID="LabelValidade7" Text="Válido até: 31/12/9999" runat="server" />
                                    <br />
                                    <asp:Label ID="LabelLoja7" Text="Loja: DicaDaCoruja" runat="server" style="font-size: 14px;"/>
                                    <div>
                                        <asp:LinkButton ID="Btn7" Text="Anuncie já" PostBackUrl="~/ofertas/anuncie.aspx" class="Btn Btn-Vrd" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="thumbnail">
                            <div class="Margin1" style="display: table; width: 100%;">
                                <div class="ImgAlgOferta">
                                    <asp:Image ID="ImgLogo8" runat="server" CssClass="ImgResponse" ImageUrl="../Images/logo-verde.jpg" />
                                </div>
                                <div class="VerAlg ImgAlgPreco">
                                    <header>
                                    <h4 class="TxtVerde" id="fitText8"><asp:Label ID="LabelPreco8" Text="R$000000,00" runat="server" /></h4>
                                    </header>
                                </div>
                            </div>
                            <div class="ImgAlgProduto">
                                <asp:Image ID="ImgAnuncio8" runat="server" CssClass="ImgResponse" ImageUrl="../Images/anuncio.jpg" />
                            </div>
                            <div class="caption">
                                <div id="FaixaAnuncio8" runat="server" class="FaixaAnuncio FundoVerde TxtCenter">
                                    <asp:Label ID="LabelTitulo8" Text="Veja como é fácil" runat="server" />
                                </div> 
                                <div class="TxtCenter">
                                    <asp:Label ID="LabelValidade8" Text="Válido até: 31/12/9999" runat="server" />
                                    <br />
                                    <asp:Label ID="LabelLoja8" Text="Loja: DicaDaCoruja" runat="server" style="font-size: 14px;"/>
                                    <div>
                                        <asp:LinkButton ID="Btn8" Text="Anuncie já" PostBackUrl="~/ofertas/anuncie.aspx" class="Btn Btn-Vrd" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="thumbnail">
                            <div class="Margin1" style="display: table; width: 100%;">
                                <div class="ImgAlgOferta">
                                    <asp:Image ID="ImgLogo9" runat="server" CssClass="ImgResponse" ImageUrl="../Images/logo-verde.jpg" />
                                </div>
                                <div class="VerAlg ImgAlgPreco">
                                    <header>
                                    <h4 class="TxtVerde" id="fitText9"><asp:Label ID="LabelPreco9" Text="R$000000,00" runat="server" /></h4>
                                    </header>
                                </div>
                            </div>
                            <div class="ImgAlgProduto">
                                <asp:Image ID="ImgAnuncio9" runat="server" CssClass="ImgResponse" ImageUrl="../Images/anuncio.jpg" />
                            </div>
                            <div class="caption">
                                <div id="FaixaAnuncio9" runat="server" class="FaixaAnuncio FundoVerde TxtCenter">
                                    <asp:Label ID="LabelTitulo9" Text="Veja como é fácil" runat="server" />
                                </div> 
                                <div class="TxtCenter">
                                    <asp:Label ID="LabelValidade9" Text="Válido até: 31/12/9999" runat="server" />
                                    <br />
                                    <asp:Label ID="LabelLoja9" Text="Loja: DicaDaCoruja" runat="server" style="font-size: 14px;"/>
                                    <div>
                                        <asp:LinkButton ID="Btn9" Text="Anuncie já" PostBackUrl="~/ofertas/anuncie.aspx" class="Btn Btn-Vrd" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="thumbnail">
                            <div class="Margin1" style="display: table; width: 100%;">
                                <div class="ImgAlgOferta">
                                    <asp:Image ID="ImgLogo10" runat="server" CssClass="ImgResponse" ImageUrl="../Images/logo-verde.jpg" />
                                </div>
                                <div class="VerAlg ImgAlgPreco">
                                    <header>
                                    <h4 class="TxtVerde" id="fitText10"><asp:Label ID="LabelPreco10" Text="R$000000,00" runat="server" /></h4>
                                    </header>
                                </div>
                            </div>
                            <div class="ImgAlgProduto">
                                <asp:Image ID="ImgAnuncio10" runat="server" CssClass="ImgResponse" ImageUrl="../Images/anuncio.jpg" />
                            </div>
                            <div class="caption">
                                <div id="FaixaAnuncio10" runat="server" class="FaixaAnuncio FundoVerde TxtCenter">
                                    <asp:Label ID="LabelTitulo10" Text="Veja como é fácil" runat="server" />
                                </div> 
                                <div class="TxtCenter">
                                    <asp:Label ID="LabelValidade10" Text="Válido até: 31/12/9999" runat="server" />
                                    <br />
                                    <asp:Label ID="LabelLoja10" Text="Loja: DicaDaCoruja" runat="server" style="font-size: 14px;"/>
                                    <div>
                                        <asp:LinkButton ID="Btn10" Text="Anuncie já" PostBackUrl="~/ofertas/anuncie.aspx" class="Btn Btn-Vrd" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="thumbnail">
                            <div class="Margin1" style="display: table; width: 100%;">
                                <div class="ImgAlgOferta">
                                    <asp:Image ID="ImgLogo11" runat="server" CssClass="ImgResponse" ImageUrl="../Images/logo-verde.jpg" />
                                </div>
                                <div class="VerAlg ImgAlgPreco">
                                    <header>
                                    <h4 class="TxtVerde" id="fitText11"><asp:Label ID="LabelPreco11" Text="R$000000,00" runat="server" /></h4>
                                    </header>
                                </div>
                            </div>
                            <div class="ImgAlgProduto">
                                <asp:Image ID="ImgAnuncio11" runat="server" CssClass="ImgResponse" ImageUrl="../Images/anuncio.jpg" />
                            </div>
                            <div class="caption">
                                <div id="FaixaAnuncio11" runat="server" class="FaixaAnuncio FundoVerde TxtCenter">
                                    <asp:Label ID="LabelTitulo11" Text="Veja como é fácil" runat="server" />
                                </div> 
                                <div class="TxtCenter">
                                    <asp:Label ID="LabelValidade11" Text="Válido até: 31/12/9999" runat="server" />
                                    <br />
                                    <asp:Label ID="LabelLoja11" Text="Loja: DicaDaCoruja" runat="server" style="font-size: 14px;"/>
                                    <div>
                                        <asp:LinkButton ID="Btn11" Text="Anuncie já" PostBackUrl="~/ofertas/anuncie.aspx" class="Btn Btn-Vrd" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6 col-md-3">
                        <div class="thumbnail">
                            <div class="Margin1" style="display: table; width: 100%;">
                                <div class="ImgAlgOferta">
                                    <asp:Image ID="ImgLogo12" runat="server" CssClass="ImgResponse" ImageUrl="../Images/logo-verde.jpg" />
                                </div>
                                <div class="VerAlg ImgAlgPreco">
                                    <header>
                                    <h4 class="TxtVerde" id="fitText12"><asp:Label ID="LabelPreco12" Text="R$000000,00" runat="server" /></h4>
                                    </header>
                                </div>
                            </div>
                            <div class="ImgAlgProduto">
                                <asp:Image ID="ImgAnuncio12" runat="server" CssClass="ImgResponse" ImageUrl="../Images/anuncio.jpg" />
                            </div>
                            <div class="caption">
                                <div id="FaixaAnuncio12" runat="server" class="FaixaAnuncio FundoVerde TxtCenter">
                                    <asp:Label ID="LabelTitulo12" Text="Veja como é fácil" runat="server" />
                                </div> 
                                <div class="TxtCenter">
                                    <asp:Label ID="LabelValidade12" Text="Válido até: 31/12/9999" runat="server" />
                                    <br />
                                    <asp:Label ID="LabelLoja12" Text="Loja: DicaDaCoruja" runat="server" style="font-size: 14px;"/>
                                    <div>
                                        <asp:LinkButton ID="Btn12" Text="Anuncie já" PostBackUrl="~/ofertas/anuncie.aspx" class="Btn Btn-Vrd" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div>
                <nav aria-label="...">
                    <ul class="pager">
                        <li><a><asp:button ID="BtnAnterior" runat="server" Text="Anterior" CssClass="Transparente" OnClick="BtnAnterior_Click"/></a></li>
                        <li><asp:Label ID="LabelPagina" runat="server" Text="1"/></li>
                        <li><a><asp:button ID="BtnProximo" runat="server" Text="Próximo" CssClass="Transparente" OnClick="BtnProximo_Click"/></a></li>
                    </ul>
                </nav>
            </div>
        </div>
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
