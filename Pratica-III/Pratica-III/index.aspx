<%@ Page Title="" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Pratica_III.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>$(document).ready(function () { $('.parallax').parallax(); $("#home-menu").addClass('active'); });</script>
    <div class="section no-pad no-pad-top">
        <div class="parallax-container">
            <div class="section no-pad-bot no-pad-top">
              <div class="container">
                <h1 class="header center green-text">Clínica Belly</h1>
                <div class="row center">
                  <h5 class="header col s12 white-text">Clinica top</h5>
                </div>
              </div>
            </div>
            <div class="parallax">
                <img src="injecao.jpg" style="transform: translate3d(-50%, 1022.026px, 0px); opacity: 1;"/>
            </div>
        </div>
    </div>
    <div class="section container">
        <h3>Sobre nós</h3>
        <p>Nós da Clinícas Belly fazemos várias consultas todos os dias e temos orgulho de nossas instalações e de nossos mais de 80.000.000.000 de pacientes satisfeitos</p>
    </div>
</asp:Content>