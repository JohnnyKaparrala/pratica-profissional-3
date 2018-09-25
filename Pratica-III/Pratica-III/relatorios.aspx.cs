using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace Pratica_III
{
    public partial class relatorios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Chart1.Visible = false;
            Chart2.Visible = false;
            Chart3.Visible = false;
            Chart4.Visible = false;
        }

        protected void btnGraf_Click(object sender, EventArgs e)
        {
            try
            {
                switch (escolhaGraf.SelectedIndex)
                {
                    case 0:
                        throw new Exception("Escola uma opção!");
                    case 1:
                        Chart1.Visible = true;
                        break;
                    case 2:
                        Chart2.Visible = true;
                        break;
                    case 3:
                        Chart3.Visible = true;
                        break;
                    case 4:
                        Chart4.Visible = true;
                        break;
                }

            }
            catch (Exception er)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr", "javascript:M.toast({html: 'Erro: " + er.Message + "'});", true);
            }
        }
    }
}