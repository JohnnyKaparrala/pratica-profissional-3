<%@ Page Title="" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Pratica_III.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>$(document).ready(function () { $('.parallax').parallax(); $("#home-menu").addClass('active'); });</script>
    <div class="section no-pad no-pad-top">
        <div class="parallax-container">
            <div class="section no-pad-bot no-pad-top">
              <div class="container">
                <h1 class="header center green-text">Clínica Mercy</h1>
                <div class="row center">
                  <h5 class="header col s12 white-text light">Venha se juntar a mais de 50.000 pacientes por hora. E temos orgulho de nossos profissionais altamente especializados.</h5>
                </div>
              </div>
            </div>
            <div class="parallax">
                <img src="injecao.jpg" style="transform: translate3d(-50%, 1022.026px, 0px); opacity: 1;"/>
            </div>
        </div>
    </div>
    <div class="section container">
        <blockquote style="border-left-color: #4CAF50" class="flow-text">Nós da Cliníca Mercy fazemos várias consultas todos os dias e temos orgulho de nossas instalações e de nossos mais de 80.000.000.000 de pacientes diários satisfeitos</blockquote>
    </div>
    <div class="section grey lighten-4">
        <div class="container">
            <h3>Blblabl</h3>
            <p class="flow-text">lorem ipsum para marcar uma consulta <a href="contato.aspx">contate-nos</a></p>
        </div>
    </div>
</asp:Content>