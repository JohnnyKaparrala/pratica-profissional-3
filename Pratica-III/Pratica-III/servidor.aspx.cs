using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using Pratica_III.App_Start;
using System.Text;
using System.Net.Mail;

namespace Pratica_III
{
    public partial class servidor : System.Web.UI.Page
    {
        Thread threadServ;
        protected void Page_Load(object sender, EventArgs e)
        {
            /*threadServ = new Thread(new ThreadStart(checar));
            threadServ.IsBackground = true;
            threadServ.Start();*/
            checar();
        }

        protected void checar ()
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
                string add;
                if (true)
                {
                    sqlCmd.CommandText = "select p.email, p.nome, m.email, m.nome, c.horario from PACIENTE p, MEDICO m, CONSULTA c where c.id_medico = m.id and c.id_paciente = p.id and c.horario >= DATEADD(d, 0, DATEDIFF(d, 0, GETDATE())) and c.horario <= (DATEADD(d, 0, DATEDIFF(d, 0, GETDATE())) + 2)";
                    SqlDataReader reader = sqlCmd.ExecuteReader();
                    add = "";
                    
                    while (reader.Read())
                    {
                        add += "<span>enviando email para " + reader.GetValue(0) + " e " + reader.GetValue(2) + " ...</span><br/>";
                        String em = "pharmercypr3@gmail.com";
                        MailMessage mail = new MailMessage();
                        mail.To.Add(reader.GetValue(0).ToString());
                        mail.From = new MailAddress(em, "PharMercy", System.Text.Encoding.UTF8);
                        mail.Subject = "Consulta na clínica PharMercy";
                        mail.SubjectEncoding = System.Text.Encoding.UTF8;
                        mail.Body = "<h1>PharMercy</h1><p>Olá " + reader.GetValue(1).ToString() + ", não se esqueça de sua consulta amanhã às " + reader.GetValue(4).ToString() + "</span></p>";
                        mail.BodyEncoding = System.Text.Encoding.UTF8;
                        mail.IsBodyHtml = true;
                        mail.Priority = MailPriority.High;

                        SmtpClient cliente = new SmtpClient();
                        cliente.UseDefaultCredentials = false;
                        cliente.Credentials = new System.Net.NetworkCredential(em, "clinicapr3");
                        cliente.Port = 587;
                        cliente.Host = "smtp.gmail.com";
                        cliente.EnableSsl = true;

                        try
                        {
                            cliente.Send(mail);
                            //foi, deu certo
                        }
                        catch (InvalidOperationException ex)
                        {
                            throw new Exception("Email incorreto! Verifique se tudo foi preenchido corretamente.");
                        }
                        catch (SmtpFailedRecipientsException ex)
                        {
                            throw new Exception("Email incorreto, não foi possível enviar a mensagem.");
                        }
                        catch (SmtpException ex)
                        {
                            throw new Exception("Não foi possível enviar o email! Verifique sua conexão.");
                        }

                        em = "pharmercypr3@gmail.com";
                        mail = new MailMessage();
                        mail.To.Add(reader.GetValue(2).ToString());
                        mail.From = new MailAddress(em, "PharMercy", System.Text.Encoding.UTF8);
                        mail.Subject = "Consulta na clínica PharMercy";
                        mail.SubjectEncoding = System.Text.Encoding.UTF8;
                        mail.Body = "<h1>PharMercy</h1><p>Olá " + reader.GetValue(3).ToString() + ", não se esqueça de sua consulta amanhã às " + reader.GetValue(4).ToString() + "</span></p>";
                        mail.BodyEncoding = System.Text.Encoding.UTF8;
                        mail.IsBodyHtml = true;
                        mail.Priority = MailPriority.High;

                        cliente = new SmtpClient();
                        cliente.UseDefaultCredentials = false;
                        cliente.Credentials = new System.Net.NetworkCredential(em, "clinicapr3");
                        cliente.Port = 587;
                        cliente.Host = "smtp.gmail.com";
                        cliente.EnableSsl = true;

                        try
                        {
                            cliente.Send(mail);
                            //foi, deu certo
                        }
                        catch (InvalidOperationException ex)
                        {
                            throw new Exception("Email incorreto! Verifique se tudo foi preenchido corretamente.");
                        }
                        catch (SmtpFailedRecipientsException ex)
                        {
                            throw new Exception("Email incorreto, não foi possível enviar a mensagem.");
                        }
                        catch (SmtpException ex)
                        {
                            throw new Exception("Não foi possível enviar o email! Verifique sua conexão.");
                        }
                    }
                    reader.Close();

                    add += "<span>resolvendo consultas nao concluidas</span><br/>";
                    sqlCmd.CommandText = "select id from CONSULTA where horario >= DATEADD(d,0, DATEDIFF(d,0, GETDATE()))-1 and horario <= (DATEADD(d,0,DATEDIFF(d,0, GETDATE()))) and concluida = 0";
                    reader = sqlCmd.ExecuteReader();

                    var list = new List<int>();
                    while (reader.Read())
                    {
                        list.Add(Convert.ToInt32(reader.GetValue(0)));
                    }
                    reader.Close();

                    int[] arr = list.ToArray();
                    for (int j = 0; j  < arr.Length; j++)
                    {
                        SqlCommand sqlCmd2 = new SqlCommand();
                        sqlCmd2.Connection = myConnection;

                        sqlCmd2.CommandText = "update consulta set concluida = -1 where id = @ID";
                        sqlCmd2.Parameters.AddWithValue("@ID", arr[j]);
                        sqlCmd2.ExecuteNonQuery();
                        add += "<span>consulta de id " + arr[j] + "resolvida</span><br/>";
                    }
                    reader.Close();
                    add += "<span>fim</span><br/>";
                }
                acessoBD.FecharConexao();

                ConsoleTxt.InnerHtml = add;
            }
            catch (Exception er)
            {
                ConsoleTxt.InnerHtml += "\n\nErro: " + er.Message;
            }
        }
    }
}
