<%@ Page Title="" Language="C#" MasterPageFile="~/Users/Users.Master" AutoEventWireup="true" CodeBehind="Anuncios.aspx.cs" Inherits="DicaDaCoruja.Interface.Users.Anuncios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Centro" runat="server" >
    <div class="BordaAzulEsc Alt420px Larg100" >
        <div class="Margin1 TxtCenter BordaAzulEsc DivGridView" >
            <asp:GridView ID="GridAnuncios" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="false" CellPadding="4" Width="1700px">
                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" HorizontalAlign="Center" />
                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Center" />
                <RowStyle BackColor="White" ForeColor="#003399" />
                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                <SortedAscendingCellStyle BackColor="#EDF6F6" />
                <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                <SortedDescendingCellStyle BackColor="#D6DFDF" />
                <SortedDescendingHeaderStyle BackColor="#002876" />
                <Columns>
                    <asp:BoundField DataField="0" ReadOnly="true" HeaderText="Categoria Filho" ItemStyle-Width="220px" />
                    <asp:BoundField DataField="1" ReadOnly="true" HeaderText="Categoria Pai" ItemStyle-Width="220px" />
                    <asp:BoundField DataField="2" ReadOnly="true" HeaderText="Data Início" ItemStyle-Width="110px" />
                    <asp:BoundField DataField="3" ReadOnly="true" HeaderText="Data Fim" ItemStyle-Width="110px" />
                    <asp:BoundField DataField="4" ReadOnly="true" HeaderText="Produto" ItemStyle-Width="220px" />
                    <asp:BoundField DataField="5" ReadOnly="true" HeaderText="Preço" ItemStyle-Width="70px" />
                    <asp:BoundField DataField="6" ReadOnly="true" HeaderText="Nome Loja" ItemStyle-Width="220px" />
                    <asp:BoundField DataField="7" ReadOnly="true" HeaderText="Num Loja" ItemStyle-Width="90px" />
                    <asp:BoundField DataField="8" ReadOnly="true" HeaderText="Tipo" ItemStyle-Width="100px" />
                    <asp:BoundField DataField="9" ReadOnly="true" HeaderText="Link" ItemStyle-Width="300px" />
                    <asp:BoundField DataField="10" ReadOnly="true" HeaderText="ID" ItemStyle-Width="40px" />
                </Columns>
            </asp:GridView>
        </div>
        <div class="TxtCenter" style="min-height: 15px; font-size: 14px;">
            <asp:Label ID="LabelStatus" Text=" " runat="server" />
        </div>
        <div class="BordaAzulEsc Margin1" style="min-height: 120px; font-size: 14px;" >
            <asp:DropDownList ID="DropTipo" runat="server" CssClass="DropCad Margin1" AutoPostBack="True" OnSelectedIndexChanged="Change_Tipo" >
                <asp:ListItem Text="Tipo" Value="" Selected="True" />
                <asp:ListItem Text="Verde" Value="VERDE" />
                <asp:ListItem Text="Vermelho" Value="VERMELHO" />
                <asp:ListItem Text="Azul" Value="AZUL" />
            </asp:DropDownList>
            <asp:DropDownList ID="DropCategoriaPai" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Change_CategoriaPai" CssClass="DropCad Margin1" />
            <asp:DropDownList ID="DropCategoriaFilho" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Change_CategoriaFilho" CssClass="DropCad Margin1" Enabled="false" />
            <asp:DropDownList ID="DropProduto" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Change_Produto" CssClass="DropCad Margin1" Enabled="false" />
            <asp:TextBox ID="TextDataInicio" runat="server" AutoPostBack="True" placeholder="Data Início" MaxLength="10" OnTextChanged="TextDataInicio_Changed" CssClass="BoxCad Margin1" />
            <asp:TextBox ID="TextDataFim" runat="server" AutoPostBack="True" placeholder="Data Fim" MaxLength="10" OnTextChanged="TextDataFim_Changed" CssClass="BoxCad Margin1" />
            <asp:TextBox ID="TextPreco" onkeyup="formataValor(this,event);passaValor();" runat="server" placeholder="Preço do Produto" MaxLength="10" CssClass="BoxCad Margin1" />
            <asp:TextBox ID="TextDescricao" runat="server" placeholder="Descrição adicional" MaxLength="200" CssClass="BoxCad Margin1" />
        </div>
        <div class="Margin1 TxtCenter">
            <input id="BtnVizualizar" type="button" value="Vizualizar" class="Btn Btn-Cad" />
            <asp:Button ID="BtnInserir" runat="server" Text="Inserir" CssClass="Btn Btn-Cad" OnClick="BtnInserir_Click" />
        </div>
        <div class="BordaAzulEsc Margin1 TxtCenter" >
            <asp:DropDownList ID="DropID" runat="server" AutoPostBack="True" CssClass="DropCad Margin1" />
            <asp:TextBox ID="TextPrecoAlt" Text="" onkeyup="formataValor(this,event);" runat="server" placeholder="Preço do Produto" CssClass="BoxCad Margin1" />
            <asp:Button ID="BtnAltera" Text="Alterar" runat="server" CssClass="Btn Btn-Cad" OnClick="BtnAltera_Click" />
            <asp:Button ID="BtnDelete" Text="Deletar" runat="server" CssClass="Btn Btn-Cad" OnClick="BtnDelete_Click" />
        </div>
        <div id="PopupCad" title="Vizualização do Anúncio">
            <div class="AnuncioCad">
                <div class="AnuncioInt">
                    <div style="display: table; width: 100%;">
                        <div class="ImgAlgOferta">
                            <asp:Image ID="ImgLogoPopup" runat="server" ImageUrl="../Images/logo-verde.jpg" CssClass="ImgResponse" />
                        </div>
                        <div class="VerAlg AnuAlgPreco TxtVerde">
                            <header>
                            <h1 id="fitText1"><asp:Label ID="LabelPrecoPopup" Text="R$000000,00" runat="server" /></h1>
                            </header>
                        </div>
                    </div>
                    <asp:Image ID="ImgPopup" runat="server" CssClass="ImgResponse" ImageUrl="../Images/anuncio.jpg" />
                    <div class="caption">
                        <div id="FaixaPopup" runat="server" class="FaixaAnuncio FundoVerde TxtCenter">
                            <asp:Label ID="LabelTituloPopup" Text="Veja como é fácil" runat="server" />
                        </div> 
                        <div class="TxtCenter">
                            <asp:Label ID="LabelValidadePopup" Text="Válido até: 31/12/9999" runat="server" style="font-size: 14px;" />
                            <br />
                            <asp:Label ID="LabelLojaPopup" Text="Loja: DicaDaCoruja" runat="server" style="font-size: 14px;" />
                            <div>
                                <asp:LinkButton ID="BtnPopup" Text="Ir para a loja" CssClass="Btn Btn-Vrd" runat="server" style="color: #ffffff;" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $("#fitText1").fitText(0.75);
    </script>
    <script type="text/javascript">
        function passaValor() {
            document.getElementById('<%=LabelPrecoPopup.ClientID%>').innerHTML = 'R$'+document.getElementById('<%=TextPreco.ClientID%>').value;
        }
    </script>
</asp:Content>
