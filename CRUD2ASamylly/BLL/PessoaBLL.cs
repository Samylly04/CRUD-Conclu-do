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

        //metodo para editar
        public void Alterar(Pessoa pessoa)
        {
            try
            {
                pessoaDAL.Alterar(pessoa);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        //metodo para salvar 
        public void Salvar(Pessoa pessoa)
        {
            try
            {
                pessoaDAL.Salvar(pessoa);
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
