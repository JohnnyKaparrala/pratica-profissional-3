<%@ Page Title="" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="cadastro_consulta.aspx.cs" Inherits="Pratica_III.cadastro_consulta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="section">
        <div class="container white">
            <div class="section">
                <center><h4>Consulta</h4></center>
            </div>
            <div class="section" style="font-size:18px;">
                <div class="row">
                    <i class="material-icons small">perm_identity</i><span>Identificação da consulta: </span><span id="lblId" runat="server"></span>
                </div>
                <div class="row">
                    <i class="material-icons small">person</i><span>Paciente: </span><span id="lblPac" runat="server"></span>
                </div>
            </div>
            <div class="section">
                <div class="row section">
                    <div class="input-field col s12">
                        <i class="material-icons prefix tooltipped" data-position="bottom" data-tooltip="Anotações adicionais sobre o paciente">note_add</i>
                        <asp:TextBox placeholder="Anotações (opcional)" runat="server" id="txtAnotacao" type="" class="validate"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="section">
                <center><asp:Button ID="btnSubmit" runat="server" Text="Concliur consulta" class="waves-effect waves-light btn-large green darken-1" OnClick="btn_Submit_Click" /></center>
            </div>
        </div>
    </div>
</asp:Content>
