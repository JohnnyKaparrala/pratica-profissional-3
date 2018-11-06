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
    public partial class avaliar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["id_aux"] = Request.QueryString["id"];
        }

        protected void limparInputs ()
        {
            rdAvalicacao.SelectedIndex = -1;
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            try
            {
                // associando a string de conexao com o BD com o configurado no WebConfig
                if (rdAvalicacao.SelectedIndex == -1)
                {
                    throw new Exception("Selecione uma carinha!");
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
                        sqlCmd.CommandText = "UPDATE CONSULTA SET AVALIACAO_PACIENTE = @AVALIACAO_PACIENTE, COMENTARIO_PACIENTE = @COMENTARIO_PACIENTE WHERE ID = @ID";
                        sqlCmd.Parameters.AddWithValue("@AVALIACAO_PACIENTE", rdAvalicacao.SelectedIndex);
                        sqlCmd.Parameters.AddWithValue("@COMENTARIO_PACIENTE", txtComentario.InnerText);
                        sqlCmd.Parameters.AddWithValue("@ID", Session["id_aux"]);
                    }

                    int iResultado = sqlCmd.ExecuteNonQuery();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr", "javascript:M.toast({html: 'Agradecemos pela avaliação!'});", true);
                    limparInputs();
                    acessoBD.FecharConexao();
                    Response.Redirect("consultas.aspx");
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