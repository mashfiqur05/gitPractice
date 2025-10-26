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
using System.Data.SqlTypes;

namespace eAcademy_Management_System
{
    public partial class Registration_Form : Form
    {
        public Registration_Form()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string FullName = txtUn.Text;
            string email = txtEa.Text;
            string password = txtPass2.Text;
            string confirmPassword = txtConfirm.Text;

            string gender = "";
            if (rbMale.Checked)
            {
                gender = "Male";
            }
            else if (rbFemale.Checked)
            {
                gender = "Female";
            }

            string userName = txtUserName.Text;
            DateTime dob = dtpDob.Value;





            if (string.IsNullOrWhiteSpace(FullName))
            {
                MessageBox.Show("Please enter your Full Name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }


            if (string.IsNullOrWhiteSpace(userName))
            {
                MessageBox.Show("Please Enter Your UserName.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }




            if (string.IsNullOrWhiteSpace(gender))
            {
                MessageBox.Show("Please select your Gender.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Please enter your Email Address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (!dtpDob.Checked)

            {

                MessageBox.Show("Please select your Date Of Birth.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DateTime Dob = dtpDob.Value;


            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Please enter a password and confirm your password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (password != confirmPassword)
            {
                MessageBox.Show("The password and confirm password do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPass2.Clear();
                txtConfirm.Clear();
                txtPass2.Focus();
                return;
            }

            try
            {
                
                var con = new SqlConnection();


                con.ConnectionString = ApplicationHelper.Connectionpath;
                con.Open();

                var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = $"Insert into UserInfo values ('{FullName}','{userName}','{gender}','{email}','{Dob}','{password}', 'Student')";
                cmd.ExecuteNonQuery();

                con .Close();
                MessageBox.Show("Registration Successfully Completed");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void pass2_Click(object sender, EventArgs e)
        {
            txtPass2.UseSystemPasswordChar = false;
        }

        private void pass3_Click(object sender, EventArgs e)
        {

            txtConfirm.UseSystemPasswordChar = false;

        }

        private void pass2_MouseHover(object sender, EventArgs e)
        {
            txtPass2.UseSystemPasswordChar = false;
        }

        private void pass2_MouseLeave(object sender, EventArgs e)
        {
            txtPass2.UseSystemPasswordChar = true;
        }

        private void pass3_MouseHover(object sender, EventArgs e)
        {
            txtConfirm.UseSystemPasswordChar = false;
        }

        private void pass3_MouseLeave(object sender, EventArgs e)
        {
            txtConfirm.UseSystemPasswordChar = true;
        }

        private void dtpDob_ValueChanged(object sender, EventArgs e)
        {
            dtpDob.Format = DateTimePickerFormat.Short;
            dtpDob.CustomFormat = null;
        }
    }
}

