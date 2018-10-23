<%@ Page Title="" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="avaliar.aspx.cs" Inherits="Pratica_III.avaliar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .face {
            color : inherit;
            cursor: pointer;
            transition:0.5s;
        }

        .face.r:hover {
            color : #c62828;
        }
        
        .face.g:hover {
            color : #2e7d32;
        }

        .face.rg:hover {
            color : #e57373;
        }

        .face.rgr:hover {
            color : #a5d6a7 ;
        }
        
        .face.gr:hover {
            color : #424242;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="section">
        <div class="white container">
            <div class="section">
                <center><h4>Avaliar consulta</h4></center>
            </div>
            <div class="section">
                <div class="row">
                    <div class="input-field col s6">
                        <i class="material-icons small">perm_identity</i><span>Identificação da consulta: </span><span id="lblId" runat="server"></span>
                    </div>
                    <div class="input-field col s6">
                        <i class="material-icons small">person</i><span>Paciente: </span><span id="lblPac" runat="server"></span>
                    </div>
                </div>
                <div class="section"></div>
                <div class="row">
                    <div class="col s1">
                    </div>
                    <div class="col s2">
                        <a class="face r"><i class="material-icons large">sentiment_very_dissatisfied</i></a>
                    </div>
                    <div class="col s2">
                        <a class="face rg"><i class="material-icons large">sentiment_dissatisfied</i></a>
                    </div>
                    <div class="col s2">
                        <a class="face gr"><i class="material-icons large">sentiment_neutral</i></a>
                    </div>
                    <div class="col s2">
                        <a class="face rgr"><i class="material-icons large">sentiment_satisfied</i></a>
                    </div>
                    <div class="col s2">
                        <a class="face g"><i class="material-icons large">sentiment_very_satisfied</i></a>
                    </div>
                    <div class="col s1">
                    </div>
                </div>
                <div class="section"></div>
                <section>
                    <div class="input-field col s12">
                      <i class="material-icons prefix">mode_edit</i>
                      <textarea id="textarea1" class="materialize-textarea"></textarea>
                      <label for="textarea1">Comentários (opcional)</label>
                    </div>
                </section>
                <div class="section"></div>
                <div class="section">
                    <center><asp:Button ID="btnSubmit" runat="server" Text="Submeter" cssClass="waves-effect waves-light btn-large green darken-1" /></center>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="server">
    <script>
        M.textareaAutoResize($('#textarea1'));
    </script>
</asp:Content>