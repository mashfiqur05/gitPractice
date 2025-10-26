using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace eAcademy_Management_System
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string un = txtUsername.Text;
            string pass = txtPass.Text;
            if (string.IsNullOrWhiteSpace(un) || string.IsNullOrWhiteSpace(pass))
            {
                MessageBox.Show("Please enter both username and password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
               
                var con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.Connectionpath;
                con.Open();

                var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = $"SELECT * FROM UserInfo WHERE UserName='{txtUsername.Text}' AND Password='{txtPass.Text}'";
                cmd.ExecuteNonQuery();

                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Login successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    

          

        private void label6_Click(object sender, EventArgs e)
        {
            Registration_Form registerForm = new Registration_Form();
            registerForm.Show();
            this.Hide();
        }

        private void forgotPass_Click(object sender, EventArgs e)
        {
            ForgotForm forgotForm = new ForgotForm();
            forgotForm.ShowDialog();
        }

        private void pass1_Click(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = false;
        }

        private void pass1_MouseHover(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = false;
        }

        private void pass1_MouseLeave(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = true;
        }
    }
}
