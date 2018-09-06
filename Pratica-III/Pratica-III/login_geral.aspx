<%@ Page Title="" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="login_geral.aspx.cs" Inherits="Pratica_III.cadastro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="section">
            <div class="container white ">
                <div class="section">
                    <center><h4>Login</h4></center>
                </div>
                <div class="section">
                    <div class="row section">
                        <div class="input-field col s6">
                            <i class="material-icons prefix tooltipped" data-position="bottom" data-tooltip="Email para Pacientes">account_box</i>
                            <asp:TextBox placeholder="Cadastro" runat="server" id="txtEmail" type="" class="validate"></asp:TextBox>
                        </div>           
                        <div class="input-field col s6">
                            <i class="material-icons prefix tooltipped" data-position="bottom" data-tooltip="Senha do Cadastro">lock</i>
                            <asp:TextBox placeholder="Senha" runat="server" id="txtSenha" type="password" class="validate"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row section">
                        <div class="input-field col s12">
                            <asp:DropDownList runat="server" id="cargo">
                                <asp:ListItem disabled>Escolha o cargo</asp:ListItem>
                                <asp:ListItem>Administrador</asp:ListItem>
                                <asp:ListItem>Médico</asp:ListItem>
                                <asp:ListItem>Paciente</asp:ListItem>
                            </asp:DropDownList>
                            <label>Cargo</label>
                        </div>
                    </div>
                </div>
                <div class="section">
                    <center><asp:Button ID="btnCadastrar" runat="server" Text="Entrar" class="waves-effect waves-light btn-large green darken-1" OnClick="btnCadastrar_Click" /></center>
                </div>
            </div>
        </div>
</asp:Content>
