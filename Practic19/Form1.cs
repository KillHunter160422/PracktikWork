namespace Practic19
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string getConnection = DAL.GetConnection;
            textBox1.Text = getConnection;

            try
            {
                using (var connection = new MySql.Data.MySqlClient.MySqlConnection(getConnection))
                {
                    connection.Open();
                    MessageBox.Show("Успешное подключение к БД");

                    Autorisation autorisation = new Autorisation();
                    autorisation.Show();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
