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
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;

namespace Pratica_III
{
    public partial class cadastro_paciente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            // associando a string de conexao com o BD com o configurado no WebConfig
            String conString = WebConfigurationManager.ConnectionStrings["conexaoBD"].ConnectionString;

            // instanciar a classe conexaoBD
            conexaoBD acessoBD = new conexaoBD();
            acessoBD.Connection(conString);
            acessoBD.AbrirConexao();

            // checar se o usuario digitou dados para o LOGIN e SENHA
            if (txtEmail.Text == "" || txtNiver.Text == "" || txtNome.Text == "" || txtTelefoneCel.Text == "" || txtTelefoneRes.Text == "")
            {
                //aparecer o alert falando pra preencher tudo
            }
            else
            {
                //ver se dados estão formatados corretamente
                byte[] vetorImagem;
                try
                {
                    SqlConnection myConnection;
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

                    SqlCommand sqlCmd = new SqlCommand();
                    sqlCmd.Connection = myConnection;
                    if (sqlCmd.Parameters.Count == 0)
                    {
                        sqlCmd.CommandText = "INSERT INTO PACIENTE(NOME, ANIVERSARIO, EMAIL, CELULAR, TELEFONE_RESIDENCIAL, FOTO) VALUES (@NOME,convert(datetime,@ANIVERSARIO,103),@EMAIL,@CELULAR,@TELEFONE_RESIDENCIAL, @IMAGEM)";

                        sqlCmd.Parameters.Add("@NOME", System.Data.SqlDbType.VarChar, 50);
                        sqlCmd.Parameters.Add("@ANIVERSARO", System.Data.SqlDbType.VarChar, 10000);
                        sqlCmd.Parameters.Add("@EMAIL", System.Data.SqlDbType.VarChar, 50);
                        sqlCmd.Parameters.Add("@CELULAR", System.Data.SqlDbType.VarChar, 50);
                        sqlCmd.Parameters.Add("@TELEFONE_RESIDENCIAL", System.Data.SqlDbType.VarChar, 50);
                        sqlCmd.Parameters.Add("@FOTO", System.Data.SqlDbType.Image);
                    }

                    sqlCmd.Parameters["@NOME"].Value = txtNome.Text;
                    sqlCmd.Parameters["@ANIVERSARIO"].Value = txtNiver.Text;//todo erro aqui
                    sqlCmd.Parameters["@EMAIL"].Value = txtEmail.Text;
                    sqlCmd.Parameters["@CELULAR"].Value = txtTelefoneCel.Text;
                    sqlCmd.Parameters["@TELEFONE_RESIDENCIAL"].Value = txtTelefoneRes.Text;
                    sqlCmd.Parameters["@FOTO"].Value = vetorImagem;
                    int iResultado = sqlCmd.ExecuteNonQuery();


                }
                catch (Exception er)
                {
                    txtEmail.Text = er.Message;
                }
                acessoBD.FecharConexao();
            }
        }
    }
}