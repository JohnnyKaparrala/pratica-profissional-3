<%@ Page Title="" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="cadastro_especialidade.aspx.cs" Inherits="Pratica_III.cadastro_especialidade" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="section">
        <div class="row white container">
            <div class="section">
                <center><h4>Cadastro de especialidade</h4></center>
            </div>
            <div class="section">
                <form class="col s12">
                    <div class="section">
                        <div class="input-field col s12">
                            <i class="material-icons prefix tooltipped" data-position="bottom" data-tooltip="Nome da especialidade">local_hospital</i>
                            <asp:TextBox placeholder="Especialidade" runat="server" id="txtEsp" type="" class="validate"></asp:TextBox>
                        </div>
                    </div>
                    <div class="section">
                        <center><asp:Button CausesValidation="False" runat="server" ID="btn_Submit" class="waves-effect waves-light btn-large green darken-1" Text="Submeter" OnClick="btn_Submit_Click"/></center>
                    </div>
                </form>
            </div>
        </div>
    </div>
</asp:Content>
