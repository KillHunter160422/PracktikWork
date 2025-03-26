using MySql.Data.MySqlClient;

namespace Practic19
{
    public partial class Autorisation : Form
    {
        public Autorisation()
        {
            InitializeComponent();
        }

        private void sign_Click(object sender, EventArgs e)
        {
            string txtLogin = login.Text.Trim();
            string txtPassword = password.Text.Trim();

            if (string.IsNullOrEmpty(txtLogin))
            {
                MessageBox.Show("Введите логин, по-братски");
                login.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtPassword))
            {
                MessageBox.Show("Введите пароль, по-братски");
                password.Focus();
                return;

            }

            try
            {
                DAL dal = new DAL();
                dal.Server = "localhost";
                dal.Port = 3306;
                dal.Database = "market";
                dal.UserID = txtLogin;
                dal.Password = txtPassword;

                string connectionString = $"Server={dal.Server};Database={dal.Database};User Id={dal.UserID};Password={dal.Password};";
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    MessageBox.Show($"Здравствуйте, {txtLogin}");
                    this.DialogResult = DialogResult.OK;
                    this.Close();

                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
    }
}
