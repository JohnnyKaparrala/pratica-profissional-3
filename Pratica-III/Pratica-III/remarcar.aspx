<%@ Page Title="" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="remarcar.aspx.cs" Inherits="Pratica_III.remarcar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2> Selecione a nova data da Consulta:</h2>
    <div class="section">
        <div class="row">                
            <div class="input-field col s6">
                <i class="material-icons prefix tooltipped" data-position="bottom" data-tooltip="Formato: aaaa-mm-dd">date_range</i>
                <asp:TextBox placeholder="Nova data" runat="server" id="txtData" type="text" class="datepicker"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="input-field col s6">
                <asp:Button ID="btnRemarcar" runat="server" Text="Remarcar" class="waves-effect waves-light btn-large green darken-1" OnClick="btnRemarcar_Click"></asp:Button>
            </div>
            <div>
                <asp:DropDownList runat="server" id="txtHor">
                            <asp:ListItem disabled>Escolha o horário</asp:ListItem>
                        </asp:DropDownList>
                        <label>Horário</label>
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
                format: 'yyyy-mm-dd',
                onOpen: function () {
                    var instance = M.Datepicker.getInstance($('.datepicker'));
                    instance.options.minDate = new Date();
                }
            });
        });
    </script>
</asp:Content>
