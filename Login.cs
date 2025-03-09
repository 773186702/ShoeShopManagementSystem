// LoginForm.cs
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace New_Shoe_InventoryM
{
    public partial class LoginForm : Form
    {

        public LoginForm()
        {
            InitializeComponent();
        }

        private void button_login_Click(object sender, EventArgs e)
        {

           // ('admin', 'admin123'),  --Sample Admin User
           //('user1', 'password1'); --Sample Normal User

            SqlConnection conn = new SqlConnection("Server=DESKTOP-C7DCFJ7\\SQLEXPRESS01;Database=loginapp;Trusted_Connection=True;");
            var userName = txtUsername.Text;
            var userPassword = txtPassword.Text;
            var query = "Select * from users where userName='" + userName + "' AND password='" + userPassword + "'";
           // string query = "SELECT * FROM Users WHERE userName = @userName AND password = @password";

            SqlCommand cmd = new SqlCommand(query, conn);


            try
            {

                SqlDataAdapter adpter1 = new SqlDataAdapter(cmd);

                DataTable table = new DataTable();
                adpter1.Fill(table);

                if (table.Rows.Count == 1)
                {
                    Dashboard gg = new Dashboard();
                    gg.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Error Username or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

      

        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowPassword.Checked == true)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

