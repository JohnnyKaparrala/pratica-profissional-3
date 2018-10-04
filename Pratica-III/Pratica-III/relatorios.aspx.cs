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

        protected void btnGraf_Click(object sender, EventArgs e)
        {
            try
            {
                

            }
            catch (Exception er)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr", "javascript:M.toast({html: 'Erro: " + er.Message + "'});", true);
            }
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

                //poderia fazer um switch case, mas com if é melhor

                //  consulta mensal por medico      consultas canceladas
                if (escolhaGraf.SelectedIndex == 1 || escolhaGraf.SelectedIndex == 4)
                {
                    adapter = new SqlDataAdapter("SELECT id,nome FROM MEDICO", myConnection);
                    adapter.Fill(itens);

                    ddPesquisa.DataTextField = "nome";
                    ddPesquisa.DataValueField = "id";

                    ddPesquisa.DataBind();
                    //ddPesquisa.Items.Insert(0, new ListItem("Selecione","0"));
                    ddPesquisa.Visible = true;
                }
                else
                if (escolhaGraf.SelectedIndex == 2) 
                {
                    txtData.Visible = true;
                }

                myConnection.Close();
            }
            catch (Exception er)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr", "javascript:M.toast({html: 'Erro: " + er.Message + "'});", true);
            }

        }
    }
}