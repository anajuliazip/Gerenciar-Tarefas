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

namespace GerenciarTarefas
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
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

                            // Define as propriedades básicas
                            cb.Text = reader["Tarefa"].ToString();
                            cb.Location = new Point(20, 20 + (contador * 30)); // Define a posição dos CheckBoxes de forma crescente
                            cb.Name = reader["Tarefa"].ToString();
                            cb.AutoSize = true;



                            this.Controls.Add(cb);

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
    }
}
