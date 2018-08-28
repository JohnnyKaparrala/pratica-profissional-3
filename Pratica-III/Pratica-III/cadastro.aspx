<%@ Page Title="" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="cadastro.aspx.cs" Inherits="Pratica_III.cadastro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="section">
            <div class="container white ">
                <center><h4>Login</h4></center>
                <div class="row section">
                    <div class="input-field col s6">
                        <i class="material-icons prefix tooltipped" data-position="bottom" data-tooltip="Email para Pacientes">account_box</i>
                        <asp:TextBox placeholder="Cadastro" runat="server" id="txtEmail" type="" class="validate"></asp:TextBox>
                    </div>           
                    <div class="input-field col s6">
                        <i class="material-icons prefix tooltipped" data-position="bottom" data-tooltip="Senha do Cadastro">lock</i>
                        <asp:TextBox placeholder="Senha" runat="server" id="txtSenha" type="" class="validate"></asp:TextBox>
                    </div>
                </div>
                <br />  
                <center><asp:Button ID="btnCadastrar" runat="server" Text="Entrar" class="waves-effect waves-light btn-large green darken-1" OnClick="btnCadastrar_Click" /></center>
            </div>
        </div>
</asp:Content>
