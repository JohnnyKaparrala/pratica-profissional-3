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

namespace Pratica_III
{
    public partial class consultas_medico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                conexaoBD acessoBD;
                String conString;

                conString = WebConfigurationManager.ConnectionStrings["conexaoBD"].ConnectionString;
                acessoBD = new conexaoBD();
                acessoBD.Connection(conString);
                acessoBD.AbrirConexao();

                SqlCommand sqlCmd = new SqlCommand();
                SqlConnection myConnection;
                myConnection = new SqlConnection(conString);
                myConnection.Open();
                sqlCmd.Connection = myConnection;

                sqlCmd.CommandText = "SELECT C.ID, C.HORARIO, P.NOME, C.CONCLUIDA FROM CONSULTA C, PACIENTE P, MEDICO M WHERE P.ID = C.ID_PACIENTE AND C.ID_MEDICO = (SELECT ID FROM MEDICO WHERE EMAIL = @EMAIL)";
                sqlCmd.Parameters.AddWithValue("@EMAIL", Session["quem"]);
                SqlDataReader reader = sqlCmd.ExecuteReader();

                while (reader.Read())
                {
                    string val = "✕";
                    bool conc = false;
                    if (reader.GetValue(3).ToString() == "True")
                    {
                        val = "✓";
                        conc = true;
                    }
                    tbBody.InnerHtml += "<tr><td>" + reader.GetValue(0).ToString() + "</td><td>" + reader.GetValue(1).ToString() + "</td><td>" + reader.GetValue(2).ToString() + "</td><td><b>" + val + "</b></td><td>" + (conc ? "Conclusão não disponível" : $"<a href=\"cadastro_consulta.aspx?pac={reader.GetValue(2).ToString()}&id={reader.GetValue(0).ToString()}\" class=\"waves-effect waves-light btn-small green darken-1\">CONCLUIR</a>") + "</td><td>";
                }
            }
            catch (Exception er)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr", "javascript:M.toast({html: Ocorreu um erro durante a operação!'});", true);
            }
        }
    }
}