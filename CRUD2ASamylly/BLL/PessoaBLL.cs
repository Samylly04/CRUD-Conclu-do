using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD2AEmylly.DAL;
using System.Data;
using CRUD2AEmylly.Model;

namespace CRUD2AEmylly.BLL
{
    public class PessoaBLL
    {
        PessoaDAL pessoaDAL = new PessoaDAL();

        //método para excluir
        public void Excluir(Pessoa cliente)
        {
            try
            {
                pessoaDAL.Excluir(cliente);
            }
            catch (Exception erro)
            {

                throw erro;
            }
        }

        //metodo para editar
        public void Alterar(Pessoa cliente)
        {
            try
            {
                pessoaDAL.Alterar(cliente);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        //metodo para salvar 
        public void Salvar(Pessoa cliente)
        {
            try
            {
                pessoaDAL.Salvar(cliente);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        //metodo para listar

        public DataTable Listar()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = pessoaDAL.Listar();
                return dt;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
    }
}
