using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using Pratica_III.App_Start;
using System.Text;

namespace Pratica_III
{
    public partial class mudar_senha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void limparCampos ()
        {
            txtSenha_antiga.Text = "";
            txtSenha_nova.Text = "";
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection myConnection;
                myConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["conexaoBD"].ConnectionString);
                myConnection.Open();
                String conString = WebConfigurationManager.ConnectionStrings["conexaoBD"].ConnectionString;
                conexaoBD acessoBD = new conexaoBD();
                acessoBD.Connection(conString);
                acessoBD.AbrirConexao();
                SqlCommand sqlcmd = new SqlCommand();
                myConnection = new SqlConnection(conString);
                myConnection.Open();
                sqlcmd.Connection = myConnection;

                try
                {
                    switch (Session["cargo"])
                    {
                        case 0:
                            {
                                sqlcmd.CommandText = "UPDATE ADM SET SENHA = @SENHA_NOVA WHERE SENHA = @SENHA_ANTIGA AND NOME = @NOME";
                                sqlcmd.Parameters.AddWithValue("@SENHA_NOVA", txtSenha_nova.Text);
                                sqlcmd.Parameters.AddWithValue("@SENHA_ANTIGA", txtSenha_antiga.Text);
                                sqlcmd.Parameters.AddWithValue("@NOME", Session["quem"]);
                                sqlcmd.ExecuteNonQuery();
                            }
                            break;

                        case 1:
                            {
                                sqlcmd.CommandText = "UPDATE MEDICO SET SENHA = @SENHA_NOVA WHERE SENHA = @SENHA_ANTIGA AND EMAIL = @EMAIL";
                                sqlcmd.Parameters.AddWithValue("@SENHA_NOVA", txtSenha_nova.Text);
                                sqlcmd.Parameters.AddWithValue("@SENHA_ANTIGA", txtSenha_antiga.Text);
                                sqlcmd.Parameters.AddWithValue("@EMAIL", Session["quem"]);
                                sqlcmd.ExecuteNonQuery();
                            }
                            break;

                        case 2:
                            {
                                sqlcmd.CommandText = "UPDATE PACIENTE SET SENHA = @SENHA_NOVA WHERE SENHA = @SENHA_ANTIGA AND EMAIL = @EMAIL";
                                sqlcmd.Parameters.AddWithValue("@SENHA_NOVA", txtSenha_nova.Text);
                                sqlcmd.Parameters.AddWithValue("@SENHA_ANTIGA", txtSenha_antiga.Text);
                                sqlcmd.Parameters.AddWithValue("@EMAIL", Session["quem"]);
                                sqlcmd.ExecuteNonQuery();
                            }
                            break;

                        default:
                            {
                                
                            }
                            break;
                    }
                } catch (Exception er)
                {
                    throw new Exception("Senha inválida.");
                }
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr", "javascript:M.toast({html: 'Senha alterada com sucesso!'});", true);
            }
            catch (Exception er)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr", "javascript:M.toast({html: 'Erro: " + er.Message + "'});", true);
            }
            limparCampos();
        }
    }
}