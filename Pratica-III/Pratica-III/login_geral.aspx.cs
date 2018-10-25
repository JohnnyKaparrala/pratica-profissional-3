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
    public partial class cadastro : System.Web.UI.Page
    {   
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtEmail.Text) || String.IsNullOrEmpty(txtSenha.Text))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr", "javascript:M.toast({html: 'Preencha os dados corretamente'});", true);
                    return;
                }

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
                    switch (cargo.SelectedIndex)
                    {
                        case 1://adm
                            {
                                //começa verificando se é secretária
                                sqlcmd.CommandText = "SELECT ID FROM ADM WHERE NOME = @NOME AND SENHA = @SENHA";
                                sqlcmd.Parameters.AddWithValue("@NOME", txtEmail.Text);
                                sqlcmd.Parameters.AddWithValue("@SENHA", txtSenha.Text);
                                SqlDataReader reader = sqlcmd.ExecuteReader();
                                int val = -1;
                                reader.Read();
                                val = Convert.ToInt32(reader.GetValue(0).ToString());
                                Session["idquem"] = reader[0];
                                reader.Close();
                            }
                            break;

                        case 2://medc
                            {
                                sqlcmd.CommandText = "SELECT ID FROM MEDICO WHERE EMAIL = @NOME AND SENHA = @SENHA";
                                sqlcmd.Parameters.AddWithValue("@NOME", txtEmail.Text);
                                sqlcmd.Parameters.AddWithValue("@SENHA", conexaoBD.Hash(txtSenha.Text));
                                SqlDataReader reader = sqlcmd.ExecuteReader();
                                int val = -1;
                                reader.Read();
                                val = Convert.ToInt32(reader.GetValue(0).ToString());
                                Session["idquem"] = reader[0];
                                reader.Close();
                            }
                            break;

                        case 3://paciente
                            {
                                sqlcmd.CommandText = "SELECT ID FROM PACIENTE WHERE EMAIL = @NOME AND SENHA = @SENHA";
                                sqlcmd.Parameters.AddWithValue("@NOME", txtEmail.Text);
                                sqlcmd.Parameters.AddWithValue("@SENHA", conexaoBD.Hash(txtSenha.Text));
                                SqlDataReader reader = sqlcmd.ExecuteReader();
                                int val = -1;
                                reader.Read();
                                val = Convert.ToInt32(reader.GetValue(0).ToString());
                                Session["idquem"] = reader[0];
                                reader.Close();
                            }
                            break;

                        default:
                            {
                                throw new Exception("Index inválido.");
                            }
                            break;
                    }
                } catch (InvalidOperationException er)
                {
                    throw new Exception("Cadastro inválido!");
                }
                Session["cargo"] = cargo.SelectedIndex - 1;
                Session["quem"] = txtEmail.Text;
                /*
                 0: secretaria
                 1: medico
                 2: paciente
                */
                Session["wel"] = true;
                Response.Redirect("index.aspx");
            }
            catch (Exception er)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr", "javascript:M.toast({html: 'Erro: " + er.Message + "'});", true);
            }
        }
    }
}