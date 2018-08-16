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

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            // associando a string de conexao com o BD com o configurado no WebConfig
            string conString = WebConfigurationManager.ConnectionStrings["conexaoBD"].ConnectionString;

            // instanciar a classe conexaoBD
            conexaoBD acessoBD = new conexaoBD();
            acessoBD.Connection(conString);
            acessoBD.AbrirConexao();

            if (txtEmailMedico.Text == "" || txtEmailPaciente.Text == "" || txtData.Text == "" || txtDuracao.Text == "")
            {
                //TODO aparecer o alert falando pra preencher tudo
            }
            else
            {
                //TODO ver se dados estão formatados corretamente
                byte[] vetorImagem;
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

                    sqlcmd.CommandText = "SELECT P.ID, M.ID FROM PACIENTE P, MEDICO M WHERE P.EMAIL = @P_EMAIL AND M.EMAIL = @M_EMAIL";
                    sqlcmd.Parameters.AddWithValue("@P_EMAIL", txtEmailPaciente.Text);
                    sqlcmd.Parameters.AddWithValue("@M_EMAIL", txtEmailMedico.Text);
                    SqlDataReader reader = sqlcmd.ExecuteReader();
                    int p_id = -1;
                    int m_id = -1;

                    while (reader.Read())
                    {
                        p_id = Convert.ToInt32(reader.GetValue(0).ToString());
                        m_id = Convert.ToInt32(reader.GetValue(1).ToString());
                    }
                    reader.Close();

                    if (p_id == -1)
                    {

                    }
                    if (m_id == -1)
                    {

                    }
                    int dur = -1;
                    switch (txtDuracao.Text)
                    {
                        case "30 min":
                            dur = 0;
                            break;

                        case "60 min":
                            dur = 1;
                            break;

                        default:
                            throw new Exception("");//TODO
                    }

                    SqlCommand sqlCmd = new SqlCommand();
                    sqlCmd.Connection = myConnection;
                    if (sqlCmd.Parameters.Count == 0)
                    {
                        sqlCmd.CommandText = "INSERT INTO CONSULTA(HORARIO, ID_PACIENTE, ID_MEDICO, CONCLUIDA, ANOTACOES, DURACAO) VALUES (@HORARIO,@ID_PACIENTE,@ID_MEDICO,0, NULL, @DURACAO)";

                        sqlCmd.Parameters.AddWithValue("@HORARIO", txtData.Text);
                        sqlCmd.Parameters.AddWithValue("@ID_PACIENTE", p_id);
                        sqlCmd.Parameters.AddWithValue("@ID_MEDICO", m_id);
                        sqlCmd.Parameters.AddWithValue("@DURACAO", dur);
                    }

                    int iResultado = sqlCmd.ExecuteNonQuery();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr", "javascript:M.toast({html: 'Consulta agendada com sucesso!'});", true);
                    limparInputs();
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