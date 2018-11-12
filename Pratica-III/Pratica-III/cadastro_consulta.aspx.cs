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
            id = Request["id"];
            lblId.InnerText = id;
            lblPac.InnerText = Request["pac"];
        }

        protected void limparInputs ()
        {
            txtAnotacao.Text = "";
            lblId.InnerText = "";
            lblPac.InnerText = "";
            Session["pac"] = null;
            Session["id"] = null;
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            try
            {
                // associando a string de conexao com o BD com o configurado no WebConfig
                if (txtAnotacao.Text == "")
                {
                    throw new Exception("Preencha todos os campos!");
                }
                else
                {
                    string conString = WebConfigurationManager.ConnectionStrings["conexaoBD"].ConnectionString;

                    // instanciar a classe conexaoBD
                    conexaoBD acessoBD = new conexaoBD();
                    acessoBD.Connection(conString);
                    acessoBD.AbrirConexao();

                    //TODO ver se dados estão formatados corretamente
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
                        sqlCmd.CommandText = "UPDATE CONSULTA SET ANOTACOES = UPPER(@ANOTACOES), CONCLUIDA = 1 WHERE ID = @ID";
                        sqlCmd.Parameters.AddWithValue("@ANOTACOES", txtAnotacao.Text);
                        sqlCmd.Parameters.AddWithValue("@ID", id);
                    }

                    int iResultado = sqlCmd.ExecuteNonQuery();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr", "javascript:M.toast({html: 'Consulta registrada com sucesso!'});", true);
                    limparInputs();
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
