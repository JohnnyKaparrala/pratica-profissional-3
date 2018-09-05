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
                    throw new Exception("Preencha todos os campos.");
                }
                else
                {
                    //TODO ver se o email existe e mandar
                    //TODO ver se dados estão formatados corretamente
                    byte[] vetorImagem;

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
                    {//TODO inserir senha
                        sqlCmd.CommandText = "INSERT INTO PACIENTE(NOME, ANIVERSARIO, EMAIL, CELULAR, TELEFONE_RESIDENCIAL, FOTO) VALUES (@NOME,@ANIVERSARIO,@EMAIL,@CELULAR,@TELEFONE_RESIDENCIAL, @FOTO)";

                        sqlCmd.Parameters.AddWithValue("@NOME", txtNome.Text);
                        sqlCmd.Parameters.AddWithValue("@EMAIL", txtEmail.Text);
                        sqlCmd.Parameters.AddWithValue("@CELULAR", txtTelefoneCel.Text);
                        sqlCmd.Parameters.AddWithValue("@TELEFONE_RESIDENCIAL", txtTelefoneRes.Text);
                        sqlCmd.Parameters.AddWithValue("@FOTO", vetorImagem);
                        sqlCmd.Parameters.AddWithValue("@ANIVERSARIO", txtNiver.Text);
                    }

                    int iResultado = sqlCmd.ExecuteNonQuery();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr", "javascript:M.toast({html: 'Paciente registrado com sucesso!'});", true);
                    limparInputs();
                }
                acessoBD.FecharConexao();
            }
            catch (Exception er)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "scr", "javascript:M.toast({html: 'Erro: " + er.Message + "'});", true);
            }
        }
    }
}