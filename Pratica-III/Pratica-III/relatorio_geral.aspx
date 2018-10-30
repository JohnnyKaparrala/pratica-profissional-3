    <%@ Page Title="" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="relatorio_geral.aspx.cs" Inherits="Pratica_III.relatorio_geral" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="white container">
        <center><h4>Relatótrio de Consultas</h4></center>
        <div class="section ">
                <div class="section" style="float: right">
                    <div class="col s3">
                        Selecionar Consultas até:
                    </div>
                    <div class="col s4">
                        <asp:DropDownList ID="ddDura" runat="server">
                            <asp:ListItem Value="1">Amanhã</asp:ListItem>
                            <asp:ListItem Value="7">Próxima Semana</asp:ListItem>                            
                            <asp:ListItem Value="30">Próximo Mês</asp:ListItem>                            
                            <asp:ListItem Value="99">O final</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col s2"><asp:Button runat="server" id="btnData" Text="Selecionar Data" class="waves-effect waves-light btn-large green darken-1"/>
                    </div>
                </div>
                <table class="striped">
                    <thead>
                        <tr>
                            <th>ID consulta</th>
                            <th>Horário início</th>
                            <th>Duração</th>
                            <th>Médico</th>
                            <th>Paciente</th>
                            <th>Concluída</th>
                        </tr>
                    </thead>
                    <tbody runat="server" id="tbBody">
                    </tbody>
                </table>
        </div>
    </div>
</asp:Content>
