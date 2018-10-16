using Pratica_III.App_Start;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace Pratica_III
{
    public partial class relatorios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            chartChart.Visible = false;
        }        

        protected void escolhaGraf_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                String conString = WebConfigurationManager.ConnectionStrings["conexaoBD"].ConnectionString;
                
                SqlConnection myConnection;
                myConnection = new SqlConnection(conString);
                myConnection.Open();

                DataTable itens = new DataTable();
                SqlDataAdapter adapter;

                ddPesquisa.DataSource = itens;

                ddPesquisa.Visible = false;
                txtData.Visible = false;
                btnGerarGraf.Visible = true;

                //poderia fazer um switch case, mas com if é melhor

                //  consulta mensal por medico      consultas canceladas
                if (escolhaGraf.SelectedIndex == 1 || escolhaGraf.SelectedIndex == 4)
                {
                    adapter = new SqlDataAdapter("SELECT id,nome FROM MEDICO", myConnection);
                    adapter.Fill(itens);

                    ddPesquisa.DataTextField = "nome";
                    ddPesquisa.DataValueField = "id";

                    ddPesquisa.DataBind();
                    ddPesquisa.Items.Insert(0, new ListItem("Selecione","0"));
                    ddPesquisa.Items[0].Enabled = false;
                    ddPesquisa.Visible = true;
                }
                else
                if (escolhaGraf.SelectedIndex == 2) 
                {
                    txtData.Visible = true;
                }
                else //3
                {
                    btnGerarGraf.Visible = false;
                }

                myConnection.Close();
            }
            catch (Exception er)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr", "javascript:M.toast({html: 'Erro: " + er.Message + "'});", true);
            }

        }

        protected void btnGerarGraf_Click(object sender, EventArgs e)
        {
            try{ 
                String conString = WebConfigurationManager.ConnectionStrings["conexaoBD"].ConnectionString;

                DataTable table = new DataTable();
                SqlDataAdapter adapt = new SqlDataAdapter();

                SqlConnection myConnection;
                myConnection = new SqlConnection(conString);
                myConnection.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = myConnection;

                switch (escolhaGraf.SelectedIndex)
                {
                    case 1:
                        cmd.CommandText = "SELECT count(*) as quantidade, RIGHT(CONVERT(CHAR(10),horario,103),7) as data" +
                            " FROM CONSULTA WHERE id_medico = @id group by RIGHT(CONVERT(CHAR(10), horario, 103), 7)";
                        cmd.Parameters.Add("@id", SqlDbType.Int);
                        cmd.Parameters["@id"].Value = ddPesquisa.SelectedValue;

                        chartChart.Series[0].ChartType = SeriesChartType.Column;
                        chartChart.Series[0].XValueMember = "data";
                        chartChart.Series[0].YValueMembers = "quantidade";
                        break;
                    case 2:
                        cmd.CommandText = "select count(*) as quantidade, e.nome as especialidade from CONSULTA c, MEDICO m, ESPECIALIDADE_MEDICO e" +
                            " where c.id_medico = m.id and m.id_especialidade_medico = e.id and " +
                            "CONVERT(CHAR(10),C.horario,103) = '@DATA' group by e.nome";
                        cmd.Parameters.Add("@data", SqlDbType.VarChar);
                        cmd.Parameters["@data"].Value = txtData.Text;
                        
                        chartChart.Series[0].ChartType = SeriesChartType.Pie;
                        break;
                    case 3:
                        cmd.CommandText = "select count(distinct c.id_paciente) as quantidade, m.nome as medico	from CONSULTA c, MEDICO m " +
                            "where c.id_medico = m.id group by m.nome";

                        chartChart.Series[0].ChartType = SeriesChartType.Bar;
                        chartChart.Series[0].XValueMember = "medico";
                        chartChart.Series[0].YValueMembers = "quantidade";
                        break;
                    case 4:
                        cmd.CommandText = "select count(*) as quantidade, RIGHT(CONVERT(CHAR(10),horario,103),7) as mes " +
                            "from CONSULTA	where concluida = -1 and id_medico = @id	" +
                            "group by id_medico, RIGHT(CONVERT(CHAR(10),horario,103),7)";
                        cmd.Parameters.Add("@id", SqlDbType.Int);
                        cmd.Parameters["@id"].Value = ddPesquisa.SelectedValue;

                        chartChart.Series[0].ChartType = SeriesChartType.Column;
                        chartChart.Series[0].XValueMember = "mes";
                        chartChart.Series[0].YValueMembers = "quantidade";
                        break;
                }
                adapt.SelectCommand = cmd;
                adapt.Fill(table);
                
                chartChart.DataSource = table;
                chartChart.DataBind();
               
                
                myConnection.Close();

                chartChart.Visible = true;
            }catch(Exception er)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr", "javascript:M.toast({html: 'Erro: " + er.Message + "'});", true);
            }

        }

        protected void btnGraf_Click(object sender, EventArgs e)
        {
            try
            {
                if (escolhaGraf.SelectedIndex == 3)
                {
                    btnGerarGraf_Click(btnGerarGraf,EventArgs.Empty);
                }
            }
            catch (Exception er)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr", "javascript:M.toast({html: 'Erro: " + er.Message + "'});", true);
            }
        }
    }
}