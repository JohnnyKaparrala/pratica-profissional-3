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
using System.Net.Mail;

namespace Pratica_III
{
    public partial class cadastro_medico : System.Web.UI.Page
    {
        conexaoBD acessoBD;
        String conString;

        protected void limparInputs()
        {

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                conString = WebConfigurationManager.ConnectionStrings["conexaoBD"].ConnectionString;
                acessoBD = new conexaoBD();
                acessoBD.Connection(conString);
                acessoBD.AbrirConexao();

                SqlCommand sqlCmd = new SqlCommand();
                SqlConnection myConnection;
                myConnection = new SqlConnection(conString);
                myConnection.Open();
                sqlCmd.Connection = myConnection;

                sqlCmd.CommandText = "SELECT NOME FROM ESPECIALIDADE_MEDICO";
                SqlDataReader reader = sqlCmd.ExecuteReader();

                while (reader.Read())
                {
                    selEsp.Items.Insert(0, new ListItem(reader.GetValue(0).ToString()));
                }

                acessoBD.FecharConexao();
            }
            catch (Exception er)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr", "javascript:M.toast({html: 'Erro: " + er.Message + "'});", true);
            }
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            try
            {
                // associando a string de conexao com o BD com o configurado no WebConfig
                conString = WebConfigurationManager.ConnectionStrings["conexaoBD"].ConnectionString;

                // instanciar a classe conexaoBD
                acessoBD = new conexaoBD();
                acessoBD.Connection(conString);
                acessoBD.AbrirConexao();

                if (txtEmail.Text == "" || txtNiver.Text == "" || txtNome.Text == "" || txtTelefoneCel.Text == "" || txtTelefoneRes.Text == "")
                {
                    throw new Exception("Preencha todos os campos!");
                }
                else
                {
                    SqlConnection myConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["conexaoBD"].ConnectionString);
                    myConnection.Open();
                    conString = WebConfigurationManager.ConnectionStrings["conexaoBD"].ConnectionString;
                    acessoBD = new conexaoBD();
                    acessoBD.Connection(conString);
                    acessoBD.AbrirConexao();
                    SqlCommand sqlcmd = new SqlCommand();
                    myConnection = new SqlConnection(conString);
                    myConnection.Open();
                    sqlcmd.Connection = myConnection;
                    sqlcmd.CommandText = "SELECT TOP 1 1 FROM MEDICO WHERE EMAIL = @EMAIL";
                    sqlcmd.Parameters.AddWithValue("@EMAIL", txtEmail.Text);
                    SqlDataReader reader = sqlcmd.ExecuteReader();
                    int val = -1;
                    reader.Read();
                    val = Convert.ToInt32(reader.GetValue(0).ToString());
                    reader.Close();
                    if (val == 1)
                    {
                        throw new Exception("Médico já cadastrado!");
                    }

                    byte[] vetorImagem;
                    
                    myConnection = new SqlConnection(conString);
                    myConnection.Open();

                    string strArq = txtFoto.Text;

                    if (string.IsNullOrEmpty(strArq))
                        throw new Exception("a");

                    // transformar imagem em vetor de byte para colocar no BD
                    FileInfo arqImagem = new FileInfo(strArq);
                    long tamanhoArquivoImagem = arqImagem.Length;

                    // cria uma stream em memoria com a imagem
                    FileStream fs = new FileStream(strArq, FileMode.Open, FileAccess.Read, FileShare.Read);

                    vetorImagem = new byte[Convert.ToInt32(tamanhoArquivoImagem)];

                    int iByteRead = fs.Read(vetorImagem, 0, Convert.ToInt32(tamanhoArquivoImagem));
                    fs.Close();

                    sqlcmd = new SqlCommand();
                    myConnection = new SqlConnection(conString);
                    myConnection.Open();
                    sqlcmd.Connection = myConnection;

                    sqlcmd.CommandText = "SELECT ID FROM ESPECIALIDADE_MEDICO WHERE NOME = @NOME_ESPEC";
                    sqlcmd.Parameters.AddWithValue("@NOME_ESPEC", selEsp.Text);
                    reader = sqlcmd.ExecuteReader();
                    int esp = -1;

                    while (reader.Read())
                    {
                        esp = Convert.ToInt32(reader.GetValue(0).ToString());
                    }

                    if (esp == -1)
                    {

                    }
                    reader.Close();

                    //gera senha aleatória
                    string senha;
                    senha = System.Web.Security.Membership.GeneratePassword(10, 0);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr", "javascript:console.log(\"" + senha + "\");", true);

                    //envia email com senha
                    {
                        String em = "bellydogclinica@gmail.com";
                        MailMessage mail = new MailMessage();
                        mail.To.Add(txtEmail.Text);
                        mail.From = new MailAddress(em, "Clínica Belly", System.Text.Encoding.UTF8);
                        mail.Subject = "Seu Cadastro na Clínica Belly!";
                        mail.SubjectEncoding = System.Text.Encoding.UTF8;
                        mail.Body = "Seu usuário é: " + txtEmail.Text + "\nSua senha é " + senha;
                        mail.BodyEncoding = System.Text.Encoding.UTF8;
                        mail.IsBodyHtml = true;
                        mail.Priority = MailPriority.High;

                        SmtpClient cliente = new SmtpClient();
                        cliente.UseDefaultCredentials = false;
                        cliente.Credentials = new System.Net.NetworkCredential(em, "bellypr3");
                        cliente.Port = 587;
                        cliente.Host = "smtp.gmail.com";
                        cliente.EnableSsl = true;


                        try
                        {
                            cliente.Send(mail);
                            //foi, deu certo
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr", "javascript:M.toast({html: Email Enviado com Sucesso!});", true);
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

                    SqlCommand sqlCmd = new SqlCommand();
                    sqlCmd.Connection = myConnection;
                    if (sqlCmd.Parameters.Count == 0)
                    {
                        sqlCmd.CommandText = "INSERT INTO MEDICO(NOME, ANIVERSARIO, EMAIL, CELULAR, TELEFONE_RESIDENCIAL, FOTO, ID_ESPECIALIDADE_MEDICO) VALUES (@NOME,@ANIVERSARIO,@EMAIL,@CELULAR,@TELEFONE_RESIDENCIAL,@FOTO,@ID_ESPECIALIDADE_MEDICO)";

                        sqlCmd.Parameters.AddWithValue("@NOME", txtNome.Text);
                        sqlCmd.Parameters.AddWithValue("@EMAIL", txtEmail.Text);
                        sqlCmd.Parameters.AddWithValue("@CELULAR", txtTelefoneCel.Text);
                        sqlCmd.Parameters.AddWithValue("@TELEFONE_RESIDENCIAL", txtTelefoneRes.Text);
                        sqlCmd.Parameters.AddWithValue("@FOTO", vetorImagem);
                        sqlCmd.Parameters.AddWithValue("@ANIVERSARIO", txtNiver.Text);
                        sqlCmd.Parameters.AddWithValue("@ID_ESPECIALIDADE_MEDICO", esp);
                    }

                    int iResultado = sqlCmd.ExecuteNonQuery();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr", "javascript:M.toast({html: Médico registrado com sucesso!'});", true);
                    limparInputs();
                    acessoBD.FecharConexao();
                }
            }
            catch (Exception er)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr", "javascript:M.toast({html: 'Erro: " + er.Message + "'});", true);
            }
        }
    }
}