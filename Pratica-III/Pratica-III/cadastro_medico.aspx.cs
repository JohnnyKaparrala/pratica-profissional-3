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
    public partial class cadastro_medico : System.Web.UI.Page
    {
        conexaoBD acessoBD;
        String conString;

        protected void limparInputs ()
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

                    SqlCommand sqlcmd = new SqlCommand();
                    myConnection = new SqlConnection(conString);
                    myConnection.Open();
                    sqlcmd.Connection = myConnection;

                    sqlcmd.CommandText = "SELECT ID FROM ESPECIALIDADE_MEDICO WHERE NOME = @NOME_ESPEC";
                    sqlcmd.Parameters.AddWithValue("@NOME_ESPEC", selEsp.Text);
                    SqlDataReader reader = sqlcmd.ExecuteReader();
                    int esp = -1;

                    while (reader.Read())
                    {
                        esp = Convert.ToInt32(reader.GetValue(0).ToString());
                    }

                    if (esp == -1)
                    {

                    }
                    reader.Close();

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