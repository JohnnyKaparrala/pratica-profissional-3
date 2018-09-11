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
    public partial class cadastro_especialidade : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void limparInputs()
        {
            txtEsp.Text = "";
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            try
            {
                // associando a string de conexao com o BD com o configurado no WebConfig
                String conString = WebConfigurationManager.ConnectionStrings["conexaoBD"].ConnectionString;

                // instanciar a classe conexaoBD
                conexaoBD acessoBD = new conexaoBD();
                acessoBD.Connection(conString);
                acessoBD.AbrirConexao();

                if (txtEsp.Text == "")
                {
                    throw new Exception("Preencha todos os campos!");
                }
                else
                {
                    SqlConnection myConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["conexaoBD"].ConnectionString);
                    myConnection.Open();
                    conString = WebConfigurationManager.ConnectionStrings["conexaoBD"].ConnectionString;
                    acessoBD = new conexaoBD();
                    acessoBD.Connection(conString);
                    acessoBD.AbrirConexao();
                    SqlCommand sqlcmd = new SqlCommand();
                    myConnection = new SqlConnection(conString);
                    myConnection.Open();
                    sqlcmd.Connection = myConnection;
                    sqlcmd.CommandText = "SELECT TOP 1 1 FROM ESPECIALIDADE_MEDICO WHERE NOME = @NOME";
                    sqlcmd.Parameters.AddWithValue("@NOME", txtEsp.Text);
                    SqlDataReader reader = sqlcmd.ExecuteReader();
                    int val = -1;
                    reader.Read();
                    val = Convert.ToInt32(reader.GetValue(0).ToString());
                    reader.Close();
                    if (val == 1)
                    {
                        throw new Exception("Especialidade já cadastrada!");
                    }
                    
                    myConnection = new SqlConnection(conString);
                    myConnection.Open();

                    SqlCommand sqlCmd = new SqlCommand();
                    sqlCmd.Connection = myConnection;
                    if (sqlCmd.Parameters.Count == 0)
                    {
                        sqlCmd.CommandText = "INSERT INTO ESPECIALIDADE_MEDICO(NOME) VALUES (@NOME)";

                        sqlCmd.Parameters.AddWithValue("@NOME", txtEsp.Text);
                    }

                    int iResultado = sqlCmd.ExecuteNonQuery();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr", "javascript:M.toast({html: 'Especialidade registrada com sucesso!'});", true);
                    acessoBD.FecharConexao();
                }
            }
            catch (Exception er)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr", "javascript:M.toast({html: 'Erro: " + er.Message + "'});", true);
                limparInputs();
            }
        }
    }
}