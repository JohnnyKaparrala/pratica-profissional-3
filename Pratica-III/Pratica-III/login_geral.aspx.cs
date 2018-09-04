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
using System.Security.Cryptography;
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

                String sql;
                int res;

                //começa verificando se é secretária
                sqlcmd.CommandText = "SELECT TOP 1 1 FROM ADM WHERE NOME = @NOME AND SENHA = @SENHA";
                sqlcmd.Parameters.AddWithValue("@NOME", txtEmail.Text);
                sqlcmd.Parameters.AddWithValue("@SENHA", txtSenha.Text);
                SqlDataReader reader = sqlcmd.ExecuteReader();
                int val = -1;
                reader.Read();
                val = Convert.ToInt32(reader.GetValue(0).ToString());
                reader.Close();

                if (val == 1) //tem cadastro
                {
                    Session["cargo"] = 0;
                    Session["wel"] = true;
                    Response.Redirect("index.aspx");
                }
                else
                {
                    throw new Exception("Cadastro inválido.");
                }

                String senha = Hash(txtSenha.Text);//criptografa a senha
                /*
                //verificar se é médico
                sql = String.Format("SELECT SENHA FROM MEDICO WHERE EMAIL = '{0}' AND SENHA = '{1}'", txtEmail.Text, senha);
                res = acessoBD.ExecutarConsulta(sql);
                if (res > 0) //tem cadastro
                {
                    Session["cargo"] = 1;
                    Response.Redirect("index.aspx");
                }

                //verificar se é paciente
                sql = String.Format("SELECT SENHA FROM PACIENTE WHERE EMAIL = '{0}' AND SENHA = '{1}'", txtEmail.Text, senha);
                res = acessoBD.ExecutarConsulta(sql);
                if (res > 0) //tem cadastro
                {
                    Session["cargo"] = 2;
                    Response.Redirect("index.aspx");
                }
            */
            } catch (Exception er)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr", "javascript:M.toast({html: 'Erro: " + er.Message + "'});", true);
            }
        }

        /*
         0: secretaria
         1: medico
         2: paciente
        */

        static string Hash(string input)
        {
            var hash = (new SHA1Managed()).ComputeHash(Encoding.UTF8.GetBytes(input));
            return string.Join("", hash.Select(b => b.ToString("x2")).ToArray());
        }
    }
}