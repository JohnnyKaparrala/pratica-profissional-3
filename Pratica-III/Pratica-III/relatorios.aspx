<%@ Page Title="" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="relatorios.aspx.cs" Inherits="Pratica_III.relatorios" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="section">
        <div class="container white ">
            <center><h4>Relatórios</h4></center>
            <div class="row section">
                <div class="input-field col s6">
                    <asp:DropDownList runat="server" id="escolhaGraf">
                        <asp:ListItem Value="0" Disabled Selected="True">Escolher tipo de relatório</asp:ListItem>
                        <asp:ListItem Value="1">Consulta por Médico</asp:ListItem>
                        <asp:ListItem Value="2">Atendimento por Especialidade</asp:ListItem>
                        <asp:ListItem Value="3">Consulta por paciente</asp:ListItem>
                        <asp:ListItem Value="4">Consultas Canceladas</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="input-field col s4">
                    <asp:Button runat="server" id="btnGraf" Text="Gerar Relatório" class="waves-effect waves-light btn-large green darken-1" OnClick="btnGraf_Click"/>    
                </div>
                <div class="input-field col s2">
                    <asp:DropDownList ID="ddMes" runat="server">
                        <asp:ListItem Disabled Selected="True">Escolher Ano</asp:ListItem>
                        <asp:ListItem><asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>            
        </div>
    </div>
    <div class="section">
        <div class="container white">
            <asp:Chart ID="Chart1" runat="server">
                <series>
                    <asp:Series Name="Series1">
                    </asp:Series>
                </series>
                <chartareas>
                    <asp:ChartArea Name="ChartArea1">
                    </asp:ChartArea>
                </chartareas>
            </asp:Chart>
            <asp:Chart ID="Chart2" runat="server">
                <series>
                    <asp:Series Name="Series1">
                    </asp:Series>
                </series>
                <chartareas>
                    <asp:ChartArea Name="ChartArea1">
                    </asp:ChartArea>
                </chartareas>
            </asp:Chart>
            <asp:Chart ID="Chart3" runat="server">
                <series>
                    <asp:Series Name="Series1">
                    </asp:Series>
                </series>
                <chartareas>
                    <asp:ChartArea Name="ChartArea1">
                    </asp:ChartArea>
                </chartareas>
            </asp:Chart>
            <asp:Chart ID="Chart4" runat="server">
                <series>
                    <asp:Series Name="Series1">
                    </asp:Series>
                </series>
                <chartareas>
                    <asp:ChartArea Name="ChartArea1">
                    </asp:ChartArea>
                </chartareas>
            </asp:Chart>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="server">
</asp:Content>
