<%@ Page Title="" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="relatorios.aspx.cs" Inherits="Pratica_III.relatorios" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="section">
        <div class="container white ">
            <center><h4>Relatórios</h4></center>
            <div class="row section">
                <div class="input-field col s9">
                    <asp:DropDownList runat="server" id="escolhaGraf">
                        <asp:ListItem Disabled Selected="True">Escolher tipo de relatório</asp:ListItem>
                        <asp:ListItem>Consulta por Médico</asp:ListItem>
                        <asp:ListItem>Atendimento por Especialidade</asp:ListItem>
                        <asp:ListItem>Consulta por paciente</asp:ListItem>
                        <asp:ListItem>Consultas Canceladas</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="input-field col s3">
                    <asp:Button runat="server" id="btnGraf" Text="Gerar Relatório" class="waves-effect waves-light btn-large green darken-1"/>    
                </div>
            </div>            
        </div>
    </div>
    <div class="section">
        <div class="container white">
            <asp:Chart runat="server" ID="ctl00"/>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="server">
</asp:Content>
