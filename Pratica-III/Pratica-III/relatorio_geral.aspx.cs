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

namespace Pratica_III
{
    public partial class relatorio_geral : System.Web.UI.Page
    {
        conexaoBD acessoBD;
        String conString;

        protected void limparInputs()
        {

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
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

                DateTime hj = DateTime.Now;
                if (ddDura.SelectedValue == "99")
                {
                    sqlCmd.CommandText = "SELECT C.ID, C.HORARIO, C.DURACAO, M.NOME, P.NOME, CONCLUIDA FROM CONSULTA C, PACIENTE P, MEDICO M WHERE M.ID = C.ID_MEDICO AND P.ID = C.ID_PACIENTE AND C.HORARIO > @DIA_ANTERIOR";

                }
                else
                {
                    sqlCmd.CommandText = "SELECT C.ID, C.HORARIO, C.DURACAO, M.NOME, P.NOME, CONCLUIDA FROM CONSULTA C, PACIENTE P, MEDICO M WHERE M.ID = C.ID_MEDICO AND P.ID = C.ID_PACIENTE AND C.HORARIO BETWEEN @DIA_ANTERIOR AND @DIA_POSTERIOR";
                    sqlCmd.Parameters.AddWithValue("@DIA_POSTERIOR", hj.AddDays(Convert.ToDouble(ddDura.SelectedValue)).ToString("dd-M-yyyy"));
                }
                sqlCmd.Parameters.AddWithValue("@DIA_ANTERIOR", hj.ToString("dd-M-yyyy"));//'2018-08-18 00:00:00.0000'
                SqlDataReader reader = sqlCmd.ExecuteReader();

                tbBody.InnerHtml = "";

                while (reader.Read())
                {
                    string val = "✕";
                    if (reader.GetValue(5).ToString() == "True")
                    {
                        val = "✓";
                    }
                    string val2 = "30 min";
                    if (reader.GetValue(2).ToString() == "True")
                    {
                        val2 = "60 min";
                    }
                    tbBody.InnerHtml += "<tr><td>" + reader.GetValue(0).ToString() + "</td><td>" + reader.GetValue(1).ToString() + "</td><td>" + val2 + "</td><td>" + reader.GetValue(3).ToString() + "</td><td>" + reader.GetValue(4).ToString() + "</td><td>" + val;
                    
                    if (reader.GetValue(5).ToString() == "-1")
                    {
                        tbBody.InnerHtml += "<a href='remarcar.aspx?id="+reader.GetValue(0)+"' class='waves - effect waves - light btn - large green darken-1'>Remarcar</a>";
                    }

                    tbBody.InnerHtml += "</td></tr>";
                }
                
            }
            catch (Exception er)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr", "javascript:M.toast({html: Ocorreu um erro durante a operação!'});", true);
            }

            acessoBD.FecharConexao();
        }
    }
}