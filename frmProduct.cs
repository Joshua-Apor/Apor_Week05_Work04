using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Apor_Week05_Work04
{
    public partial class frmProduct : Form
    {
        public frmProduct()
        {
            InitializeComponent();

            cmbCategory.Items.AddRange(new string[]
            {
                "Electronics",
                "Clothing",
                "Food",
                "Furniture",
                "Appliances",
                "Other"
            });

            rdoLocal.Checked = true;
            chkActive.Checked = true;
        }

        private void CalculateMarkup(object sender, EventArgs e)
        {
            decimal cost, price;

            if (decimal.TryParse(txtCost.Text, out cost) &&
                decimal.TryParse(txtPrice.Text, out price) &&
                cost > 0)
            {
                decimal markup = ((price - cost) / cost) * 100;

                txtMarkup.Text = markup.ToString("0.00");
            }
            else
            {
                txtMarkup.Clear();
            }
        }


        private void frmProduct_Load(object sender, EventArgs e)
        {

        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void rdoLocal_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdoAbroad_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void lblMarkup_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBarcode.Text))
            {
                MessageBox.Show("Please enter the barcode.");
                txtBarcode.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter the product name.");
                txtName.Focus();
                return;
            }

            if (cmbCategory.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a category.");
                cmbCategory.Focus();
                return;
            }

            decimal cost, price;

            if (!decimal.TryParse(txtCost.Text, out cost) || cost <= 0)
            {
                MessageBox.Show("Enter a valid cost greater than zero.");
                txtCost.Focus();
                return;
            }

            if (!decimal.TryParse(txtPrice.Text, out price) || price < cost)
            {
                MessageBox.Show("Price must be equal to or greater than cost.");
                txtPrice.Focus();
                return;
            }

            string origin = rdoLocal.Checked ? "Local" : "Abroad";

            decimal markup = ((price - cost) / cost) * 100;

            MessageBox.Show(
                "Product Saved Successfully!\n\n" +
                "Barcode: " + txtBarcode.Text +
                "\nName: " + txtName.Text +
                "\nDescription: " + txtDescription.Text +
                "\nCategory: " + cmbCategory.Text +
                "\nOrigin: " + origin +
                "\nStatus: " + (chkActive.Checked ? "Active" : "Inactive") +
                "\nCost: " + cost.ToString("N2") +
                "\nPrice: " + price.ToString("N2") +
                "\nMarkup: " + markup.ToString("0.00") + "%",
                "Save Successful"
            );
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Clear all fields?",
                "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                txtBarcode.Clear();
                txtName.Clear();
                txtDescription.Clear();

                cmbCategory.SelectedIndex = -1;

                rdoLocal.Checked = true;
                chkActive.Checked = true;

                txtCost.Clear();
                txtPrice.Clear();
                txtMarkup.Clear();

                txtBarcode.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to exit?",
                "Confirm Exit",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
