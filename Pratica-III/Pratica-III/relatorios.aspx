<%@ Page Title="" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="relatorios.aspx.cs" Inherits="Pratica_III.relatorios" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="section">
        <div class="container white ">
            <center><h4>Relatórios</h4></center>
            <div class="row section" style="vertical-align: middle">
                <div class="input-field col s9" >
                    <asp:DropDownList runat="server" id="escolhaGraf" OnSelectedIndexChanged="escolhaGraf_SelectedIndexChanged">
                        <asp:ListItem Value="0" Disabled Selected="True">Escolher tipo de relatório</asp:ListItem>
                        <asp:ListItem Value="1">Consulta por Médico</asp:ListItem>
                        <asp:ListItem Value="2">Atendimento por Especialidade</asp:ListItem>
                        <asp:ListItem Value="3">Consulta por paciente</asp:ListItem>
                        <asp:ListItem Value="4">Consultas Canceladas</asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddPesquisa" runat="server" Visible="false">
                    </asp:DropDownList>
                </div>
                <div class="input-field col s3">
                    <asp:Button runat="server" id="btnGraf" Text="Pesquisar Dados" class="waves-effect waves-light btn-large green darken-1" OnClick="btnGraf_Click"/>    
                    <asp:DropDownList ID="ddMes" runat="server" Visible="false">                            
                        <asp:ListItem Value="0" Disabled Selected="True">Escolher mês</asp:ListItem>
                        <asp:ListItem Value="1">Janeiro</asp:ListItem>
                        <asp:ListItem Value="2">Fevereiro</asp:ListItem>
                        <asp:ListItem Value="3">Março</asp:ListItem>
                        <asp:ListItem Value="4">Abril</asp:ListItem>
                        <asp:ListItem Value="5">Maio</asp:ListItem>
                        <asp:ListItem Value="6">Junho</asp:ListItem>
                        <asp:ListItem Value="7">Julho</asp:ListItem>
                        <asp:ListItem Value="8">Agosto</asp:ListItem>
                        <asp:ListItem Value="9">Setembro</asp:ListItem>
                        <asp:ListItem Value="10">Outubro</asp:ListItem>
                        <asp:ListItem Value="11">Novembro</asp:ListItem>
                        <asp:ListItem Value="12">Dezembro</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
                <div class="row section">
                    <center><asp:Button ID="btnGerarGraf" runat="server" Text="Gerar Gráfico" class="waves-effect waves-light btn-large green darken-1" /></center>
                </div>
            </div>            
        </div>
    <div class="section">
        <div class="container white">
            <asp:Chart ID="chartChart" runat="server">
                <Series>
                    <asp:Series Name="SerieChart"></asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="AreaChart"></asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="server">
</asp:Content>
