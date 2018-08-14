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
    public partial class agendamento_consulta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void limparInputs ()
        {
            txtData.Text = "";
            txtEmailMedico.Text = "";
            txtEmailPaciente.Text = "";
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // associando a string de conexao com o BD com o configurado no WebConfig
            String conString = WebConfigurationManager.ConnectionStrings["conexaoBD"].ConnectionString;

            // instanciar a classe conexaoBD
            conexaoBD acessoBD = new conexaoBD();
            acessoBD.Connection(conString);
            acessoBD.AbrirConexao();

            // checar se o usuario digitou dados para o LOGIN e SENHA
            if (btnSubmit.Text == "" || txtData.Text == "" || txtEmailMedico.Text == "" || txtEmailPaciente.Text == "")
            {
                //aparecer o alert falando pra preencher tudo
            }
            else
            {
                //ver se dados estão formatados corretamente

                String sqlQuery = "insert into";
                int achouReg = acessoBD.ExecutaInsUpDel(sqlQuery);
                
                acessoBD.FecharConexao();
            }
        }
    }
}