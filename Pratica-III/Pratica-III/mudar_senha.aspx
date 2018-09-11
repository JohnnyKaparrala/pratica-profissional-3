<%@ Page Title="" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="mudar_senha.aspx.cs" Inherits="Pratica_III.mudar_senha" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>$("#mudar-senha").addClass('active'); });</script>
    <div class="section">
        <div class="row white container">
            <div class="section">
                <center><h4>Cadastro de paciente</h4></center>
            </div>
            <div class="section">
                <form class="col s12">
                    <div class="row section">
                        <div class="input-field col s6">
                            <i class="material-icons prefix tooltipped" data-position="bottom" data-tooltip="Senha antiga">lock_open</i>
                            <asp:TextBox placeholder="Senha antiga" runat="server" id="txtSenha_antiga" type="password" class="validate"></asp:TextBox>
                        </div>
                        <div class="input-field col s6">
                            <i class="material-icons prefix tooltipped" data-position="bottom" data-tooltip="Senha nova">lock_outline</i>
                            <asp:TextBox placeholder="Senha nova" runat="server" id="txtSenha_nova" type="password" class="validate"></asp:TextBox>
                        </div>
                    </div>
                    <div class="section">
                        <center><asp:Button CausesValidation="False" runat="server" ID="btn_Submit" class="waves-effect waves-light btn-large green darken-1" Text="Mudar senha" OnClick="btnSubmit_Click"/></center>
                    </div>
                </form>
            </div>
        </div>
    </div>
</asp:Content>
