using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eAcademy_Management_System
{
    public partial class ForgotForm : Form
    {
        public ForgotForm()
        {
            InitializeComponent();
        }

      
        private void pass5_Click(object sender, EventArgs e)
        {
            txtNewPassword2.UseSystemPasswordChar = false;
        }

        private void pass5_MouseHover(object sender, EventArgs e)
        {
            txtNewPassword2.UseSystemPasswordChar = false;
        }

        private void pass5_MouseLeave(object sender, EventArgs e)
        {
            txtNewPassword2.UseSystemPasswordChar = true;
        }

        private void pass6_Click(object sender, EventArgs e)
        {
            txtConfirmPassword2.UseSystemPasswordChar = false;
        }

        private void pass6_MouseHover(object sender, EventArgs e)
        {
            txtConfirmPassword2.UseSystemPasswordChar = false;
        }

        private void pass6_MouseLeave(object sender, EventArgs e)
        {
            txtConfirmPassword2.UseSystemPasswordChar = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        
            
        
           
            string email = txtEmailAddress2.Text;
            string username = txtUserName2.Text;
            string newPass = txtNewPassword2.Text;
            string confirmPass = txtConfirmPassword2.Text;


            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Please enter your Email Address.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Please enter your Username.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(newPass))
            {
                MessageBox.Show("Please enter a New Password.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(confirmPass))
            {
                MessageBox.Show("Please confirm your New Password.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (newPass != confirmPass)
            {
                MessageBox.Show("The new password and confirm password do not match!", "Password Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           
           

            try
            {
               
                var con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.Connectionpath;
                con.Open();

               
                var checkCmd = new SqlCommand();
                checkCmd.Connection = con;

               
                checkCmd.CommandText = $"SELECT * FROM UserInfo WHERE UserName='{username}' AND EmailAddress='{email}'";

                SqlDataAdapter adp = new SqlDataAdapter(checkCmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                   
                    var updateCmd = new SqlCommand();
                    updateCmd.Connection = con;

                    
                    updateCmd.CommandText = $"UPDATE UserInfo SET Password='{newPass}' WHERE UserName='{username}' AND EmailAddress='{email}'";

                    updateCmd.ExecuteNonQuery();

                    MessageBox.Show("Password reset successfully! You can now log in.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                }
                else
                {
                   
                    MessageBox.Show("The provided Email Address and Username combination was not found.", "Verification Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtUserName2_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }

