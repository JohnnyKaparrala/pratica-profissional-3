<%@ Page Title="" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="cadastro_paciente.aspx.cs" Inherits="Pratica_III.cadastro_paciente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="section">
        <div class="row white container">
            <div class="section">
                <center><h4>Cadastro de paciente</h4></center>
            </div>
            <div class="section">
                <form class="col s12">
                    <div class="row">
                        <div class="input-field col s6">
                            <i class="material-icons prefix tooltipped" data-position="bottom" data-tooltip="Nome do paciente">account_circle</i>
                            <asp:TextBox placeholder="Nome" runat="server" id="txtNome" type="text" class="validate"></asp:TextBox>
                        </div>
                        <div class="input-field col s6">
                            <i class="material-icons prefix tooltipped" data-position="bottom" data-tooltip="Email do paciente">contact_mail</i>
                            <asp:TextBox placeholder="Email" runat="server" id="txtEmail" type="email" class="validate"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                    <div class="input-field col s6">
                        <i class="material-icons prefix tooltipped" data-position="bottom" data-tooltip="Formato: (DDD)1234-5678">contact_phone</i>
                        <asp:TextBox placeholder="Telefone Celular" runat="server" id="txtTelefoneCel" type="tel" class="validate"></asp:TextBox>
                    </div>
                    <div class="input-field col s6">
                        <i class="material-icons prefix tooltipped" data-position="bottom" data-tooltip="Formato: 1234-5678">phone</i>
                        <asp:TextBox placeholder="Telefone Residencial" runat="server" id="txtTelefoneRes" type="tel" class="validate"></asp:TextBox>
                    </div>
                    </div>
                    <div class="row">
                        <div class="input-field col s6">
                            <i class="material-icons prefix tooltipped" data-position="bottom" data-tooltip="Formato: aaaa-dd-mm">date_range</i>
                            <asp:TextBox placeholder="Aniversário" runat="server" id="txtNiver" type="text" class="datepicker"></asp:TextBox>
                        </div>
                        <div class="input-field col s6">
                            <i class="material-icons prefix tooltipped" data-position="bottom" data-tooltip="Formato: C:\pasta\arquivo.png">camera_alt</i>
                            <asp:TextBox placeholder="Foto" runat="server" id="txtFoto" type="" class="validate"></asp:TextBox>
                        </div>
                    </div>
                    <center><asp:Button CausesValidation="False" runat="server" ID="btn_Submit" class="waves-effect waves-light btn-large green darken-1" Text="Submeter" OnClick="btn_Submit_Click"/></center>
                </form>
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
                yearRange: 100,
                format: 'yyyy-dd-mm',
                onOpen: function () {
                    var instance = M.Datepicker.getInstance($('.datepicker'));
                    instance.options.maxDate = new Date();
                }
            });
        });
    </script>
</asp:Content>
