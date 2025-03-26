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

namespace Practic19
{
    public partial class Authorisation : Form
    {
        public Authorisation()
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
                dal.Server = txtLogin;
                dal.UserID = txtLogin;
                dal.Password = txtPassword;

                using (MySqlConnection connection = new MySqlConnection())
                {
                    connection.Open();
                    dal.Database = "market";

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
