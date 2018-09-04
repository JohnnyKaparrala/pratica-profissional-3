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

            if(String.IsNullOrEmpty(txtEmail.Text) || String.IsNullOrEmpty(txtSenha.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr", "javascript:M.toast({html: 'Preencha os dados corretamente'});", true);
                return;
            }

            String conString = WebConfigurationManager.ConnectionStrings["conexaoBD"].ConnectionString;
            conexaoBD acessoBD = new conexaoBD();
            acessoBD.Connection(conString);
            acessoBD.AbrirConexao();

            String senha = Hash(txtSenha.Text);
            String sql;
            int res;

            //começa verificando se é secretária
            sql = String.Format("SELECT SENHA FROM ADM WHERE NOME = '{0}' AND SENHA = '{1}'",txtEmail.Text, senha);
            res = acessoBD.ExecutarConsulta(sql);
            if (res > 0) //tem cadastro
            {
                Session["cargo"] = 0;
                Response.Redirect("index.aspx");
                return;
            }

            //verificar se é médico
            sql = String.Format("SELECT SENHA FROM MEDICO WHERE EMAIL = '{0}' AND SENHA = '{1}'", txtEmail.Text, senha);
            res = acessoBD.ExecutarConsulta(sql);
            if (res > 0) //tem cadastro
            {
                Session["cargo"] = 1;
                Response.Redirect("index.aspx");
                return;
            }

            //verificar se é paciente
            sql = String.Format("SELECT SENHA FROM PACIENTE WHERE EMAIL = '{0}' AND SENHA = '{1}'", txtEmail.Text, senha);
            res = acessoBD.ExecutarConsulta(sql);
            if (res > 0) //tem cadastro
            {
                Session["cargo"] = 2;
                Response.Redirect("index.aspx");
                return;
            }

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr", "javascript:M.toast({html: 'Você não possui cadastro'});", true);
        }

        static string Hash(string input)
        {
            var hash = (new SHA1Managed()).ComputeHash(Encoding.UTF8.GetBytes(input));
            return string.Join("", hash.Select(b => b.ToString("x2")).ToArray());
        }
    }
}