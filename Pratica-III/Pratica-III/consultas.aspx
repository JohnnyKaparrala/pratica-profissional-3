<%@ Page Title="" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="consultas.aspx.cs" Inherits="Pratica_III.avaliacao_consulta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>$("#mudar-senha").addClass('active'); });</script>
    <div class="section">
        <div class="row white container">
            <div class="section">
                <center><h4>Avaliar consultas</h4></center>
            </div>
            <div class="section">
                <form class="col s12">
                    <div class="row section">
                        <table class="striped">
                            <thead>
                                <tr>
                                    <th>ID consulta</th>
                                    <th>Horário início</th>
                                    <th>Médico</th>
                                    <th>Concluída</th>
                                    <th>Avaliar</th>
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
