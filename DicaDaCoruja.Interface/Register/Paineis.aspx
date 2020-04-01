﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Register/Register.Master" AutoEventWireup="true" CodeBehind="Paineis.aspx.cs" Inherits="DicaDaCoruja.Interface.Register.Paineis" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Centro" runat="server">
    <div class="BordaAzulEsc Alt420" style="width: 100%;">
        <div class="Margin1 TxtCenter DivGridView" >
            <asp:GridView ID="GridPainel" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Width="100%" >
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
            <asp:ScriptManager ID="ScriptMananger1" runat="server" EnableScriptGlobalization="True"></asp:ScriptManager>
            <asp:DropDownList ID="DropFornecedor" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Change_Fornecedor" CssClass="Margin1" Style="width: 200px;" />
            <asp:DropDownList ID="DropTipo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Change_Tipo" CssClass="Margin1" Style="width: 230px;" />
            <asp:TextBox ID="TextDescricao" Text="" runat="server" placeholder="Descrição Painel" CssClass="Margin1" />
            <asp:TextBox ID="TextDataInicio" Text="" runat="server" placeholder="Data Inicio" AutoPostBack="True" OnTextChanged="TextDataInicio_Changed" CssClass="Margin1" Style="width: 182px;" Enabled="False" />
            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TextDataInicio" Format="dd/MM/yyyy" />
            <asp:TextBox ID="TextDataFim" Text="" runat="server" placeholder="Data Fim" AutoPostBack="True" OnTextChanged="TextDataFim_Changed" CssClass="Margin1" Style="width: 182px;" Enabled="False" />
            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="TextDataFim" Format="dd/MM/yyyy" />
            <asp:TextBox ID="TextLink" Text="" runat="server" placeholder="Link" CssClass="Margin1" />
            <asp:FileUpload ID="UpldFoto" runat="server" CssClass="Margin1"/>
        </div>
        <div class="Margin1 TxtCenter">
            <asp:Label ID="LabelStatus" Text="" runat="server" />
            <br />
            <asp:Button ID="BtnInserir" Text="Inserir" runat="server" CssClass="btn btn-default" OnClick="BtnInserir_Click" />
        </div>
        <div class="Margin1 TxtCenter">
            <asp:TextBox ID="TextID" Text="" runat="server" placeholder="Deletar ID" CssClass="Margin1" />
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
