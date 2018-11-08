<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="servidor.aspx.cs" Inherits="Pratica_III.servidor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="background-color:#101010; color: white">
    <form id="form1" runat="server">
        <asp:HiddenField ID="Hidden" runat="server" />
        <div>
            <pre>
<a href="index.aspx">voltar</a>
Servidor (as tarefas estão rodando em background)
<div id="ConsoleTxt" runat="server"></div>
            </pre>
        </div>
    </form>
</body>
    <script>
    </script>
</html>
