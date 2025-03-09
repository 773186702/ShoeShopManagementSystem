using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Data.OleDb;
using System.Security.Cryptography;

namespace New_Shoe_InventoryM
{
    public partial class Products : Form
    {
        public Products()
        {
            InitializeComponent();


        }

        SqlConnection conn = new SqlConnection("Server=DESKTOP-C7DCFJ7\\SQLEXPRESS01;Database=Productss;Trusted_Connection=True");
        SqlCommand cmd;

        DataTable table = new DataTable();

        private void button_clear_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            id1.Text = "";
            txtID.Text = "";
            txtName.Text = "";
            txtPrice.Text = "";
            txtQuantity.Text = "";
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Products_Load(object sender, EventArgs e)
        {
           
            load_data();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "select image(*.Jpg; *.png; *.Gif)| *.Jpg; *.png; *.Gif ";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }
            else
            {
                pictureBox1.Image = null;
            }
        }
        // for search btn
        private void button1_Click(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter =
               String.Format("Name like '%" + txtSearch.Text + "%'");
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //id1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtID.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtName.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtPrice.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtQuantity.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();

            MemoryStream ms = new MemoryStream((byte[])dataGridView1.CurrentRow.Cells[3].Value);
            pictureBox1.Image = Image.FromStream(ms);
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            this.Hide();

            // Show the Dashboard form
            Dashboard dashboardForm = new Dashboard();
            dashboardForm.FormClosed += (s, args) => this.Close(); // Close current form when Dashboard form is closed
            dashboardForm.ShowDialog();
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            this.Hide();

            // Show the Categories form
            Category categoriesForm = new Category();
            categoriesForm.FormClosed += (s, args) => this.Close(); // Close Dashboard form when Categories form is closed
            categoriesForm.ShowDialog();
        }

        private void btnSuppliers_Click(object sender, EventArgs e)
        {
            this.Hide();

            // Show the Suppliers form
            Suppliers suppliersForm = new Suppliers();
            suppliersForm.FormClosed += (s, args) => this.Close(); // Close Dashboard form when Suppliers form is closed
            suppliersForm.ShowDialog();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            this.Hide();

            // Show the Products form
            Products productsForm = new Products();
            productsForm.FormClosed += (s, args) => this.Close(); // Close Dashboard form when Products form is closed
            productsForm.ShowDialog();
        }

        private void btn_LogOut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to log out this application?", "Log-Out Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            // id1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtID.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtName.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();

            MemoryStream ms = new MemoryStream((byte[])dataGridView1.CurrentRow.Cells[3].Value);
            pictureBox1.Image = Image.FromStream(ms);

            txtPrice.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtQuantity.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();

        }

       
        private void btnDelete_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("Delete from Products where ID=@ID", conn);
            cmd.Parameters.AddWithValue("id", id1.Text);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            load_data();

            pictureBox1.Image = null;
            id1.Text = "";
            txtID.Text = "";
            txtName.Text = "";
            txtPrice.Text = "";
            txtQuantity.Text = "";

        }

        private void load_data()
        {
            cmd = new SqlCommand("Select * from Products order by ID desc", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if the required fields are not empty
                if (string.IsNullOrEmpty(txtName.Text) || pictureBox1.Image == null || string.IsNullOrEmpty(txtPrice.Text) || string.IsNullOrEmpty(txtQuantity.Text))
                {
                    MessageBox.Show("Please fill in all fields and select an image.");
                    return;
                }

                // Initialize the SQL command with the insert query
                cmd = new SqlCommand("INSERT INTO Products (Name, Picture, Price, Quantity) VALUES (@Name, @Picture, @Price, @Quantity)", conn);

                // Add parameters with values from the form
                cmd.Parameters.AddWithValue("@Name", txtName.Text);

                // Parse Price and Quantity to their respective data types
                if (decimal.TryParse(txtPrice.Text, out decimal price))
                {
                    cmd.Parameters.AddWithValue("@Price", price);
                }
                else
                {
                    MessageBox.Show("Please enter a valid price.");
                    return;
                }

                if (int.TryParse(txtQuantity.Text, out int quantity))
                {
                    cmd.Parameters.AddWithValue("@Quantity", quantity);
                }
                else
                {
                    MessageBox.Show("Please enter a valid quantity.");
                    return;
                }

                // Convert the image in pictureBox1 to a byte array and add as parameter
                MemoryStream memstm = new MemoryStream();
                pictureBox1.Image.Save(memstm, pictureBox1.Image.RawFormat);
                cmd.Parameters.AddWithValue("@Picture", memstm.ToArray());

                // Open the connection, execute the command, and close the connection
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();

                // Show a message based on the success of the operation
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Data Inserted Successfully");
                }
                else
                {
                    MessageBox.Show("No data was inserted.");
                }

                // Refresh the data in the DataGridView
                load_data();
            }
            catch (Exception ex)
            {
                // Show an error message if an exception occurs
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

    }


    
}


     


