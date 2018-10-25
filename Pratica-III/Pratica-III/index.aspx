<%@ Page Title="" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Pratica_III.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>$(document).ready(function () { $('.parallax').parallax(); $("#home-menu").addClass('active'); });</script>
    <div class="section no-pad no-pad-top">
        <div class="parallax-container">
            <div class="section no-pad-bot no-pad-top">
              <div class="container">
                <h1 class="header center green-text">Clínica PharMercy</h1>
                <div class="row center">
                  <h5 class="header col s12 white-text light">Profissionais de qualidade e eficiência no atendimento são o nosso foco.</h5>
                  <h5 class="header col s12 white-text light">Junte-se a nós!</h5>
                </div>
              </div>
            </div>
            <div class="parallax">
                <img src="injecao.jpg" style="transform: translate3d(-50%, 1022.026px, 0px); opacity: 1;"/>
            </div>
        </div>
    </div>
    <div class="section container">
        <blockquote style="border-left-color: #4CAF50" class="flow-text">Nos orgulhamos de nosso empenho e dedicação, resultando em um dos maiores índices de aprovação do mercado, premiado pela INTRA e ANAMT em apenas 1 ano de funcionamento.</blockquote>
    </div>
    <div class="section grey lighten-4">
        <div class="container">
            <h3>Marque Sua consulta</h3>
            <p class="flow-text">Para marcar sua consulta com um de nossos profissionais, <a href="contato.aspx">contate-nos</a></p>
        </div>
    </div>
</asp:Content>