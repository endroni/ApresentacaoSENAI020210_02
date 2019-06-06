using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CRUD_FIEMG
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Inserindo dados no combobox Estado
            cmbEstado.Items.Add("MG");
            cmbEstado.Items.Add("SP");
            cmbEstado.Items.Add("RJ");

            //Inserindo dados no combobox Cidade
            cmbCidade.Items.Add("Belo Horizonte");
            cmbCidade.Items.Add("Santa Luzia");
            cmbCidade.Items.Add("Sabará");
            cmbCidade.Items.Add("São Paulo");
            cmbCidade.Items.Add("Santos");
            cmbCidade.Items.Add("Paratí");
            cmbCidade.Items.Add("Xerém");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Conecta no banco
                MySqlConnection objcon = new MySqlConnection("SERVER=localhost;DATABASE=bd_crud;UID=root;PASSWORD=;");
                // Abre a conexão com o Banco
                objcon.Open();
                // Comandos de inserção
                MySqlCommand objCmd = new MySqlCommand("INSERT INTO tb_dados ( cd_dados,nm_nome,sg_estado,nm_cidade,ds_endereco) VALUES (NULL, ?, ?, ?, ?)",objcon);
                //Parametros para o SQL
                objCmd.Parameters.Add("@nm_nome", MySqlDbType.VarChar, 60).Value = txtNome.Text;
                objCmd.Parameters.Add("@sg_estado", MySqlDbType.VarChar, 2).Value = cmbEstado.SelectedItem.ToString();
                objCmd.Parameters.Add("@nm_cidade", MySqlDbType.VarChar, 50).Value = cmbCidade.SelectedItem.ToString();
                objCmd.Parameters.Add("@ds_endereco", MySqlDbType.VarChar, 100).Value = txtEndereco.Text;

                // Comando para executar a query
                objCmd.ExecuteNonQuery();

                MessageBox.Show("Cadastrado!");

                // Fecha a conexão com o banco
                objcon.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro de conexão!!!" + erro);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Conecta no banco
                MySqlConnection objcon = new MySqlConnection("SERVER=localhost;DATABASE=bd_crud;UID=root;PASSWORD=;");
                // Abre a conexão com o Banco
                objcon.Open();
                // Comandos do mysql e seus parâmetros
                MySqlCommand objCmd = new MySqlCommand("DELETE FROM tb_dados WHERE cd_dados = ?",objcon);
                objCmd.Parameters.Clear();
                objCmd.Parameters.Add("@cd_dados", MySqlDbType.Int32).Value = txtCod.Text;

                // Executa o comando
                objCmd.CommandType = CommandType.Text;
                objCmd.ExecuteNonQuery();

                //Fecha a conexão
                objcon.Close();

                MessageBox.Show("Registro removido!");
            }
            catch (Exception erro)
            {
                MessageBox.Show("Não foi possível deletar !!!" + erro);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Conecta no banco
                MySqlConnection objcon = new MySqlConnection("SERVER=localhost;DATABASE=bd_crud;UID=root;PASSWORD=;");
                // Abre a conexão com o Banco
                objcon.Open();

                // Comandos do mysql e seus parâmetros
                MySqlCommand objCmd = new MySqlCommand("SELECT nm_nome,sg_estado,nm_cidade,ds_endereco FROM tb_dados WHERE cd_dados = ?", objcon); 
                objCmd.Parameters.Clear();
                objCmd.Parameters.Add("@cd_dados", MySqlDbType.Int32).Value = txtCod.Text;
                // Executa o comando
                objCmd.CommandType = CommandType.Text;

                // Recebe o conteúdo do banco
                MySqlDataReader dr;
                dr = objCmd.ExecuteReader();

                // Insere as informações vindas do banco para o formulário
                dr.Read();

                txtNome.Text = dr.GetString(0);
                cmbEstado.Text = dr.GetString(1);
                cmbCidade.Text = dr.GetString(2);
                txtEndereco.Text = dr.GetString(3);

                //Fecha a conexão
                objcon.Close();
            }

            catch (Exception erro)
            {
                MessageBox.Show("Erro de procura! " + erro);
            }
        }

        private void atualizar_Click(object sender, EventArgs e)
        {
            try
            {

            }

        }
    }
}
