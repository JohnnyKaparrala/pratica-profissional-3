using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.SqlClient;

[assembly: OwinStartup(typeof(Pratica_III.App_Start.conexaoBD))]

namespace Pratica_III.App_Start
{
    public class conexaoBD
    {
        private SqlConnection con;
        private String ConnectionString { get; set; }


        public void Configuration(IAppBuilder app)
        {
            this.ConnectionString = ConnectionString;
        }
        
        public void Connection() { }

        // Construtor: recebe a string de conexao
        public void Connection(String ConnectString)
        {
            this.ConnectionString = ConnectString;
        }

        // métodos de criação da conexao e acesso ao BD
        public void AbrirConexao()
        {
            if (string.IsNullOrEmpty(this.ConnectionString)) throw
                    new Exception("Não foi possível abrir a conexao com o BD - método Abrir!");

            if (con == null)
            {
                con = new SqlConnection();
                con.ConnectionString = this.ConnectionString;
            }
            con.Open();  // abrindo a conexao com o BD
        }

        public void FecharConexao()
        {
            con.Close();
        }

        // método usado para retornar uma dataset
        public IDataReader RetornaDados(String sql)
        {
            // verificando se o sql veio preenchido
            if (String.IsNullOrEmpty(sql)) throw
                  new Exception("A query de consulta veio vazia - RetornaDados()");

            // verificar se a conexao está fechada
            if ((con == null) || (con.State == ConnectionState.Closed))
                throw new Exception("A conexao com BD está fechada! RetornaDados()");

            // criando o comando de execução da consulta
            SqlCommand comando = new SqlCommand(sql, this.con);
            SqlDataReader dr_Dados = comando.ExecuteReader();
            dr_Dados.Read();
            return dr_Dados;
        }

        // método que somente faz a consulta e retorna a qtde de rows encontrada
        public int ExecutarConsulta(String sql)
        {
            // verificando se o sql veio preenchido
            if (String.IsNullOrEmpty(sql)) throw
                  new Exception("A query de consulta veio vazia - ExecutarConsulta()");

            // verificar se a conexao está fechada
            if ((con == null) || (con.State == ConnectionState.Closed))
                throw new Exception("A conexao com BD está fechada! ExecutarConsulta()");

            SqlCommand comando = new SqlCommand();
            comando.Connection = this.con;
            // rodar a consulta
            comando.CommandText = sql;
            try
            {
                /* o EXECUTESCALAR é usado para consultas e retorna 
                 * o qtde de rows
                   Sempre usara a PK da tabela, que é a 1o coluna 
                   da tabela */
                int quantidadeLinhas = (int)comando.ExecuteScalar();
                return quantidadeLinhas;
            }
            catch
            {
                return -1;
            }
        }

        // método usado para INSERT, UPDATE e DELETE
        public int ExecutaInsUpDel(String sql)
        {
            // verificando se o sql veio preenchido
            if (String.IsNullOrEmpty(sql)) throw
                  new Exception("A query de consulta veio vazia - ExecutaInsUpDel()");

            // verificar se a conexao está fechada
            if ((con == null) || (con.State == ConnectionState.Closed))
                throw new Exception("A conexao com BD está fechada! ExecutaInsUpDel()");

            SqlCommand comando = new SqlCommand();
            comando.Connection = this.con;
            comando.CommandText = sql;
            try
            {
                int retorno = (int)comando.ExecuteNonQuery();
                return retorno;
            }
            catch
            {
                // problema na execução do INSERT, UPDATE ou DELETE
                return 0;
            }
        }

        public static string Hash(string input)
        {
            var hash = (new System.Security.Cryptography.SHA1Managed()).ComputeHash(Encoding.UTF8.GetBytes(input));
            return string.Join("", hash.Select(b => b.ToString("x2")).ToArray());
        }
    }
}
