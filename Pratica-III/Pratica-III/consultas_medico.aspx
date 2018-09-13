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
                <form class="col s12">
                    <div class="row section">
                        <table class="striped">
                            <thead>
                                <tr>
                                    <th>ID consulta</th>
                                    <th>Horário início</th>
                                    <th>Paciente</th>
                                    <th>Concluída</th>
                                    <th>Cadastro</th>
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
