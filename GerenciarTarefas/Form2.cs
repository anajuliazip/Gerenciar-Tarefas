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

        private List<CheckBox> checkBoxes = new List<CheckBox>();
        private Panel panel;
        private VScrollBar vScrollBar;
        public Form2()
        {
            InitializeComponent();
            // Configurar o painel e a barra de rolagem
            panel = new Panel
            {
                Location = new Point(20, 20),
                Size = new Size(300, 300),
                AutoScroll = true // Habilitar AutoScroll
            };
            vScrollBar = new VScrollBar
            {
                Dock = DockStyle.Right, // Dock para ajustar a posição automaticamente
                Minimum = 0
            };
            panel.Controls.Add(vScrollBar); // Adicionar a barra de rolagem ao painel
            vScrollBar.Scroll += vScrollBar1_Scroll;

            this.Controls.Add(panel);
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
                            CheckBox cb = new CheckBox
                            {
                                Text = "Nome: " + reader["Tarefa"].ToString() + "\n" + "Data para conclusão: " + reader["data"] + "\n" + "Concluído: " + reader["Concluido"] + "\n",
                                Location = new Point(0, contador * 60),
                                Name = reader["Tarefa"].ToString(),
                                AutoSize = true
                            };

                            panel.Controls.Add(cb);
                            checkBoxes.Add(cb);
                            contador++;
                        }

                    }
                    vScrollBar.Maximum = Math.Max(panel.Controls.Count * 60 - panel.Height, 0);
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


                                    string query1 = "SELECT id FROM tarefas WHERE Tarefa = @tarefa";

                                    using (MySqlCommand cmd2 = new MySqlCommand(query1, conn))
                                    {
                                        cmd2.Parameters.AddWithValue("@tarefa", cb.Name);

                                        object id = cmd2.ExecuteScalar();

                                        if (id != null)
                                        {

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

            panel.VerticalScroll.Value = vScrollBar.Value; 

        }
    }
}

