<%@ Page Title="" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="agendamento_consulta.aspx.cs" Inherits="Pratica_III.agendamento_consulta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="section">
        <div class="white container">
            <div class="section">
                <center><h4>Agendamento de consulta</h4></center>
            </div>
            <div class="section">
                <div class="row">
                        <div class="input-field col s6">
                            <i class="material-icons prefix tooltipped" data-tooltip="Email do paciente">contact_mail</i>
                            <asp:TextBox placeholder="Email paciente" data-position="bottom" runat="server" id="txtEmailPaciente" type="email" class="validate"></asp:TextBox>
                        </div>
                        <div class="input-field col s6">
                            <i class="material-icons prefix tooltipped" data-position="bottom" data-tooltip="Email do médico">contact_mail</i>
                            <asp:TextBox placeholder="Email médico" runat="server"  id="txtEmailMedico" type="email" class="validate"></asp:TextBox>
                            <span class="helper-text" data-error="wrong" data-success="right"></span>
                        </div>
                    </div>
                <div class="row">
                    <div class="input-field col s6">
                        <i class="material-icons prefix tooltipped"  data-position="bottom" data-tooltip="Data do dia da consulta">date_range</i>
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
                <div class="section">
                    <center><asp:Button ID="btnSubmit" runat="server" Text="Submeter" cssClass="waves-effect waves-light btn-large green darken-1" OnClick="btn_Submit_Click" /></center>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="server">
    <script>
        $(document).ready(function () {
            $("#agendamento-menu").addClass('active');
            $('.datepicker').datepicker({
                i18n: {
                    months: ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho', 'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'],
                    monthsShort: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun', 'Jul', 'Ago', 'Set', 'Out', 'Nov', 'Dez'],
                    weekdays: ["Domingo", "Segunda", "Terça", "Quarta", "Quinta", "Sexta", "Sábado"],
                    weekdaysShort: ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sab'],
                    weekdaysAbbrev: ["D", "S", "T", "Q", "Q", "S", "S"],
                    cancel: 'Cancelar',
                    clear: 'Limpar',
                    done: 'Ok'
                },
                format: 'yyyy-dd-mm',
                onOpen: function () {
                    var instance = M.Datepicker.getInstance($('.datepicker'));
                    instance.options.minDate = new Date();
                }
            });
        });
    </script>
</asp:Content>
