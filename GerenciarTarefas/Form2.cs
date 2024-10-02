using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GerenciarTarefas
{
    public partial class Form2 : Form
    {
        private Panel panel;
        private VScrollBar vScrollBar;
        private List<CheckBox> checkBoxes = new List<CheckBox>();
        public Form2()
        {
            InitializeComponent();
            // Configuração do Formulário
            this.Text = "Exemplo de VScrollBar";
            this.Size = new System.Drawing.Size(300, 400);

            // Criar o painel
            panel = new Panel();
            panel.Size = new System.Drawing.Size(250, 300);
            panel.Location = new System.Drawing.Point(20, 20);
            panel.AutoScroll = false; // Desabilita a rolagem automática

            // Adicionando vários controles ao painel
            for (int i = 0; i < 20; i++)
            {
                var label = new Label();
                label.Text = "Item " + (i + 1);
                label.Location = new System.Drawing.Point(10, 30 * i); // Localiza os labels verticalmente
                panel.Controls.Add(label);
            }

            // Criar a barra de rolagem
            vScrollBar = new VScrollBar();
            vScrollBar.Location = new System.Drawing.Point(260, 20);
            vScrollBar.Size = new System.Drawing.Size(20, 300);
            vScrollBar.Minimum = 0;
            vScrollBar.Maximum = 20; // Máximo é o número de controles no painel
            vScrollBar.SmallChange = 1;
            vScrollBar.LargeChange = 3;

            // Associar evento de rolagem
            vScrollBar.Scroll += vScrollBar1;

            // Adicionar controles ao formulário
            this.Controls.Add(panel);
            this.Controls.Add(vScrollBar);
            int contador = 0;
            string connectionString = "server=127.0.0.1;userid=root;password=root;database=gerenciartarefas";


            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {

                    conn.Open();


                    string query = "SELECT * FROM  tarefas";


                    MySqlCommand cmd = new MySqlCommand(query, conn);


                    MySqlDataReader reader = cmd.ExecuteReader();


                    //string resultado = "";


                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            CheckBox cb = new CheckBox();


                            cb.Text = "Nome: " + reader["Tarefa"].ToString() + "\n" + "Data para conclusão: " + reader["data"] + "\n" + "Cocluído: " + reader["Concluido"] + "\n";
                            cb.Location = new Point(20, 20 + (contador * 60));
                            cb.Name = reader["Tarefa"].ToString();
                            cb.AutoSize = true;



                            this.Controls.Add(cb);

                            checkBoxes.Add(cb);
                            contador++;

                        }

                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Erro ao acessar o banco de dados: " + ex.Message);
                }
            }

        }

        public void button1_Click(object sender, EventArgs e)
        {
            if (checkBoxes.Count > 0)
            {
                foreach (var cb in checkBoxes)
                {
                    if (cb.Checked)
                    {
                        var result = MessageBox.Show($"Tarefa {cb.Name} está marcada.", "Seleção", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);

                        string connectionString = "server=127.0.0.1;userid=root;password=root;database=gerenciartarefas";

                        if (result != DialogResult.Cancel)
                        {
                            MySqlConnection conn = new MySqlConnection(connectionString);
                            try
                            {
                                conn.Open();


                                string query = "UPDATE tarefas SET Concluido = @concluido WHERE Tarefa = @tarefa";
                                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                                {

                                    cmd.Parameters.AddWithValue("@concluido", "sim");
                                    cmd.Parameters.AddWithValue("@tarefa", $"{cb.Name}");


                                    int rowsAffected = cmd.ExecuteNonQuery();
                                    if (rowsAffected > 0)
                                    {
                                        MessageBox.Show("Registro atualizado com sucesso!");
                                    }
                                    else if (rowsAffected <= 0)
                                    {
                                        MessageBox.Show("Nenhum registro encontrado com o nome especificado.");
                                    }
                                }


                            }

                            catch (Exception ex)
                            {
                                MessageBox.Show("Erro ao atualizar o registro: " + ex.Message);
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Nenhuma tarefa encontrada.");
            }
        }

        public void button2_Click(object sender, EventArgs e)
        {
            if (checkBoxes.Count > 0)
            {
                foreach (var cb in checkBoxes)
                {
                    if (cb.Checked)
                    {
                        var result = MessageBox.Show($"Tarefa {cb.Name} está marcada.", "Seleção", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);

                        string connectionString = "server=127.0.0.1;userid=root;password=root;database=gerenciartarefas";

                        if (result == DialogResult.OK)
                        {
                            using (MySqlConnection conn = new MySqlConnection(connectionString))
                            {
                                try
                                {
                                    conn.Open();

                                    // Consulta para obter o id da tarefa correspondente ao checkbox marcado
                                    string query1 = "SELECT id FROM tarefas WHERE Tarefa = @tarefa";

                                    using (MySqlCommand cmd2 = new MySqlCommand(query1, conn))
                                    {
                                        cmd2.Parameters.AddWithValue("@tarefa", cb.Name);

                                        // Executa o comando e obtém o id
                                        object id = cmd2.ExecuteScalar();

                                        if (id != null)
                                        {
                                            // Comando DELETE
                                            string query = "DELETE FROM tarefas WHERE id = @id";

                                            using (MySqlCommand cmd = new MySqlCommand(query, conn))
                                            {
                                                cmd.Parameters.AddWithValue("@id", id);

                                                int rowsAffected = cmd.ExecuteNonQuery();
                                                if (rowsAffected > 0)
                                                {
                                                    MessageBox.Show("Registro deletado com sucesso!");
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Nenhum registro encontrado com o nome especificado.");
                                                }
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Nenhuma tarefa encontrada com o nome especificado.");
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Erro ao atualizar o registro: " + ex.Message);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Nenhuma tarefa encontrada.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            panel.Location = new System.Drawing.Point(panel.Location.X, -vScrollBar.Value * 30); // Multiplica pelo espaço entre os controles
        }
    }
}

