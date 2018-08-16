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

        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            // associando a string de conexao com o BD com o configurado no WebConfig
            String conString = WebConfigurationManager.ConnectionStrings["conexaoBD"].ConnectionString;

            // instanciar a classe conexaoBD
            conexaoBD acessoBD = new conexaoBD();
            acessoBD.Connection(conString);
            acessoBD.AbrirConexao();
            
            if (txtEsp.Text == "")
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

                    SqlCommand sqlCmd = new SqlCommand();
                    sqlCmd.Connection = myConnection;
                    if (sqlCmd.Parameters.Count == 0)
                    {
                        sqlCmd.CommandText = "INSERT INTO ESPECIALIDADE_MEDICO(NOME) VALUES (@NOME)";
                        
                        sqlCmd.Parameters.AddWithValue("@NOME", txtEsp.Text);
                    }

                    int iResultado = sqlCmd.ExecuteNonQuery();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr", "javascript:M.toast({html: 'Especialidade registrada com sucesso!'});", true);
                }
                catch (Exception er)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr", "javascript:M.toast({html: 'Ocorreu um erro durante a operação!'});", true);
                }
                acessoBD.FecharConexao();
            }
        }
    }
}