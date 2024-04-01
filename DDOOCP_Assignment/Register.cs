using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DDOOCP_Assignment
{
    public partial class Register : Form
    {
        public bool _NameError = false;
        public bool _PswError = false;
        public bool _ComPswError = false;
        public Register()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            error_message.Hide();
            center_element();
            submit_btn.Enabled = false;
        }

        private void submit_btn_Click(object sender, EventArgs e)
        {
            
            string password = psw_input.Text;
            string name = name_input.Text;
            string pattern = "^[a-zA-Z0-9]*$";
            Regex regex = new Regex(pattern);
            if (!regex.IsMatch(name))
            {
                MessageBox.Show("User name can contain only letters and numbera!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password))
            {
                center_element();
                error_message.Text = "You need to fill in both fields";
                error_message.Show();
                return;
            }
            if (!regex.IsMatch(name))
            {
                MessageBox.Show("User name can contain only letters and numbera!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (password.Length != 12 || !password.Any(char.IsUpper) || !password.Any(char.IsLower))
            {
                MessageBox.Show("Password must be 12 characters long and contain at least one uppercase and one lowercase letter.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }
            if (password != comfirm_psw_input.Text)
            {
                MessageBox.Show("You need to put the same password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string sql = "insert into users (name, password,state) values (@name, @password, true)";
            DatabaseConnection dt = new DatabaseConnection();   
            using (MySqlCommand cmd = new MySqlCommand(sql, dt.con))
            {
                cmd.Parameters.AddWithValue("@name", name_input.Text);
                cmd.Parameters.AddWithValue("@password", psw_input.Text);
                try
                {
                    dt.con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Creation Successfully");
                    Form1 form = new Form1();
                    form.Show();
                    this.Hide();
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    if (ex.Number == 1062)
                    {
                        MessageBox.Show("Username already exists. Please choose a different username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Error inserting into the database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                finally
                {
                    dt.con.Close(); 
                }
            }
        }

        private void name_input_TextChanged(object sender, EventArgs e)
        {
            
            string name = name_input.Text;
            string pattern = "^[a-zA-Z0-9]*$";
            Regex regex = new Regex(pattern);
            if (!regex.IsMatch(name))
            {
                error_message.Text = "Uname can only contain letters and numbers!";
                error_message.Show();
                center_element();
                
            }
            else
            {
                error_message.Hide();
                _NameError = true;
            }
            EnableBtn();

        }

        private void form_close_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void psw_input_TextChanged(object sender, EventArgs e)
        {
            
            string password = psw_input.Text;
            if (password.Length != 12 || !password.Any(char.IsUpper) || !password.Any(char.IsLower))
            {
                
                error_message.Text = "Password must be 12 characters long and contain at least one uppercase and one lowercase letter.";
                error_message.Show();
                center_element();
            }
            else
            {
                error_message.Hide();
                _PswError = true;
            }
            EnableBtn();
        }

        private void comfirm_psw_input_TextChanged(object sender, EventArgs e)
        {
            
            string password = psw_input.Text;
            string confirmPassword = comfirm_psw_input.Text;

            if (password != confirmPassword)
            {
                error_message.Text = "Passwords do not match!";
                error_message.Show();
                center_element();
            }
            else
            {
                error_message.Hide();
                _ComPswError = true;
            }
            EnableBtn();
        }

        private void center_element()
        {
            Control controlToCenter = error_message;
            int x = (panel1.Width - controlToCenter.Width) / 2;
            int y = controlToCenter.Location.Y;
            controlToCenter.Location = new Point(x, y);
        }

        private void EnableBtn()
        {
            if(_NameError && _PswError && _ComPswError)
            {
                
                submit_btn.Enabled = true;
            }
            else
            {
                submit_btn.Enabled = false;
            }
        }

        private void login_link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }
    }
}
