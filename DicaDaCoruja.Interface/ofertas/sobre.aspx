<%@ Page Title="" Language="C#" MasterPageFile="~/ofertas/ofertas.Master" AutoEventWireup="true" CodeBehind="sobre.aspx.cs" Inherits="DicaDaCoruja.Interface.ofertas.sobre" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CenterPlcHld" runat="server">
    <div class="BordaAzulEsc">
        <div class="Margin1">
            <h1>Sobre</h1>
            <h2>Dica da Coruja, As melhores <em>ofertas</em>, <em>promoções</em> e <em>descontos</em> de <em>Piracicaba</em> e região</h2>
            <p>O site dica da coruja surgiu da ideia de dois amigos em 2016, com o intuito de promover a informação de preços de lojas físicas através da internet e auxiliar nossos clientes em como chegar no estabelecimento com o produto de interesse. Aos comerciantes, pensamos numa plataforma com preço acessível onde todos podem divulgar seus produtos, promoções e serviços para uma gama muito maior de potenciais interessados e não somente nas imediações de seus estabelecimentos.</p>
            <p>Nosso diferencial está no uso de cores para destacar determinados anúncios e o auxílio do gps para os clientes guiarem-se até um estabelecimento que muitas vezes é desconhecido das pessoas. Nossos valores fundamentam-se no respeito aos clientes e interessados em nossos anúncios, lembrando que apenas fazemos a divulgação e a responsabilidade pela mercadoria fica a cargo dos lojistas.</p>
            <p>Aguardem novidades e não hesitem em nos mandar críticas ou sugestões pelo email contato@dicadacoruja.com</p>
            <br />
            <br />
	        <p>Direitos autorais e propriedade intelectual</p>
            <p>Os documentos, conteúdos e criações contidos neste website pertencem aos seus criadores e colaboradores. A autoria dos conteúdo, material e imagens exibidos no Dica da Coruja é protegida por leis nacionais e internacionais. Não podem ser copiados, reproduzidos, modificados, publicados, atualizados, postados, transmitidos ou distribuídos de qualquer maneira sem autorização prévia e por escrito do Dica da Coruja.</p>
            <p>As imagens contidas neste website são aqui incorporadas apenas para fins de visualização, e, salvo autorização expressa por escrito, não podem ser gravadas ou baixadas via download. A reprodução ou armazenamento de materiais recuperados a partir deste serviço sujeitará os infratores às penas da lei.</p>
            <p>O nome do site Dica da Coruja, seu logotipo, o nome de domínio para acesso na Internet, bem como todos os elementos característicos da tecnologia desenvolvida e aqui apresentada, sob a forma da articulação de bases de dados, constituem marcas registradas e propriedades intelectuais privadas e todos os direitos decorrentes de seu registro são assegurados por lei. Alguns direitos de uso podem ser cedidos por Dica da Coruja em contrato ou licença especial, que pode ser cancelada a qualquer momento se não cumpridos os seus termos.</p>
            <p>As marcas registradas do Dica da Coruja só podem ser usadas publicamente com autorização expressa. O uso destas marcas registradas em publicidade e promoção de produtos deve ser adequadamente informado.</p>
            <p>O site Dica da Coruja empenha-se em manter a qualidade, atualidade e autenticidade das informações do site, mas seus criadores e colaboradores não se responsabilizam por eventuais falhas nos serviços ou inexatidão das informações oferecidas. O usuário não deve ter como pressuposto que tais serviços e informações são isentos de erros ou serão adequados aos seus objetivos particulares. Os criadores e colaboradores tampouco assumem o compromisso de atualizar as informações, e reservam-se o direito de alterar as condições de uso ou preços dos serviços e produtos oferecidos no site a qualquer momento.</p>
            <p>O acesso ao site Dica da Coruja é gratuito. O site Dica da Coruja poderá criar áreas de acesso exclusivo aos seus clientes ou para terceiros especialmente autorizados.</p>
            <p>Os criadores e colaboradores do site Dica da Coruja poderão a seu exclusivo critério e em qualquer tempo, modificar ou desativar o site, bem como limitar, cancelar ou suspender seu uso ou o acesso. Também estes termos de uso poderão ser alterados a qualquer tempo. Visite regularmente esta página e consulte os termos então vigentes. Algumas disposições destes Termos podem ser substituídas por termos ou avisos legais expressos localizados em determinadas páginas deste site.</p>
            <p>O site Dica da Coruja apenas divulga anúncios sendo que não garante a quantidade ou disponibilidade de produtos anunciados pelos clientes.</p>
            <br />
        </div>
        <div class="Margin1" style="text-align: center;">
            <asp:Button ID="BtnAnuncie" runat="server" CssClass="Btn Btn-Cad" Text="Anuncie com a gente" PostBackUrl="../ofertas/anuncie.aspx" />
        </div>
    </div>
</asp:Content>
