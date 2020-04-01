<%@ Page Title="" Language="C#" MasterPageFile="~/Register/Register.Master" AutoEventWireup="true" CodeBehind="Anuncios.aspx.cs" Inherits="DicaDaCoruja.Interface.Register.Anuncios" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Centro" runat="server">
    <div class="BordaAzulEsc Alt420">
        <div class="Margin1 TxtCenter DivGridView">
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
        <div class="Margin1" style="border: 1px solid black; min-height: 120px; font-size: 14px;">
            <asp:ScriptManager ID="ScriptMananger1" runat="server" EnableScriptGlobalization="True"></asp:ScriptManager>
            <asp:DropDownList ID="DropFornecedor" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Change_Fornecedor" CssClass="Margin1" Style="width: 200px;" />
            <asp:DropDownList ID="DropTipo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Change_Tipo" CssClass="Margin1" Style="width: 230px;" />
            <asp:DropDownList ID="DropCategoriaPai" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Change_CategoriaPai" CssClass="Margin1" Style="width: 200px;" />
            <asp:DropDownList ID="DropCategoriaFilho" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Change_CategoriaFilho" CssClass="Margin1" Style="width: 200px;"/>
            <asp:DropDownList ID="DropProduto" runat="server" AutoPostBack="True" CssClass="Margin1" Style="width: 200px;" />
            <asp:TextBox ID="TextDataInicio" Text="" runat="server" placeholder="Data Inicio" AutoPostBack="True" OnTextChanged="TextDataInicio_Changed" CssClass="Margin1" Style="width: 182px;" Enabled="False" />
            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TextDataInicio" Format="dd/MM/yyyy" />
            <asp:TextBox ID="TextDataFim" Text="" runat="server" placeholder="Data Fim" AutoPostBack="True" OnTextChanged="TextDataFim_Changed" CssClass="Margin1" Style="width: 182px;" Enabled="False" />
            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="TextDataFim" Format="dd/MM/yyyy" />
            <asp:TextBox ID="TextPreco" Text="" onkeyup="formataValor(this,event);" runat="server" placeholder="Preço do Produto" CssClass="Margin1" />
            <asp:TextBox ID="TextLink" Text="" runat="server" placeholder="Link" CssClass="Margin1" />
        </div>
        <div class="Margin1 TxtCenter">
            <asp:Button ID="BtnInserir" Text="Inserir" runat="server" CssClass="btn btn-default" OnClick="BtnInserir_Click" />
        </div>
        <div class="Margin1 TxtCenter" style="border: 1px solid black;" >
            <asp:DropDownList ID="DropID" runat="server" AutoPostBack="True" CssClass="Margin1" Style="width: 200px;"/>
            <asp:TextBox ID="TextPrecoAlt" Text="" onkeyup="formataValor(this,event);" runat="server" placeholder="Preço do Produto" CssClass="Margin1" />
            <asp:Button ID="BtnAltera" Text="Alterar" runat="server" CssClass="btn btn-default" OnClick="BtnAltera_Click" />
            <asp:Button ID="BtnDelete" Text="Deletar" runat="server" CssClass="btn btn-default" OnClick="BtnDelete_Click" />
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
