using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pratica_III
{
    public partial class menu : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string add = "";
            /*
             0: secretaria
             1: medico
             2: paciente
            */
            switch (Session["cargo"])
            {
                case 0:
                    {
                        add += "<li><a href=\"agendamento_consulta.aspx\">Agendamentos de consulta</a></li>";
                        add += "<li><a class=\"dropdown-trigger\" data-target=\"cadastros-drop\">Cadastros<i class=\"material-icons right\">arrow_drop_down</i></a></li>";
                        add += "<li><a class=\"dropdown-trigger\" data-target=\"relatorios-drop\">Relatórios<i class=\"material-icons right\">arrow_drop_down</i></a></li>";
                    }break;

                case 1:
                    {
                        add += "<li><a href=\"cadastro_consulta.aspx\">cadastro consulta</a></li>";
                    }
                    break;

                case 2:
                    {
                        add += "<li><a href=\"cadastro_consulta.aspx\">cadastro consulta</a></li>";
                    }
                    break;
                    
                    break;
                default: {
                        
                    } break;
            }
            if (Session["cargo"] == null)
                add += "<li><a href=\"login_geral.aspx\">Login</a></li>";
            else
            {
                add += "<li><a href=\"logout.aspx\">Logout</a></li>";
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr", "javascript:M.toast({html: 'Bem-vindo(a)!'});", true);
            }

            h_menu.InnerHtml = "<li><a href=\"index.aspx\">Home</a></li>" + add;
            /*
            <li id="agendamento-menu"><a href="agendamento_consulta.aspx">Agendamentos de consulta</a></li>
            <li id="cadastro-menu"><a class="dropdown-trigger" data-target="cadastros-drop">Cadastros<i class="material-icons right">arrow_drop_down</i></a></li>
            <li id="relatorio-menu"><a class="dropdown-trigger" data-target="relatorios-drop">Relatórios<i class="material-icons right">arrow_drop_down</i></a></li>
            <li id="login-menu"><a href="login_geral.aspx" style="">Login</a></li>
             */

        }
    }
}