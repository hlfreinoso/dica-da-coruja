<%@ Page Title="" Language="C#" MasterPageFile="~/Register/Register.Master" AutoEventWireup="true" CodeBehind="Categorias.aspx.cs" Inherits="DicaDaCoruja.Interface.Register.Categorias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Centro" runat="server">
    <div class="BordaAzulEsc Alt420" style="width: 100%;">
        <div class="Margin1 TxtCenter DivGridView" >
            <asp:GridView ID="GridCategoria" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Width="100%" >
                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" HorizontalAlign="Center" />
                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Center" />
                <RowStyle BackColor="White" ForeColor="#003399" />
                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                <SortedAscendingCellStyle BackColor="#EDF6F6" />
                <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                <SortedDescendingCellStyle BackColor="#D6DFDF" />
                <SortedDescendingHeaderStyle BackColor="#002876" />
            </asp:GridView>
        </div>
        <div class="Margin1" style="border: 1px solid black; min-height: 120px;">
            <asp:TextBox ID="TextCatePai" Text="" runat="server" placeholder="Nome da Categoria Pai" CssClass="Margin1" Style="width: 250px;" />
            <asp:TextBox ID="TextCategoria" Text="" runat="server" placeholder="Nome da Categoria Filho" CssClass="Margin1" Style="width: 250px;" />
        </div>
        <div class="Margin1 TxtCenter">
            <asp:Label ID="LabelStatus" Text="" runat="server" />
            <br />
            <asp:Button ID="BtnInserir" Text="Inserir" runat="server" CssClass="btn btn-default" OnClick="BtnInserir_Click" />
        </div>
        <div class="Margin1 TxtCenter">
            <asp:TextBox ID="TextID" Text="" runat="server" placeholder="Colocar ID" CssClass="Margin1" />
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