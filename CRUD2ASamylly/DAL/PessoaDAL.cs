using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using CRUD2AEmylly.Model;
using System.Data;

namespace CRUD2AEmylly.DAL
{
    public class PessoaDAL : Conexao
    {
        MySqlCommand comando = null;

        //método para alterar
        public void Alterar(Pessoa pessoa)
        {
            try
            {
                AbrirConexao();
                comando = new MySqlCommand("UPDATE pessoa SET nome = @nome, cidade = @cidade, celular = @celular, " +
                    "dataa = @dataa, horario = @horario, quantAnel = @quantAnel, corAnel = @corAnel," +
                    "quantArg = @quantArg, corArg = @corArg, quantLinha = @quantLinha, corLinha = @corLinha, " +
                    "quantPin = @quantPin, quantTran = @quantTran, estilo = @estilo, valorTot = @valorTot, WHERE id = @id", conexao);

                comando.Parameters.AddWithValue("@nome", pessoa.Nome);
                comando.Parameters.AddWithValue("@cidade", pessoa.Cidade);
                comando.Parameters.AddWithValue("@celular", pessoa.Celular);
                comando.Parameters.AddWithValue("@dataa", DateTime.Parse(pessoa.Dataa).ToString("yyyy-MM-dd"));
                comando.Parameters.AddWithValue("@horario", DateTime.Parse(pessoa.Horario).ToString("t"));
                comando.Parameters.AddWithValue("@quantAnel", pessoa.QuantAnel);
                comando.Parameters.AddWithValue("@corAnel", pessoa.CorAnel);
                comando.Parameters.AddWithValue("@quantArg", pessoa.QuantArg);
                comando.Parameters.AddWithValue("@corArg", pessoa.CorAnel);
                comando.Parameters.AddWithValue("@quantLinha", pessoa.QuantLinha);
                comando.Parameters.AddWithValue("@corLinha", pessoa.CorLinha);
                comando.Parameters.AddWithValue("@quantPin", pessoa.QuantPin);
                comando.Parameters.AddWithValue("@quantTran", pessoa.QuantTran);
                comando.Parameters.AddWithValue("@estilo", pessoa.Estilo);
                comando.Parameters.AddWithValue("@valorTot", pessoa.ValorTot);

                comando.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                FecharConexao();
            }
        }

        //método para salvar
        public void Salvar(Pessoa pessoa)
        {
            try
            {
                AbrirConexao();
                comando = new MySqlCommand("INSERT INTO pessoa (nome, cidade, celular, " +
                    "dataa, horario, quantAnel, corAnel, quantArg, corArg, quantLinha, corLinha, quantPin," +
                    "quantTran, estilo, valorTot) VALUES (@nome," +
                    "@cidade, @celular, @dataa, @horario, @quantAnel, @corAnel, @quantArg, @corArg," +
                    "@quantLinha, @corLinha, @quantPin, @quantTran, @estilo, @valorTot)", conexao);

                comando.Parameters.AddWithValue("@nome", pessoa.Nome);
                comando.Parameters.AddWithValue("@cidade", pessoa.Cidade);
                comando.Parameters.AddWithValue("@celular", pessoa.Celular);
                comando.Parameters.AddWithValue("@dataa", DateTime.Parse(pessoa.Dataa).ToString("yyyy-MM-dd"));
                comando.Parameters.AddWithValue("@horario", DateTime.Parse(pessoa.Horario).ToString("t"));
                comando.Parameters.AddWithValue("@quantAnel", pessoa.QuantAnel);
                comando.Parameters.AddWithValue("@corAnel", pessoa.CorAnel);
                comando.Parameters.AddWithValue("@quantArg", pessoa.QuantArg);
                comando.Parameters.AddWithValue("@corArg", pessoa.CorAnel);
                comando.Parameters.AddWithValue("@quantLinha", pessoa.QuantLinha);
                comando.Parameters.AddWithValue("@corLinha", pessoa.CorLinha);
                comando.Parameters.AddWithValue("@quantPin", pessoa.QuantPin);
                comando.Parameters.AddWithValue("@quantTran", pessoa.QuantTran);
                comando.Parameters.AddWithValue("@estilo", pessoa.Estilo);
                comando.Parameters.AddWithValue("@valorTot", pessoa.ValorTot);

                comando.ExecuteNonQuery();

            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                FecharConexao();
            }
        }

        //metodo para listar
        public DataTable Listar()
        {
            try
            {
                AbrirConexao();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter();

                comando = new MySqlCommand("SELECT * FROM pessoa ORDER BY nome", conexao);
                da.SelectCommand = comando;
                da.Fill(dt);
                return dt;
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                FecharConexao();
            }
        }

    }    
}
