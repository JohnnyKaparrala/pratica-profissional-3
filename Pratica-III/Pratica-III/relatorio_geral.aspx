<%@ Page Title="" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="relatorio_geral.aspx.cs" Inherits="Pratica_III.relatorio_geral" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="white container">
        <center><h4>Relatótrio de números gerais</h4></center>
        <div class="section ">
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
