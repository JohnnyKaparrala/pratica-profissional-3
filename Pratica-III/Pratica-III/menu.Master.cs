using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Text.RegularExpressions;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Pratica_III.App_Start;
using System.IO;
using System.Drawing;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Net.Mail;

namespace Pratica_III
{
    public partial class menu : System.Web.UI.MasterPage
    {
        conexaoBD acessoBD;
        String conString;
        protected void Page_Load(object sender, EventArgs e)
        {
            string add = "";
            /*
             0: secretaria
             1: medico
             2: paciente
            */
            string pageName = Path.GetFileNameWithoutExtension(Page.AppRelativeVirtualPath);
            switch (Session["cargo"])
            {
                case 0://adm
                    {
                        add += "<li><a href=\"agendamento_consulta.aspx\">Agendamentos de consulta</a></li>";
                        add += "<li><a class=\"dropdown-trigger\" data-target=\"cadastros-drop\">Cadastros<i class=\"material-icons right\">arrow_drop_down</i></a></li>";
                        add += "<li><a class=\"dropdown-trigger\" data-target=\"relatorios-drop\">Relatórios<i class=\"material-icons right\">arrow_drop_down</i></a></li>";
                        add += "<li><a href=\"servidor.aspx\">Servidor</a></li>";
                    }
                    break;

                case 1://med
                    {
                        add += "<li><a href=\"consultas_medico.aspx\">Consultas</a></li>";
                        if (pageName != "index" && pageName != "logout" && pageName != "relatorio_geral" && pageName != "relatorio_medicao" && pageName != "relatorio_paciente" && pageName != "mudar_senha" && pageName != "consultas_medico" && pageName != "cadastro_consulta")
                        {
                            body.InnerHtml = "<h4>Você não tem acesso a esta página</h4><p class=\"flow-text\"><a href=\"index.aspx\">Voltar ao menu</a></p>";
                        }
                    }
                    break;

                case 2://pac
                    {
                        add += "<li><a href=\"consultas.aspx\">Consultas</a></li>";
                        add += "<li><a href=\"contato.aspx\">Contato</a></li>";
                        if (pageName != "avaliacao_consulta" && pageName != "index" && pageName != "logout" && pageName != "mudar_senha" && pageName != "consultas" && pageName != "avaliar")
                        {
                            body.InnerHtml = "<h4>Você não tem acesso a esta página</h4><p class=\"flow-text\"><a href=\"index.aspx\">Voltar ao menu</a></p>";
                        }
                    }
                    break;

                default:
                    {

                    }
                    break;
            }
            if (Session["cargo"] == null)
            {
                add += "<li><a href=\"contato.aspx\">Contato</a></li>";
                add += "<li><a href=\"login_geral.aspx\">Login</a></li>";
                if (pageName != "contato" && pageName != "login_geral" && pageName != "index")
                {
                    body.InnerHtml = "<h4>Você não tem acesso a esta página</h4><p class=\"flow-text\"><a href=\"index.aspx\">Voltar ao menu</a></p>";
                }
            }
            else
            {
                add += "<li><a href=\"mudar_senha.aspx\">Mudar senha</a></li>";
                add += "<li><a href=\"logout.aspx\">Logout</a></li>";
                if (Convert.ToBoolean(Session["wel"]))
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr", "javascript:M.toast({html: 'Bem-vindo(a)!'});", true);
                Session["wel"] = false;
            }

            h_menu.InnerHtml = "<li><a href=\"index.aspx\">Home</a></li>" + add;

            if (Convert.ToInt32(Session["cargo"]) == 1 || Convert.ToInt32(Session["cargo"]) == 2)
            {
                conString = WebConfigurationManager.ConnectionStrings["conexaoBD"].ConnectionString;
                acessoBD = new conexaoBD();
                acessoBD.Connection(conString);
                acessoBD.AbrirConexao();

                SqlCommand sqlCmd = new SqlCommand();
                SqlConnection myConnection;
                myConnection = new SqlConnection(conString);
                myConnection.Open();
                sqlCmd.Connection = myConnection;

                sqlCmd.CommandText = "SELECT FOTO FROM " + ((Convert.ToInt32(Session["cargo"]) == 1) ? "MEDICO" : "PACIENTE") + " WHERE ID = " + Session["idquem"];
                SqlDataReader reader = sqlCmd.ExecuteReader();

                string base64String;
                if (reader.Read())
                {
                    byte[] imagem = (byte[])(reader[0]);
                    base64String = Convert.ToBase64String(imagem);
                }
                else
                {
                    base64String = "";
                }

                h_menu.InnerHtml += "<li><div style=\"display: flex; height: 64px;\"><img ID=\"imgLogin\" runat=\"server\" src=\"" + String.Format("data:image/jpeg;base64,{0}", base64String) + "\" class='circle' style='width: 50px; height: 50px; margin: auto;'/></div></li>";
            }

            /*
            <li id="agendamento-menu"><a href="agendamento_consulta.aspx">Agendamentos de consulta</a></li>
            <li id="cadastro-menu"><a class="dropdown-trigger" data-target="cadastros-drop">Cadastros<i class="material-icons right">arrow_drop_down</i></a></li>
            <li id="relatorio-menu"><a class="dropdown-trigger" data-target="relatorios-drop">Relatórios<i class="material-icons right">arrow_drop_down</i></a></li>
            <li id="login-menu"><a href="login_geral.aspx" style="">Login</a></li>
             */

        }
    }
}