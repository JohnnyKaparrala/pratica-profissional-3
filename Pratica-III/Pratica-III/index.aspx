<%@ Page Title="" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Pratica_III.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>$("#home-menu").addClass('active');</script>
    <div class="row white container">
        <center><h4>Home</h4></center>
        <div class="section">
            A gente é um consultório bacana q curte cuidar dos pacientes.
        </div>
    </div>
</asp:Content>
