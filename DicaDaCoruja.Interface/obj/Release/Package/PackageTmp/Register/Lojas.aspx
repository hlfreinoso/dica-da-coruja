<%@ Page Title="" Language="C#" MasterPageFile="~/Register/Register.Master" AutoEventWireup="true" CodeBehind="Lojas.aspx.cs" Inherits="DicaDaCoruja.Interface.Register.Lojas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Centro" runat="server">
    <div class="BordaAzulEsc Alt420">
        <div class="Margin1 TxtCenter DivGridView">
            <asp:GridView ID="GridFornecedor" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="false" CellPadding="4" Width="2350px">
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
                    <asp:BoundField DataField="0" ReadOnly="true" HeaderText="Grupo" ItemStyle-Width="220px" />
                    <asp:BoundField DataField="1" ReadOnly="true" HeaderText="Nome da Loja" ItemStyle-Width="220px" />
                    <asp:BoundField DataField="2" ReadOnly="true" HeaderText="Num Loja" ItemStyle-Width="90px" />
                    <asp:BoundField DataField="3" ReadOnly="true" HeaderText="CNPJ" ItemStyle-Width="110px" />
                    <asp:BoundField DataField="4" ReadOnly="true" HeaderText="Razão Social" ItemStyle-Width="300px" />
                    <asp:BoundField DataField="5" ReadOnly="true" HeaderText="CEP" ItemStyle-Width="90px" />
                    <asp:BoundField DataField="6" ReadOnly="true" HeaderText="Endereço" ItemStyle-Width="300px" />
                    <asp:BoundField DataField="7" ReadOnly="true" HeaderText="Número" ItemStyle-Width="70px" />
                    <asp:BoundField DataField="8" ReadOnly="true" HeaderText="Bairro" ItemStyle-Width="220px" />
                    <asp:BoundField DataField="9" ReadOnly="true" HeaderText="Cidade" ItemStyle-Width="220px" />
                    <asp:BoundField DataField="10" ReadOnly="true" HeaderText="Estado" ItemStyle-Width="70px" />
                    <asp:BoundField DataField="11" ReadOnly="true" HeaderText="Link" ItemStyle-Width="300px" />
                    <asp:BoundField DataField="12" ReadOnly="true" HeaderText="Status" ItemStyle-Width="70px" />
                    <asp:BoundField DataField="14" ReadOnly="true" HeaderText="Contrato" ItemStyle-Width="120px" />
                    <asp:BoundField DataField="13" ReadOnly="true" HeaderText="ID" ItemStyle-Width="70px" />
                </Columns>
            </asp:GridView>
        </div>
        <div class="Margin1" style="border: 1px solid black; min-height: 120px;">
            <asp:TextBox ID="TextGrupo" Text="" runat="server" placeholder="Nome do Grupo" CssClass="Margin1" Style="width: 150px;" />
            <asp:TextBox ID="TextFornecedor" Text="" runat="server" placeholder="Nome Abreviado" CssClass="Margin1" />
            <asp:TextBox ID="TextLoja" Text="" runat="server" placeholder="Número da loja" CssClass="Margin1" Style="width: 135px;" />
            <asp:TextBox ID="TextCNPJ" Text="" onkeyup="formataCNPJ(this,event);" runat="server" placeholder="Número do CNPJ" CssClass="Margin1" />
            <asp:TextBox ID="TextRazao" Text="" runat="server" placeholder="Razão Social" CssClass="Margin1" />
            <asp:TextBox ID="TextCEP" Text="" onkeyup="formataCEP(this,event);" runat="server" placeholder="Número do CEP" CssClass="Margin1" Style="width: 150px;" />
            <asp:DropDownList ID="DropEstado" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Change_Estado" CssClass="Margin1" Style="width: 100px;"/>
            <asp:DropDownList ID="DropCidade" runat="server" AutoPostBack="True" CssClass="Margin1" Style="width: 150px;" />
            <asp:TextBox ID="TextRua" Text="" runat="server" placeholder="Endereço" CssClass="Margin1" />
            <asp:TextBox ID="TextNumero" Text="" runat="server" placeholder="Número do Endereço" CssClass="Margin1" />
            <asp:TextBox ID="TextBairro" Text="" runat="server" placeholder="Nome do Bairro" CssClass="Margin1" />
            <asp:TextBox ID="TextLink" Text="" runat="server" placeholder="Link do Local" CssClass="Margin1" />
            <asp:DropDownList ID="DropContrato" runat="server" AutoPostBack="True" CssClass="Margin1" Style="width: 150px;" >
                <asp:ListItem Text="AVULSO" Value="AVULSO" Selected="true" />
                <asp:ListItem Text="ASSINANTE" Value="ASSINANTE" />
            </asp:DropDownList>
        </div>
        <div class="Margin1 TxtCenter">
            <asp:Label ID="LabelStatus" Text="" runat="server" />
            <br />
            <asp:Button ID="BtnInserir" Text="Inserir" runat="server" CssClass="btn btn-default" OnClick="BtnInserir_Click" />
        </div>
        <div class="Margin1 TxtCenter">
            <asp:TextBox ID="TextID" Text="" runat="server" placeholder="Colocar ID" CssClass="Margin1" />
            <asp:Button ID="BtnAtivar" Text="Ativar" runat="server" CssClass="btn btn-default" OnClick="BtnAtivar_Click" />
            <asp:Button ID="BtnDesativar" Text="Inativar" runat="server" CssClass="btn btn-default" OnClick="BtnDesativar_Click" />
        </div>
    </div>
    <script type="text/javascript" >
        $( document ).ready(function() {
            var winW = $(window).width();
            winW = winW * 0.958;
            var divResize = $(".DivGridView");
            divResize.css('width', winW);
        });
        $(function () {
            $(window).resize(function () {
                var winW = $(window).width();
                winW = winW * 0.958;
                var divResize = $(".DivGridView");
                divResize.css('width', winW);
            });
        });
    </script>
</asp:Content>