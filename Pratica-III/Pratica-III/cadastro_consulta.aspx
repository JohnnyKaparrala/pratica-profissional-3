<%@ Page Title="" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="cadastro_consulta.aspx.cs" Inherits="Pratica_III.cadastro_consulta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="section">
        <div class="container white">
            <center><h4>Consulta</h4></center>
            <div class="row section">
                <div class="input-field col s9">
                    <i class="material-icons prefix tooltipped" data-position="bottom" data-tooltip="ID da consulta">search</i>
                    <asp:TextBox placeholder="ID da consulta" runat="server" id="txtID" type="" class="validate" OnClick="btn_consulta_Click"></asp:TextBox>
                </div>
                <div class="col s3 input-field">
                    <asp:Button ID="Button1" runat="server" Text="Procurar consulta" class="waves-effect waves-light btn-small green darken-1" OnClick="btn_consulta_Click" />
                </div>
            </div>
            <div class="row section">
                <div class="input-field col s12">
                    <i class="material-icons prefix tooltipped" data-position="bottom" data-tooltip="Anotações adicionais sobre o paciente">note_add</i>
                    <asp:TextBox placeholder="Anotações (opcional)" runat="server" id="txtAnotacao" type="" class="validate"></asp:TextBox>
                </div>
            </div>
            <center><asp:Button ID="btnSubmit" runat="server" Text="Submeter" class="waves-effect waves-light btn-large green darken-1 disabled" OnClick="btn_Submit_Click" /></center>
        </div>
    </div>
</asp:Content>
