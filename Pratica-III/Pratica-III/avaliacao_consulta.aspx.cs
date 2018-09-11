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
    public partial class avaliacao_consulta : System.Web.UI.Page
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

                sqlCmd.CommandText = "SELECT C.ID, C.HORARIO, C.DURACAO, M.NOME FROM CONSULTA C, PACIENTE P, MEDICO M WHERE P.ID = C.ID_PACIENTE";
                SqlDataReader reader = sqlCmd.ExecuteReader();

                while (reader.Read())
                {
                    tbBody.InnerHtml += "<tr><td>" + reader.GetValue(0).ToString() + "</td><td>" + reader.GetValue(1).ToString() + "</td><td>" + "" + "</td><td>" + reader.GetValue(3).ToString() + "</td><td>" + reader.GetValue(4).ToString() + "</td><td>" + "" + "</td></tr>";
                }
            }
            catch (Exception er)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr", "javascript:M.toast({html: Ocorreu um erro durante a operação!'});", true);
            }
            
        }
    }
}