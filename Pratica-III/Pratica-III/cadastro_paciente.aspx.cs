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
    public partial class cadastro_paciente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void limparInputs()
        {

        }

        static string Hash(string input)
        {
            var hash = (new System.Security.Cryptography.SHA1Managed()).ComputeHash(Encoding.UTF8.GetBytes(input));
            return string.Join("", hash.Select(b => b.ToString("x2")).ToArray());
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            try
            {
                // associando a string de conexao com o BD com o configurado no WebConfig
                String conString = WebConfigurationManager.ConnectionStrings["conexaoBD"].ConnectionString;

                // instanciar a classe conexaoBD
                conexaoBD acessoBD = new conexaoBD();
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
                    sqlcmd.CommandText = "SELECT TOP 1 1 FROM PACIENTE WHERE EMAIL = @EMAIL";
                    sqlcmd.Parameters.AddWithValue("@EMAIL", txtEmail.Text);
                    SqlDataReader reader = sqlcmd.ExecuteReader();
                    int val = -1;
                    reader.Read();
                    if (reader.HasRows)
                        val = Convert.ToInt32(reader.GetValue(0).ToString());
                    reader.Close();
                    if (val == 1)
                    {
                        throw new Exception("Paciente já cadastrado!");
                    }

                    //TODO ver se dados estão formatados corretamente
                    byte[] vetorImagem;
                    
                    myConnection = new SqlConnection(conString);
                    myConnection.Open();

                    string strArq = txtFoto.Text;

                    if (string.IsNullOrEmpty(strArq))
                        throw new Exception("Caminho de arquivo inválido!");

                    // transformar imagem em vetor de byte para colocar no BD
                    FileInfo arqImagem = new FileInfo(strArq);
                    long tamanhoArquivoImagem = arqImagem.Length;

                    // cria uma stream em memoria com a imagem
                    FileStream fs = new FileStream(strArq, FileMode.Open, FileAccess.Read, FileShare.Read);

                    vetorImagem = new byte[Convert.ToInt32(tamanhoArquivoImagem)];

                    int iByteRead = fs.Read(vetorImagem, 0, Convert.ToInt32(tamanhoArquivoImagem));
                    fs.Close();

                    SqlCommand sqlCmd = new SqlCommand();
                    sqlCmd.Connection = myConnection;

                    string senha;
                    senha = System.Web.Security.Membership.GeneratePassword(10, 0);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr", "javascript:console.log(\"" + senha + "\");", true);

                    //envia email com senha
                    {
                        String em = "pharmercypr3@gmail.com";
                        MailMessage mail = new MailMessage();
                        mail.To.Add(txtEmail.Text);
                        mail.From = new MailAddress(em, "PharMercy", System.Text.Encoding.UTF8);
                        mail.Subject = "Cadastro na clínica PharMercy";
                        mail.SubjectEncoding = System.Text.Encoding.UTF8;
                        mail.Body = "<h1>PharMercy</h1><p>Seu usuário é: <span style=\"color:#43a047\">" + txtEmail.Text + "</span></p><p>Sua senha é <span style=\"color:#43a047\">" + senha + "</span>.</p><p>Você pode alterá-la a qualquer momento no site.</p>";
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
                    }

                    if (sqlCmd.Parameters.Count == 0)
                    {
                        sqlCmd.CommandText = "INSERT INTO PACIENTE(NOME, ANIVERSARIO, EMAIL, CELULAR, TELEFONE_RESIDENCIAL, FOTO, SENHA) VALUES (UPPER(@NOME),@ANIVERSARIO,@EMAIL,@CELULAR,@TELEFONE_RESIDENCIAL, @FOTO, @SENHA)";

                        sqlCmd.Parameters.AddWithValue("@NOME", txtNome.Text);
                        sqlCmd.Parameters.AddWithValue("@EMAIL", txtEmail.Text);
                        sqlCmd.Parameters.AddWithValue("@CELULAR", txtTelefoneCel.Text);
                        sqlCmd.Parameters.AddWithValue("@TELEFONE_RESIDENCIAL", txtTelefoneRes.Text);
                        sqlCmd.Parameters.AddWithValue("@FOTO", vetorImagem);
                        sqlCmd.Parameters.AddWithValue("@ANIVERSARIO", txtNiver.Text);
                        sqlCmd.Parameters.AddWithValue("@SENHA", conexaoBD.Hash(senha));
                    }

                    sqlCmd.ExecuteNonQuery();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr", "javascript:M.toast({html: 'Paciente registrado com sucesso!'});", true);
                    limparInputs();
                    acessoBD.FecharConexao();
                }
            }
            catch (Exception er)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr", "javascript:M.toast({html: 'Erro: " + er.Message + "'});", true);
                limparInputs();
            }
        }
    }
}