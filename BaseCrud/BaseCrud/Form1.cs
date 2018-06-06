using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseCrud
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Cadastro
            String query = "INSERT INTO tabela_tb(nome,sobrenome) VALUES(@nome,@sobrenome)";
            SqlCommand cmd = new SqlCommand(query, Conexao.Conectar());
            cmd.Parameters.AddWithValue("@nome", textBox1.Text);
            cmd.Parameters.AddWithValue("@sobrenome", textBox2.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Cadastrado!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Listar
            SqlCommand cmd = new SqlCommand("SELECT * FROM tabela_tb",Conexao.Conectar());
            cmd.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataTable data = new DataTable();
            adapter.Fill(data);
            BindingSource bs = new BindingSource();
            bs.DataSource = data;
            dataGridView1.DataSource = bs;
        }

        //Metodo executado cada vez que troca o item selecionado
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            //Editar
            string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            PuxarDados(id);
        }

        private void PuxarDados(string id) {
            SqlCommand cmd = new SqlCommand("SELECT * FROM tabela_tb WHERE id = '" + id +"'", Conexao.Conectar());
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read()) {
                    textBox3.Text = reader.GetString(1);
                    textBox4.Text = reader.GetString(2);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Excluir
            string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            SqlCommand cmd = new SqlCommand("DELETE FROM tabela_tb WHERE id = '" + id + "'", Conexao.Conectar());
            SqlDataReader reader = cmd.ExecuteReader();
            MessageBox.Show("Deletado!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Editar
            string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            SqlCommand cmd = new SqlCommand("UPDATE tabela_tb SET nome = @nome,sobrenome = @sobrenome WHERE id= '" + id + "'",Conexao.Conectar());
            cmd.Parameters.AddWithValue("@nome", textBox3.Text);
            cmd.Parameters.AddWithValue("@sobrenome", textBox4.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Salvo!");
        }
    }
}
