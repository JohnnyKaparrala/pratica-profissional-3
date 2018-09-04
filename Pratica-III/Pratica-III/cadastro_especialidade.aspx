<%@ Page Title="" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="cadastro_especialidade.aspx.cs" Inherits="Pratica_III.cadastro_especialidade" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="section">
        <div class="row white container">
            <center><h4>Cadastro de especialidade</h4></center>
            <form class="col s12">
                <div class="input-field col s12">
                    <i class="material-icons prefix tooltipped" data-position="bottom" data-tooltip="Nome da especialidade">local_hospital</i>
                    <asp:TextBox placeholder="Especialidade" runat="server" id="txtEsp" type="" class="validate"></asp:TextBox>
                </div>
                <center><asp:Button CausesValidation="False" runat="server" ID="btn_Submit" class="waves-effect waves-light btn-large green darken-1" Text="Submeter" OnClick="btn_Submit_Click"/></center>
            </form>
        </div>
    </div>
</asp:Content>
