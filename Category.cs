using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace New_Shoe_InventoryM
{
    public partial class Category : Form
    {
        DataTable table1 = new DataTable("table");
        int index;
        public Category()
        {
            InitializeComponent();
        }

        private void lblCategories_Click(object sender, EventArgs e)
        {

        }

        private void button_stdPrint_Click(object sender, EventArgs e)
        {
            this.Hide();

            // Show the Categories form
            Category categoriesForm = new Category();
            categoriesForm.FormClosed += (s, args) => this.Close(); // Close Dashboard form when Categories form is closed
            categoriesForm.ShowDialog();
        }

        private void Category_Load(object sender, EventArgs e)
        {
            table1.Columns.Add("ID", Type.GetType("System.Int32"));
            table1.Columns.Add("Name", Type.GetType("System.String"));
            table1.Columns.Add("Discription", Type.GetType("System.String"));
      
            dataGridView1.DataSource = table1;
        }

        private void button_search_Click(object sender, EventArgs e)
        {
           
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            table1.Rows.Add(txtID.Text, txtName.Text, textBox_description.Text);
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            txtID.Text = String.Empty;
            txtName.Text = String.Empty;
            textBox_description.Text = String.Empty;
       
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[index];
            txtID.Text = row.Cells[0].Value.ToString();
            txtName.Text = row.Cells[1].Value.ToString();
            textBox_description.Text = row.Cells[2].Value.ToString();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            this.Hide();

            // Show the Dashboard form
            Dashboard dashboardForm = new Dashboard();
            dashboardForm.FormClosed += (s, args) => this.Close(); // Close current form when Dashboard form is closed
            dashboardForm.ShowDialog();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            index = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(index);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter =
               String.Format("Name like '%" + txtSearch.Text + "%'");
        }
    }
}
