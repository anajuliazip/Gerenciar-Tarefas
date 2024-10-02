using MySql.Data.MySqlClient;

namespace GerenciarTarefas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            lblError.Visible = false;
        }

        private void btnTarefa_Click(object sender, EventArgs e)
        {
            string tarefa = txbTarefa.Text;
            string data = mCDataTarefa.SelectionStart.Date.ToString("dd/MM/yyyy");

            try
            {
                MySqlConnection conn = new MySqlConnection("server=127.0.0.2;userid=root;password=root;database=gerenciartarefas");
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO `tarefas` (`Tarefa`, `data`) VALUES (@tarefa, @data);", conn);
                cmd.Parameters.AddWithValue("@tarefa", tarefa);
                cmd.Parameters.AddWithValue("@data", data);

                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception Ex)
            {
                lblError.Visible = true;
                lblError.Text = Ex.Message.ToString();
            }
            finally
            {
                txbTarefa.Text = null;
                mCDataTarefa.Text = null;
            }
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.ShowDialog();
        }
    }
}