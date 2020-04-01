<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DicaDaCoruja.Interface.Register.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Dica da Coruja</title>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/style.css" rel="stylesheet" />
    <script type="text/javascript" src="../Scripts/jquery-3.2.1.min.js"></script>
    <script type="text/javascript" src="../Scripts/bootstrap.min.js"></script>
    <link rel="shortcut icon" href="../Images/logo-icone.ico" type="image/x-icon" />
</head>
    <body>
        <form id="geral" runat="server">
            <div id="Top">
                <div class="ImgAlgTopo">
                    <img src="../Images/topo.jpg" class="img-responsive img-rounded" alt="Imagem Responsiva"/>
                </div>
            </div>
            <div id="home">
                <div id="login">
                    <div class="form-login" style="border: 1px solid black">
                        <asp:TextBox ID="TxtUsuario" runat="server" PlaceHolder="usuário" CssClass="Margin1"></asp:TextBox>
                        <br />
                        <asp:TextBox ID="TxtSenha" runat="server" TextMode="Password" PlaceHolder="senha" CssClass="Margin1"></asp:TextBox>
                        <br />
                        <asp:Button ID="BtnEntrar" text="ENTRAR" runat="server" OnClick="BtnEntrar_Click" CssClass="BtnEntrar Margin1" />
                        <asp:Label runat="server" ID="LblStatus" ForeColor="Red"></asp:Label>
                    </div>
                </div>
            </div>
            <div id="rodape">
                <div>Desenvolvido por Heitor Reinoso - Todos os direitos reservados</div>
            </div>
        </form>
    </body>
</html>