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

        protected void limparInputs()
        {
            txtData.Text = "";
            txtEmailMedico.Text = "";
            txtEmailPaciente.Text = "";
        }

        protected string prox_horario(string hor)
        {
            DateTime d1 = DateTime.Parse(hor);
            DateTime d2;
            d2 = DateTime.Parse("00:30:00");
            DateTime d3 = d1.Add(d2.TimeOfDay);
            return d3.TimeOfDay.ToString();
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            // associando a string de conexao com o BD com o configurado no WebConfig
            string conString = WebConfigurationManager.ConnectionStrings["conexaoBD"].ConnectionString;

            // instanciar a classe conexaoBD
            conexaoBD acessoBD = new conexaoBD();
            acessoBD.Connection(conString);
            acessoBD.AbrirConexao();
            try
            {
                if (txtEmailMedico.Text == "" || txtEmailPaciente.Text == "" || txtData.Text == "" || txtDuracao.Text == "")
                {
                    //TODO aparecer o alert falando pra preencher tudo
                    throw new Exception("Preencha todos os campos");
                }
                else
                {
                    //TODO ver se dados estão formatados corretamente
                    byte[] vetorImagem;

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
                        throw new Exception("Paciente não encontrado.");
                    }
                    if (m_id == -1)
                    {
                        throw new Exception("Médico não encontrado.");
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

                    string horario = txtData.Text + " " + txtHor.Text;

                    sqlcmd.CommandText = "SELECT HORARIO FROM CONSULTA WHERE ID_MEDICO = 1 AND HORARIO BETWEEN (@DIA) AND (@DIA_SEGUINTE)";
                    sqlcmd.Parameters.AddWithValue("@DIA", txtData.Text + " 00:00:00.000");
                    sqlcmd.Parameters.AddWithValue("@DIA_SEGUINTE", txtData.Text + " 23:59:59.999");
                    sqlcmd.Parameters.AddWithValue("@HORARIO", horario + ".000");
                    sqlcmd.Parameters.AddWithValue("@ID_MED", m_id);
                    reader = sqlcmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string horario_autal = reader.GetValue(0).ToString().Substring((reader.GetValue(0).ToString()).Length - 8);
                        if (dur == 1)
                        {
                            if ((prox_horario(txtHor.Text + ":00") == horario_autal))
                                throw new Exception("Médico já está ocupado neste horário.");
                        }
                        else
                        if (txtHor.Text + ":00" == horario_autal)
                        {
                            throw new Exception("Médico já está ocupado neste horário.");
                        }
                    }
                    reader.Close();

                    if (dur == 1 && (txtHor.Text == "11:30" || txtHor.Text == "16:30"))
                    {
                        throw new Exception("A duração é muito grande para o horário escolhido");
                    }

                    SqlCommand sqlCmd = new SqlCommand();
                    sqlCmd.Connection = myConnection;
                    if (sqlCmd.Parameters.Count == 0)
                    {
                        sqlCmd.CommandText = "INSERT INTO CONSULTA(HORARIO, ID_PACIENTE, ID_MEDICO, CONCLUIDA, ANOTACOES, DURACAO) VALUES (@HORARIO,@ID_PACIENTE,@ID_MEDICO,0, NULL, @DURACAO)";

                        sqlCmd.Parameters.AddWithValue("@HORARIO", horario);
                        sqlCmd.Parameters.AddWithValue("@ID_PACIENTE", p_id);
                        sqlCmd.Parameters.AddWithValue("@ID_MEDICO", m_id);
                        sqlCmd.Parameters.AddWithValue("@DURACAO", dur);
                    }

                    int iResultado = sqlCmd.ExecuteNonQuery();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr", "javascript:M.toast({html: 'Consulta agendada com sucesso!'});", true);
                }
            }
            catch (Exception er)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr", "javascript:M.toast({html: 'Erro: " + er.Message + "'});", true);
            }
                limparInputs();
                acessoBD.FecharConexao();
            }
        }
    }