<%@ Page Title="" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="consultas_medico.aspx.cs" Inherits="Pratica_III.consultas_medico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="section">
        <div class="row white container">
            <div class="section">
                <center><h4>Concluir consultas</h4></center>
            </div>
            <div class="section">
                <div class="section" style="float: right">
                    <div class="col s3">
                        Selecionar Consultas até:
                    </div>
                    <div class="col s4">
                        <asp:DropDownList ID="ddDura" runat="server">
                            <asp:ListItem Value="1">Amanhã</asp:ListItem>
                            <asp:ListItem Value="7">Próxima Semana</asp:ListItem>                            
                            <asp:ListItem Value="30">Próximo Mês</asp:ListItem>                            
                            <asp:ListItem Value="99">O final</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col s2"><asp:Button runat="server" id="btnData" Text="Selecionar Data" class="waves-effect waves-light btn-large green darken-1"/>
                    </div>
                </div>

                <form class="col s12">
                    <div class="row section">
                        <table class="striped">
                            <thead>
                                <tr>
                                    <th>ID consulta</th>
                                    <th>Data</th>
                                    <th>Horário</th>
                                    <th>Paciente</th>
                                    <th>Status de conclusão</th>
                                </tr>
                            </thead>
                            <tbody runat="server" id="tbBody">
                            </tbody>
                        </table>
                    </div>
                </form>
            </div>
        </div>
    </div>
</asp:Content>
