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
    public partial class Suppliers : Form
    {
        DataTable table = new DataTable("table");
        int index;
        public Suppliers()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            table.Rows.Add(txtSupId.Text, txtSupName.Text, txtSupCompanyname.Text, txtSupEmail.Text, txtContactno.Text);
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter =
               String.Format("Sup_Name like '%" + txtSearch.Text + "%'");
        }

        private void Suppliers_Load(object sender, EventArgs e)
        {
            table.Columns.Add("Sup_ID", Type.GetType("System.Int32"));
            table.Columns.Add("Sup_Name", Type.GetType("System.String"));
            table.Columns.Add("Sup_Company_Name", Type.GetType("System.String"));
            table.Columns.Add("Sup_E-mail", Type.GetType("System.String"));
            table.Columns.Add("Contact No.", Type.GetType("System.String"));
            dataGridView1.DataSource = table;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtSupId.Text = String.Empty;
            txtSupName.Text = String.Empty;
            txtSupCompanyname.Text = String.Empty;
            txtSupEmail.Text = String.Empty;
            txtContactno.Text = String.Empty;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[index];
            txtSupId.Text = row.Cells[0].Value.ToString();
            txtSupName.Text = row.Cells[1].Value.ToString();
            txtSupCompanyname.Text = row.Cells[2].Value.ToString();
            txtSupEmail.Text = row.Cells[3].Value.ToString();
            txtContactno.Text = row.Cells[4].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataGridViewRow newdata = dataGridView1.Rows[index];
            newdata.Cells[0].Value = txtSupId.Text;
            newdata.Cells[1].Value = txtSupName.Text;
            newdata.Cells[2].Value = txtSupCompanyname.Text;
            newdata.Cells[3].Value = txtSupEmail.Text;
            newdata.Cells[4].Value = txtContactno.Text;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            index = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(index);
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

        private void txtSupEmail_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
