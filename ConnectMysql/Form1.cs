using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConnectMysql
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCount_Click(object sender, EventArgs e)
        {
            student std = new student();
            var count = std.GetCount();
            lblCount.Text = count.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            student std = new student();
            int gender = male.Checked ? 1 : 0;
            var result = std.Insert(txtName.Text.Trim(), gender, txtAddress.Text.Trim());
            if (result > 0)
                MessageBox.Show("Success");
            else
                MessageBox.Show("Fail");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Please enter Id");
                return;
            }
            student std = new student();
            int id = Convert.ToInt32(txtId.Text);
            int gender = male.Checked ? 1 : 0;
            var result = std.Update(id, txtName.Text.Trim(), gender, txtAddress.Text.Trim());

            if (result > 0)
                MessageBox.Show("Success");
            else
                MessageBox.Show("Fail");
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Please enter Id");
                return;
            }
            student std = new student();
            var stds = std.Select(Convert.ToInt32(txtId.Text)).FirstOrDefault();
            txtName.Text = stds.NAME;
            txtAddress.Text = stds.ADDRESS;
            if (stds.GENDER == 0)
                female.Checked = true;
            else
                male.Checked = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Please enter Id");
                return;
            }
            var confirmResult = MessageBox.Show("Are you sure to delete this item ??",
                                     "Confirm Delete!!",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                student std = new student();
                int id = Convert.ToInt32(txtId.Text);
                var result = std.Delete(id);
                if (result > 0)
                    MessageBox.Show("Success");
                else
                    MessageBox.Show("Fail");
            }
        }
    }
}
