﻿using System;
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
    public partial class consultas_medico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                conexaoBD acessoBD;
                String conString;

                conString = WebConfigurationManager.ConnectionStrings["conexaoBD"].ConnectionString;
                acessoBD = new conexaoBD();
                acessoBD.Connection(conString);
                acessoBD.AbrirConexao();

                SqlCommand sqlCmd = new SqlCommand();
                SqlConnection myConnection;
                myConnection = new SqlConnection(conString);
                myConnection.Open();
                sqlCmd.Connection = myConnection;
                
                if (ddDura.SelectedValue == "99")
                {
                    sqlCmd.CommandText = "SELECT DISTINCT C.ID, C.HORARIO, P.NOME, C.CONCLUIDA FROM CONSULTA C, PACIENTE P, MEDICO M WHERE P.ID = C.ID_PACIENTE AND C.ID_MEDICO = (SELECT ID FROM MEDICO WHERE EMAIL = @EMAIL) AND C.horario > GETDATE() ORDER BY ID DESC";
                }
                else
                {
                    sqlCmd.CommandText = "SELECT DISTINCT C.ID, C.HORARIO, P.NOME, C.CONCLUIDA FROM CONSULTA C, PACIENTE P, MEDICO M WHERE P.ID = C.ID_PACIENTE AND C.ID_MEDICO = (SELECT ID FROM MEDICO WHERE EMAIL = @EMAIL) AND C.horario between GETDATE() and @data ORDER BY ID DESC";
                    DateTime hj = DateTime.Now;
                    sqlCmd.Parameters.AddWithValue("@data", hj.AddDays(Convert.ToDouble(ddDura.SelectedValue)).ToString("dd-M-yyyy"));
                }
                sqlCmd.Parameters.AddWithValue("@EMAIL", Session["quem"]);
                SqlDataReader reader = sqlCmd.ExecuteReader();

                tbBody.InnerHtml = "";

                while (reader.Read())
                {
                    string val_conc = "<span class=\"red-text\">EXPIRADA</span>";

                    switch (Convert.ToInt16(reader.GetValue(3).ToString()))
                    {
                        case 1:
                            {
                                val_conc = "<span class=\"grey-text\">CONCLUÍDA</span>";
                            }
                            break;

                        case 0:
                            {
                                val_conc = $"<a href=\"cadastro_consulta.aspx?pac={reader.GetValue(2).ToString()}&id={reader.GetValue(0).ToString()}\" class=\"waves-effect waves-light btn-small green darken-1\">CONCLUIR</a>";
                            }
                            break;
                    }
                    
                    tbBody.InnerHtml += "<tr><td>" + reader.GetValue(0).ToString() + "</td><td>" + ((DateTime)reader.GetValue(1)).ToString("dd'/'MM'/'yyyy") + "</td><td>" + ((DateTime)reader.GetValue(1)).ToString("hh: mm") + " - " + ((DateTime)reader.GetValue(1)).ToString("hh: mm") + "</td><td>" + reader.GetValue(2).ToString() + "</td><td>" + val_conc + "</td><td>";
                }
            }
            catch (Exception er)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr", "javascript:M.toast({html: Ocorreu um erro durante a operação!'});", true);
            }
        }
    }
}