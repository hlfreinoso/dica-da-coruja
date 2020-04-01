<%@ Page Title="" Language="C#" MasterPageFile="~/Register/Register.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="DicaDaCoruja.Interface.Register.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Centro" runat="server">
    <div class="BordaAzulEsc Alt420" style="width: 100%;">
        <div class="Margin1 TxtCenter DivGridView">
            <asp:GridView ID="GridUsuarios" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="false" CellPadding="4" Width="100%">
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
                    <asp:BoundField DataField="0" ReadOnly="true" HeaderText="Loja" />
                    <asp:BoundField DataField="1" ReadOnly="true" HeaderText="Número Loja" />
                    <asp:BoundField DataField="2" ReadOnly="true" HeaderText="Usuário" />
                    <asp:BoundField DataField="3" ReadOnly="true" HeaderText="Senha" />
                    <asp:BoundField DataField="4" ReadOnly="true" HeaderText="Situação" />
                </Columns>
            </asp:GridView>
        </div>
        <div class="TxtCenter" style="min-height: 15px; font-size: 14px;">
            <asp:Label ID="LabelStatus" Text=" " runat="server" />
        </div>
        <div class="Margin1" style="border: 1px solid black; min-height: 120px; font-size: 14px;">
            <asp:DropDownList ID="DropFornecedor" runat="server" AutoPostBack="True" CssClass="Margin1" Style="width: 200px;"/>
            <asp:TextBox ID="TextUsuario" Text="" runat="server" placeholder="Usuário" CssClass="Margin1" Style="width: 200px;"/>
            <asp:TextBox ID="TextSenha" Text="" runat="server" placeholder="Senha" CssClass="Margin1" Style="width: 200px;"/>
        </div>
        <div class="Margin1 TxtCenter">
            <asp:Button ID="BtnInserir" Text="Inserir" runat="server" CssClass="btn btn-default" OnClick="BtnInserir_Click" />
        </div>
        <div class="Margin1 TxtCenter">
            <asp:DropDownList ID="DropUsuario" runat="server" AutoPostBack="True" CssClass="Margin1" Style="width: 200px;"/>
            <asp:Button ID="BtnAtivar" Text="Ativar" runat="server" CssClass="btn btn-default" OnClick="BtnAtivar_Click" />
            <asp:Button ID="BtnInativar" Text="Inativar" runat="server" CssClass="btn btn-default" OnClick="BtnInativar_Click" />
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
