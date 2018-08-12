<%@ Page Title="" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="cadastro_consulta.aspx.cs" Inherits="Pratica_III.cadastro_consulta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container white">
        <center><h4>Consulta</h4></center>
        <div class="row section">
            <div class="input-field col s9">
                <i class="material-icons prefix">account_circle</i>
                <input id="icon_prefix" type="text" class="validate">
                <label for="icon_prefix">ID Consulta</label>
            </div>
            <div class="col s3 input-field">
                <a class="waves-effect waves-light btn-small green darken-1">Procurar consulta</a>
            </div>
        </div>
        <div class="row section">
            <div class="input-field col s12">
                <i class="material-icons prefix">note</i>
                <textarea id="textarea" class="materialize-textarea"></textarea>
                <label for="textarea">Anotações (opcional)</label>
            </div>
        </div>
        <center><a class="waves-effect waves-light btn-large green darken-1 disabled">Concluir consulta</a></center>
    </div>
</asp:Content>
