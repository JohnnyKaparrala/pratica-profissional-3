using Pratica_III.App_Start;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pratica_III
{
    public partial class remarcar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
            DateTime data = DateTime.Now;
            for (int m = 0, h = 9; h < 17; m += 30)
            {
                if (m == 60)
                {
                    m = 0;
                    h++;
                }
                if (h > data.Hour && h != 13 && h != 12)
                {
                    txtHor.Items.Add(h.ToString().PadLeft(2, '0') + ":" + m.ToString().PadLeft(2, '0'));
                }
            }
        }

        protected void btnRemarcar_Click(object sender, EventArgs e)
        {
            try
            {
                String conString = WebConfigurationManager.ConnectionStrings["conexaoBD"].ConnectionString;
                conexaoBD acessoBD = new conexaoBD();
                acessoBD.Connection(conString);
                acessoBD.AbrirConexao();
                
                SqlConnection myConnection;
                myConnection = new SqlConnection(conString);
                myConnection.Open();

                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = myConnection;

                string horario = txtData.Text + " " + txtHor.Text;

                sqlCmd.CommandText = "update CONSULTA set horario = @hora, concluida = 0 where id = @id";
                sqlCmd.Parameters.AddWithValue("@hora", horario);
                sqlCmd.Parameters.AddWithValue("@id"  , Request.QueryString["id"]);

                sqlCmd.ExecuteNonQuery();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr", "javascript:M.toast({html: 'Consulta Remarcada com Sucesso!'});", true);
                acessoBD.FecharConexao();
                myConnection.Close();
            }
            catch (Exception er)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr", "javascript:M.toast({html: 'Erro: " + er.Message + "'});", true);
            }
        }
    }
}