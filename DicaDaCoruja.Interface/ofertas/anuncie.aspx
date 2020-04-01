<%@ Page Title="" Language="C#" MasterPageFile="~/ofertas/ofertas.Master" AutoEventWireup="true" CodeBehind="anuncie.aspx.cs" Inherits="DicaDaCoruja.Interface.ofertas.anuncie" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CenterPlcHld" runat="server">
    <div class="BordaAzulEsc">
        <div class="Margin1">
            <h1>Anuncie já</h1>
            <h2>Principais <em>vantagens</em> e motivos para você anunciar no Dica da Coruja</h2>
            <h3>Porque <em>anunciar</em> com o Dica da Coruja?</h3>
            <p>-Uso do GPS para levar o cliente até seu estabelecimento</p>
            <p>-Sem custo por clique</p>
            <p>-Sem custos de manutenção de um website</p>
            <p>-Seus produtos anunciados 24 horas por dia, 7 dias da semana</p>
            <p>-Sem custos com mídia impressa. Ex: Folhetos e jornais diários</p>
            <p>-Preservação do meio ambiente</p>
            <p>-Aumento da visibilidade de sua loja ou clínica através do compartilhamento de ofertas e serviços por grupos e pessoas através de redes sociais, apenas pelo custo fixo do anúncio ou banner virtual.</p>
            <br />
            <h3>Parceiros de comércios online:</h3>
            <p>-Sem custo por clique</p>
            <p>-Direcionamento da oferta até o E commerce</p>
            <p>-Compartilhamento de algumas <em>ofertas</em> através da loja por rede sociais</p>
            <p>-Tíquete médio em compras foi de R$ 347,00</p>
            <br />
            <h3>Dica da coruja</h3>
            <p>Dica 1 – Cerca de 70% das pessoas que se deslocam até um determinado estabelecimento com foco em comprar um produto específico, acabam adquirindo outros, tanto homens quanto mulheres (aumento da margem de lucro)</p>
            <p>Dica 2 – A maior variedade de produtos anunciados se torna um atrativo e consequentemente há maior poder de convencimento para o cliente conhecer o estabelecimento</p>
            <p>Dica 3 – 75% das pessoas entrevistadas procuram pesquisar preços em rede social e websites, antes de efetuar uma compra</p>
            <p>Dica 4 – Bom atendimento, produtos de qualidade e variedade são importantíssimos para o cliente sempre estar voltando ao estabelecimento</p>
            <p>Dica 5 - Importantíssimo! O parceiro estar sempre com os preços atualizados dos produtos anunciados e cumprir com as ofertas quando o cliente for visitar a loja</p>
            <p>Dica 6 - Roupas, sapatos, bebidas, carnes, doces, eletrônicos e eletrodomésticos são os produtos que mais chamam a atenção dos consumidores em propagandas</p>
            <br />
        </div>
        <div class="Margin1" style="text-align: center;">
            <asp:Button ID="BtnContato" runat="server" CssClass="Btn Btn-Cad" Text="Entre em contato" PostBackUrl="../ofertas/contato.aspx" />
        </div>
    </div>
</asp:Content>
