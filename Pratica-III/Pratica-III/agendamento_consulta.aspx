<%@ Page Title="" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="agendamento_consulta.aspx.cs" Inherits="Pratica_III.agendamento_consulta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>$("#agendamento-menu").addClass('active');</script>
    <div class="section">
        <div class="white container">
            <center><h4>Agendamento consulta</h4></center>
            <div class="row">
                    <div class="input-field col s6">
                        <i class="material-icons prefix" data-tooltip="Email do paciente">contact_mail</i>
                        <asp:TextBox placeholder="Email paciente" data-position="bottom" runat="server" id="txtEmailPaciente" type="email" class="validate"></asp:TextBox>
                    </div>
                    <div class="input-field col s6">
                        <i class="material-icons prefix" data-position="bottom" data-tooltip="Email do médico">contact_mail</i>
                        <asp:TextBox placeholder="Email médico" runat="server"  id="txtEmailMedico" type="email" class="validate"></asp:TextBox>
                        <span class="helper-text" data-error="wrong" data-success="right"></span>
                    </div>
                </div>
            <div class="row">
                <div class="input-field col s6">
                    <i class="material-icons prefix"  data-position="bottom" data-tooltip="Data do dia da consulta">date_range</i>
                    <asp:TextBox placeholder="Dia" runat="server"  id="txtData" type="text" class="datepicker"></asp:TextBox>
                </div>
                <div class="input-field col s6">
                    <asp:DropDownList runat="server" id="txtHor">
                        <asp:ListItem disabled>Escolha o horário</asp:ListItem>
                        <asp:ListItem>09:00</asp:ListItem>
                        <asp:ListItem>09:30</asp:ListItem>
                        <asp:ListItem>10:00</asp:ListItem>
                        <asp:ListItem>10:30</asp:ListItem>
                        <asp:ListItem>11:00</asp:ListItem>
                        <asp:ListItem>11:30</asp:ListItem>
                        <asp:ListItem>14:00</asp:ListItem>
                        <asp:ListItem>14:30</asp:ListItem>
                        <asp:ListItem>15:00</asp:ListItem>
                        <asp:ListItem>15:30</asp:ListItem>
                        <asp:ListItem>16:00</asp:ListItem>
                        <asp:ListItem>16:30</asp:ListItem>
                    </asp:DropDownList>
                    <label>Horário</label>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <asp:DropDownList runat="server" id="txtDuracao">
                        <asp:ListItem disabled>Escolha a duração</asp:ListItem>
                        <asp:ListItem>30 min</asp:ListItem>
                        <asp:ListItem>60 min</asp:ListItem>
                    </asp:DropDownList>
                    <label>Duração</label>
                </div>
            </div>
            <center><asp:Button ID="btnSubmit" runat="server" Text="Submeter" cssClass="waves-effect waves-light btn-large green darken-1" OnClick="btn_Submit_Click" /></center>
        </div>
    </div>
</asp:Content>
