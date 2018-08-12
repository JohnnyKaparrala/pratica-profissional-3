<%@ Page Title="" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="cadastro_especialidade.aspx.cs" Inherits="Pratica_III.cadastro_especialidade" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row white container">
        <center><h4>Cadastro de especialidade</h4></center>
        <form class="col s12">
            <div class="input-field col s12">
                <i class="material-icons prefix">local_hospital</i>
                <input id="icon_prefix" type="text" class="validate">
                <label for="icon_prefix">Especialidade</label>
            </div>
            <center><a class="waves-effect waves-light btn-large green darken-1">Submeter</a></center>
        </form>
    </div>
</asp:Content>
