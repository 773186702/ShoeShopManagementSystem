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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_LogOut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to log out this application?", "Log-Out Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void panel_slide_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

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

        private void lblTopProducts_Click(object sender, EventArgs e)
        {

        }
    }
}
