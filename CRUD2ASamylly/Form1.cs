using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using CRUD2AEmylly.BLL;
using CRUD2AEmylly.Model;

namespace CRUD2AEmylly
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //metodo para limpar
        public void Limpar()
        {
            txtCodigo.Clear();
            txtNome.Clear();
            txtCidade.Clear();
            mtbCelular.Clear();
            txtQuantAnel.Clear();
            txtCorAnel.Clear();
            txtQuantArg.Clear();
            txtCorArg.Clear();
            txtQuantLinha.Clear();
            txtCorLinha.Clear();
            txtQuantPin.Clear();
            txtQuantTran.Clear();
            cbEstilo.SelectedIndex = -1;
            txtValorTot.Clear();
            txtNome.BackColor = Color.White;
          
        }

        //metodo editar
        public void Alterar(Pessoa pessoa)
        {
            PessoaBLL pessoaBLL = new PessoaBLL();
            try
            {
                if (txtNome.Text.Trim() == string.Empty || txtNome.Text.Trim().Length < 3)
                {
                    MessageBox.Show("O campo NOME não pode ser vazio!", "Alerta",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //exibe uma caixa de alerta para o usuário
                    txtNome.BackColor = Color.LightPink; //muda a cor do campo
                    dtData.BackColor = Color.White;
                    dtHorario.BackColor = Color.White;
                }
                else if (dtData.Text == string.Empty)
                {
                    MessageBox.Show("O campo DATA não pode ser vazio!", "Alerta",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNome.BackColor = Color.White;
                    dtData.BackColor = Color.White;
                    dtHorario.BackColor = Color.LightPink;
                }
                else if (dtHorario.Text == string.Empty)
                {
                    MessageBox.Show("O campo SEXO não pode ser vazio!", "Alerta",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNome.BackColor = Color.White;
                    dtData.BackColor = Color.LightPink;
                    dtHorario.BackColor = Color.LightPink;
                }
                else
                {
                    pessoa.Id = Convert.ToInt32(txtCodigo.Text);

                    pessoa.Nome = txtNome.Text;
                    pessoa.Cidade = txtCidade.Text;
                    mtbCelular.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;  //remove a máscara do campo cpf
                    pessoa.Celular = mtbCelular.Text;
                    pessoa.Dataa = dtData.Text;
                    pessoa.Horario = dtHorario.Text;
                    pessoa.QuantAnel = txtQuantAnel.Text;
                    pessoa.CorAnel = txtCorAnel.Text;
                    pessoa.QuantArg = txtQuantArg.Text;
                    pessoa.CorArg = txtCorArg.Text;
                    pessoa.QuantLinha = txtQuantLinha.Text;
                    pessoa.CorLinha = txtCorLinha.Text;
                    pessoa.QuantPin = txtQuantPin.Text;
                    pessoa.QuantTran = txtQuantTran.Text;
                    pessoa.Estilo = cbEstilo.Text;
                    pessoa.ValorTot = txtValorTot.Text;

                    pessoaBLL.Alterar(pessoa);
                    MessageBox.Show("Cadastro atualizado com sucesso!", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Limpar();
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao atualizar novo cadastro!\n" + erro, "Erro!",
                       MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        //metodo para salvar
        private void Salvar(Pessoa pessoa)
        {
            PessoaBLL pessoaBLL = new PessoaBLL();
            try
            {
                if (txtNome.Text.Trim() == string.Empty || txtNome.Text.Trim().Length < 3)
                {
                    MessageBox.Show("O campo NOME não pode ser vazio!", "Alerta",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //exibe uma caixa de alerta para o usuário
                    txtNome.BackColor = Color.LightPink; //muda a cor do campo
                    dtData.BackColor = Color.White;
                    dtHorario.BackColor = Color.White;
                }
                else if (dtData.Text == string.Empty)
                {
                    MessageBox.Show("O campo DATA não pode ser vazio!", "Alerta",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNome.BackColor = Color.White;
                    dtData.BackColor = Color.White;
                    dtHorario.BackColor = Color.LightPink;
                }
                else if (dtHorario.Text == string.Empty)
                {
                    MessageBox.Show("O campo SEXO não pode ser vazio!", "Alerta",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNome.BackColor = Color.White;
                    dtData.BackColor = Color.LightPink;
                    dtHorario.BackColor = Color.LightPink;
                }
                else
                {
                    pessoa.Id = Convert.ToInt32(txtCodigo.Text);

                    pessoa.Nome = txtNome.Text;
                    pessoa.Cidade = txtCidade.Text;
                    mtbCelular.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;  //remove a máscara do campo celular
                    pessoa.Celular = mtbCelular.Text;
                    pessoa.Dataa = dtData.Text;
                    pessoa.Horario = dtHorario.Text;
                    pessoa.QuantAnel = txtQuantAnel.Text;
                    pessoa.CorAnel = txtCorAnel.Text;
                    pessoa.QuantArg = txtQuantArg.Text;
                    pessoa.CorArg = txtCorArg.Text;
                    pessoa.QuantLinha = txtQuantLinha.Text;
                    pessoa.CorLinha = txtCorLinha.Text;
                    pessoa.QuantPin = txtQuantPin.Text;
                    pessoa.QuantTran = txtQuantTran.Text;
                    pessoa.Estilo = cbEstilo.Text;
                    pessoa.ValorTot = txtValorTot.Text;

                    pessoaBLL.Alterar(pessoa);
                    MessageBox.Show("Cadastro realizado com sucesso!", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Limpar();
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao realizar novo cadastro!\n" + erro, "Erro!",
                       MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        //metodo para listar os dados no grid
        private void Listar()
        {
            PessoaBLL pessoaBLL = new PessoaBLL();
            try
            {
                dataGridView.DataSource = pessoaBLL.Listar();

                //renomear colunas
                dataGridView.Columns[0].HeaderText = "Código";
                dataGridView.Columns[1].HeaderText = "Nome";
                dataGridView.Columns[2].HeaderText = "Cidade";
                dataGridView.Columns[3].HeaderText = "Tel. Celular";
                dataGridView.Columns[4].HeaderText = "Data";
                dataGridView.Columns[5].HeaderText = "Horário";
                dataGridView.Columns[6].HeaderText = "Quant. Anel";               
                dataGridView.Columns[7].HeaderText = "Cor Anel";
                dataGridView.Columns[8].HeaderText = "Quant. Arg,";               
                dataGridView.Columns[9].HeaderText = "Cor Arg.";
                dataGridView.Columns[10].HeaderText = "Quant. Linha";
                dataGridView.Columns[11].HeaderText = "Cor Linha";
                dataGridView.Columns[12].HeaderText = "Quant. Ping.";
                dataGridView.Columns[13].HeaderText = "Quant. Trança";
                dataGridView.Columns[14].HeaderText = "Estilo";
                dataGridView.Columns[15].HeaderText = "Valor total";

                //Remover colunas do datagrid
                dataGridView.Columns[6].Visible = false;
                dataGridView.Columns[7].Visible = false;
                dataGridView.Columns[8].Visible = false;
                dataGridView.Columns[9].Visible = false;
                dataGridView.Columns[10].Visible = false;
                dataGridView.Columns[11].Visible = false;
                dataGridView.Columns[12].Visible = false;
                dataGridView.Columns[13].Visible = false;
                dataGridView.Columns[14].Visible = false;
                dataGridView.Columns[15].Visible = false;

                //largura das colunas
                dataGridView.Columns[0].Width = 20;
                dataGridView.Columns[1].Width = 160;
                dataGridView.Columns[2].Width = 70;
                dataGridView.Columns[3].Width = 40;
                dataGridView.Columns[4].Width = 75;
                dataGridView.Columns[5].Width = 85;

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao exibir os dados!\n" + erro, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnExibir_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Pessoa pessoa = new Pessoa();
            Salvar(pessoa);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        private void dataGridView_DoubleClick(object sender, EventArgs e)
        {
            txtCodigo.Text = dataGridView.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = dataGridView.CurrentRow.Cells[1].Value.ToString();
            txtCidade.Text = dataGridView.CurrentRow.Cells[2].Value.ToString();
            mtbCelular.Text = dataGridView.CurrentRow.Cells[3].Value.ToString();
            dtData.Text = dataGridView.CurrentRow.Cells[4].Value.ToString();
            dtHorario.Text = dataGridView.CurrentRow.Cells[5].Value.ToString();
            txtQuantAnel.Text = dataGridView.CurrentRow.Cells[6].Value.ToString();
            txtCorAnel.Text = dataGridView.CurrentRow.Cells[7].Value.ToString();
            txtQuantArg.Text = dataGridView.CurrentRow.Cells[8].Value.ToString();
            txtCorArg.Text = dataGridView.CurrentRow.Cells[9].Value.ToString();
            txtQuantLinha.Text = dataGridView.CurrentRow.Cells[10].Value.ToString();
            txtCorLinha.Text = dataGridView.CurrentRow.Cells[11].Value.ToString();
            txtQuantPin.Text = dataGridView.CurrentRow.Cells[12].Value.ToString();
            txtQuantTran.Text = dataGridView.CurrentRow.Cells[13].Value.ToString();
            cbEstilo.Text = dataGridView.CurrentRow.Cells[14].Value.ToString();
            txtValorTot.Text = dataGridView.CurrentRow.Cells[15].Value.ToString();

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Pessoa pessoa = new Pessoa();
            Alterar(pessoa);
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
