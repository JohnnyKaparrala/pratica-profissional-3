<%@ Page Title="" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="cadastro_medico.aspx.cs" Inherits="Pratica_III.cadastro_medico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row white container">
        <center><h4>Cadastro de médico</h4></center>
        <form class="col s12">
            <div class="row">
            <div class="input-field col s6">
                <i class="material-icons prefix">account_circle</i>
                <input id="icon_prefix" type="text" class="validate">
                <label for="icon_prefix">Nome</label>
            </div>
            <div class="input-field col s6">
                <i class="material-icons prefix">contact_mail</i>
                <input id="email" type="email" class="validate">
                <label for="email">Email</label>
                <span class="helper-text" data-error="wrong" data-success="right"></span>
            </div>
            </div>
            <div class="row">
            <div class="input-field col s6">
                <i class="material-icons prefix">contact_phone</i>
                <input id="icon_telephone" type="tel" class="validate">
                <label for="icon_telephone">Telefone Celular</label>
            </div>
            <div class="input-field col s6">
                <i class="material-icons prefix">phone</i>
                <input id="icon_telephone2" type="tel" class="validate">
                <label for="icon_telephone2">Telefone Residencial</label>
            </div>
            </div>
            <div class="row">
            <div class="input-field col s6">
                <i class="material-icons prefix">date_range</i>
                <input id="date" type="text" class="datepicker">
                <label for="date">Aniversário</label>
            </div>
            <div class="input-field col s6">
                <div class="file-field input-field">
                    <div class="btn-small grey darken-4">
                    <span>Foto</span>
                    <input type="file">
                    </div>
                    <div class="file-path-wrapper">
                    <input class="file-path validate" type="text">
                    </div>
                </div>
            </div>
            </div>
            <div class="input-field col s12">
                <select>
                  <option value="" disabled selected>Escolha a especialidade</option>
                  <option value="1">Esp 1</option>
                  <option value="2">esp 2</option>
                  <option value="3">esp 3</option>
                </select>
                <label>Especialidade</label>
            </div>
            <center><a class="waves-effect waves-light btn-large green darken-1">Submeter</a></center>
        </form>
    </div>
</asp:Content>
