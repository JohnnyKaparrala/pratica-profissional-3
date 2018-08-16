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
    public partial class cadastro_consulta : System.Web.UI.Page
    {
        string id;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void limparInputs ()
        {

        }

        protected void btn_consulta_Click(object sender, EventArgs e)
        {
            id = "";
            string conString = WebConfigurationManager.ConnectionStrings["conexaoBD"].ConnectionString;
            // instanciar a classe conexaoBD
            conexaoBD acessoBD = new conexaoBD();
            acessoBD.Connection(conString);
            acessoBD.AbrirConexao();

            if (txtID.Text == "")
            {
                //TODO aparecer o alert falando pra preencher tudo
            }
            else
            {
                //TODO ver se dados estão formatados corretamente
                try
                {
                    SqlConnection myConnection;
                    myConnection = new SqlConnection(conString);
                    myConnection.Open();

                    conString = WebConfigurationManager.ConnectionStrings["conexaoBD"].ConnectionString;
                    acessoBD = new conexaoBD();
                    acessoBD.Connection(conString);
                    acessoBD.AbrirConexao();

                    SqlCommand sqlcmd = new SqlCommand();
                    myConnection = new SqlConnection(conString);
                    myConnection.Open();
                    sqlcmd.Connection = myConnection;

                    sqlcmd.CommandText = "SELECT TOP 1 1 FROM CONSULTA WHERE ID = @ID";
                    sqlcmd.Parameters.AddWithValue("@ID", txtID.Text);
                    SqlDataReader reader = sqlcmd.ExecuteReader();
                    int val = -1;
                    id = txtID.Text;
                    while (reader.Read())
                    {
                        val = Convert.ToInt32(reader.GetValue(0).ToString());
                    }
                    reader.Close();
                    
                    if (val != 1)
                    {
                        //TODO
                    }
                } catch (Exception er)
                {

                }
            }
            btnSubmit.Attributes["class"] = btnSubmit.Attributes["class"].Replace("disabled", "").Trim();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr", "javascript:M.toast({html: 'Consulta encontrada!'});", true);
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            // associando a string de conexao com o BD com o configurado no WebConfig
            if (id == "")
            {
                //TODO aparecer o alert falando pra preencher tudo
            }
            else
            {
                string conString = WebConfigurationManager.ConnectionStrings["conexaoBD"].ConnectionString;

                // instanciar a classe conexaoBD
                conexaoBD acessoBD = new conexaoBD();
                acessoBD.Connection(conString);
                acessoBD.AbrirConexao();

                //TODO ver se dados estão formatados corretamente
                try
                {
                    SqlConnection myConnection;
                    myConnection = new SqlConnection(conString);
                    myConnection.Open();

                    conString = WebConfigurationManager.ConnectionStrings["conexaoBD"].ConnectionString;
                    acessoBD = new conexaoBD();
                    acessoBD.Connection(conString);
                    acessoBD.AbrirConexao();

                    SqlCommand sqlCmd = new SqlCommand();
                    sqlCmd.Connection = myConnection;
                    if (sqlCmd.Parameters.Count == 0)
                    {
                        sqlCmd.CommandText = "UPDATE CONSULTA SET ANOTACOES = @ANOTACOES, CONCLUIDA = 1 WHERE ID = @ID";
                        sqlCmd.Parameters.AddWithValue("@ANOTACOES", txtAnotacao.Text);
                        sqlCmd.Parameters.AddWithValue("@ID", txtID.Text);
                    }

                    int iResultado = sqlCmd.ExecuteNonQuery();
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "myScript", "AnotherFunction();", true);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr", "javascript:M.toast({html: 'Consulta registrada com sucesso!'});", true);
                    limparInputs();
                }
                catch (Exception er)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr", "javascript:M.toast({html: 'Ocorreu um erro na operação!'});", true);
                }
                acessoBD.FecharConexao();
            }
        }
    }
}