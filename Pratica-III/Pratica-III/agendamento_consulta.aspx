<%@ Page Title="" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="agendamento_consulta.aspx.cs" Inherits="Pratica_III.agendamento_consulta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>$("#agendamento-menu").addClass('active');</script>
    <div class="white container">
        <center><h4>Agendamento consulta</h4></center>
        <div class="row">
                <div class="input-field col s6">
                    <i class="material-icons prefix">contact_mail</i>
                    <input id="icon_prefix" type="email" class="validate">
                    <label for="icon_prefix">Email paciente</label>
                </div>
                <div class="input-field col s6">
                    <i class="material-icons prefix">contact_mail</i>
                    <input id="email" type="email" class="validate">
                    <label for="email">Email medico</label>
                    <span class="helper-text" data-error="wrong" data-success="right"></span>
                </div>
            </div>
        <div class="row">
            <div class="input-field col s6">
                <i class="material-icons prefix">date_range</i>
                <input id="date" type="text" class="datepicker">
                <label for="date">Dia</label>
            </div>
            <div class="input-field col s6">
                <select>
                  <option value="" disabled selected>Escolha o horário</option>
                  <option value="1">09:00</option>
                  <option value="1">09:30</option>
                  <option value="1">10:00</option>
                  <option value="1">10:30</option>
                  <option value="1">11:00</option>
                  <option value="1">11:30</option>
                  <option value="1">14:00</option>
                  <option value="1">14:30</option>
                  <option value="1">15:00</option>
                  <option value="1">15:30</option>
                  <option value="1">16:00</option>
                  <option value="1">16:30</option>
                </select>
                <label>Horário</label>
            </div>
        </div>
        <div class="row">
            <div class="input-field col s12">
                <select>
                  <option value="" disabled selected>Escolha a duração</option>
                  <option value="1">30 min</option>
                  <option value="1">60 min</option>
                </select>
                <label>Duração</label>
            </div>
        </div>
        <center><a class="waves-effect waves-light btn-large green darken-1">Submeter</a></center>
    </div>
</asp:Content>
