using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using CRUD2AEmylly.Model;
using System.Data;
using System.Data.SqlTypes;

namespace CRUD2AEmylly.DAL
{
    public class PessoaDAL : Conexao
    {
        MySqlCommand comando = null;

        //método para excluir
        public void Excluir(Pessoa cliente)
        {
            try
            {
                AbrirConexao();
                comando = new MySqlCommand("DELETE FROM cliente WHERE id = @id", conexao);
                comando.Parameters.AddWithValue("@id", cliente.Id);

                comando.ExecuteNonQuery();

            }
            catch (Exception erro)
            {

                throw erro;
            }
        }

        //método para alterar
        public void Alterar(Pessoa cliente)
        {
            try
            {
                AbrirConexao();
                comando = new MySqlCommand("UPDATE cliente SET nome = @nome, cidade = @cidade, celular = @celular, " +
                    "dataa = @dataa, horario = @horario, quantAnel = @quantAnel, corAnel = @corAnel," +
                    "quantArg = @quantArg, corArg = @corArg, quantLinha = @quantLinha, corLinha = @corLinha, " +
                    "quantPin = @quantPin, quantTran = @quantTran, estilo = @estilo, valorTot = @valorTot, WHERE id = @id", conexao);

                comando.Parameters.AddWithValue("@nome", cliente.Nome);
                comando.Parameters.AddWithValue("@cidade", cliente.Cidade);
                comando.Parameters.AddWithValue("@celular", cliente.Celular);
                comando.Parameters.AddWithValue("@dataa", DateTime.Parse(cliente.Dataa).ToString("yyyy-MM-dd"));
                comando.Parameters.AddWithValue("@horario", DateTime.Parse(cliente.Horario).ToString("HH:mm"));
                comando.Parameters.AddWithValue("@quantAnel", cliente.QuantAnel);
                comando.Parameters.AddWithValue("@corAnel", cliente.CorAnel);
                comando.Parameters.AddWithValue("@quantArg", cliente.QuantArg);
                comando.Parameters.AddWithValue("@corArg", cliente.CorAnel);
                comando.Parameters.AddWithValue("@quantLinha", cliente.QuantLinha);
                comando.Parameters.AddWithValue("@corLinha", cliente.CorLinha);
                comando.Parameters.AddWithValue("@quantPin", cliente.QuantPin);
                comando.Parameters.AddWithValue("@quantTran", cliente.QuantTran);
                comando.Parameters.AddWithValue("@estilo", cliente.Estilo);
                comando.Parameters.AddWithValue("@valorTot", cliente.ValorTot);

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
        public void Salvar(Pessoa cliente)
        {
            try
            {
                AbrirConexao();
                comando = new MySqlCommand("INSERT INTO cliente (nome, cidade, celular, " +
                    "dataa, horario, quantAnel, corAnel, quantArg, corArg, quantLinha, corLinha, quantPin," +
                    "quantTran, estilo, valorTot) VALUES (@nome," +
                    "@cidade, @celular, @dataa, @horario, @quantAnel, @corAnel, @quantArg, @corArg," +
                    "@quantLinha, @corLinha, @quantPin, @quantTran, @estilo, @valorTot)", conexao);

                comando.Parameters.AddWithValue("@nome", cliente.Nome);
                comando.Parameters.AddWithValue("@cidade", cliente.Cidade);
                comando.Parameters.AddWithValue("@celular", cliente.Celular);
                comando.Parameters.AddWithValue("@dataa", DateTime.Parse(cliente.Dataa).ToString("yyyy-MM-dd"));
                comando.Parameters.AddWithValue("@horario", DateTime.Parse(cliente.Horario).ToString("HH:mm"));
                comando.Parameters.AddWithValue("@quantAnel", cliente.QuantAnel);
                comando.Parameters.AddWithValue("@corAnel", cliente.CorAnel);
                comando.Parameters.AddWithValue("@quantArg", cliente.QuantArg);
                comando.Parameters.AddWithValue("@corArg", cliente.CorAnel);
                comando.Parameters.AddWithValue("@quantLinha", cliente.QuantLinha);
                comando.Parameters.AddWithValue("@corLinha", cliente.CorLinha);
                comando.Parameters.AddWithValue("@quantPin", cliente.QuantPin);
                comando.Parameters.AddWithValue("@quantTran", cliente.QuantTran);
                comando.Parameters.AddWithValue("@estilo", cliente.Estilo);
                comando.Parameters.AddWithValue("@valorTot", cliente.ValorTot);
                    
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

                comando = new MySqlCommand("SELECT * FROM cliente ORDER BY nome", conexao);
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
