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

                sqlCmd.CommandText = "SELECT C.ID, C.HORARIO, M.NOME, C.CONCLUIDA FROM CONSULTA C, PACIENTE P, MEDICO M WHERE P.ID = C.ID_PACIENTE AND C.ID_PACIENTE = (SELECT ID FROM PACIENTE WHERE EMAIL = @EMAIL)";
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
                    tbBody.InnerHtml += "<tr><td>" + reader.GetValue(0).ToString() + "</td><td>" + reader.GetValue(1).ToString() + "</td><td>" + reader.GetValue(2).ToString() + "</td><td>" + val + "</td><td>" + (conc?"":"<asp:Button runat=\"server\" Text=\"AVALIAR\" class=\"waves-effect waves-light btn-small green darken-1\" OnClick=\"btn_consulta_Click\" />") + "</td><td>";
                }
            }
            catch (Exception er)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr", "javascript:M.toast({html: Ocorreu um erro durante a operação!'});", true);
            }
            
        }
    }
}