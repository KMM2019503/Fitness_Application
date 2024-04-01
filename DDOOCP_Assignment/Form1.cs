using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZstdSharp.Unsafe;

namespace DDOOCP_Assignment
{
    public partial class Form1 : Form
    {

        public bool _NameError = false;
        public bool _PswError = false;
        public int wrongPasswords = 0;

        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            Login_btn.Enabled = false;
            
        }

        private void form_close_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void register_link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register reg = new Register();
            reg.Show();
            this.Hide();
        }

        private void Login_btn_Click(object sender, EventArgs e)
        {
            DatabaseConnection dt = new DatabaseConnection();
            string sql = "SELECT * FROM users WHERE name = @name;";
            using (MySqlCommand cmd = new MySqlCommand(sql, dt.con))
            {
                cmd.Parameters.AddWithValue("@name", name_input.Text);
                try
                {

                    dt.con.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {

                            if (!bool.Parse(reader["state"].ToString()))
                            {
                                MessageBox.Show("Your account is currently in the block state. Please Contact us for more detail!!");
                                name_input.Clear();
                                psw_input.Clear();
                                return;
                            }
                            wrongPasswords++;


                            if(wrongPasswords == 2)
                            {
                                MessageBox.Show("If you enter the wrong password four times, your account will be blocked.");
                            }

                            if (wrongPasswords >= 4) 
                            {
                               int id = int.Parse(reader["id"].ToString());
                               userStateUpdate(id);
                               wrongPasswords = 0;
                                psw_input.Clear();
                               MessageBox.Show("Your account has been locked due to entering the wrong password too many times. Please contact the help center or email impactzone2024@gmail.com.");
                               return;
                            }
                            

                            if (psw_input.Text == reader["password"].ToString())
                            {
                                int id = int.Parse(reader["id"].ToString());
                                string name = reader["name"].ToString();
                                User current_user = new User(id, name);
                                AdminDashboard ad = new AdminDashboard(current_user);
                                ad.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Wrong Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                psw_input.Clear();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid User", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error during login: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    dt.con.Close();
                }
            }
        }
        

        private void name_input_TextChanged(object sender, EventArgs e)
        {
            if(name_input.TextLength == 0)
            {
                _NameError = false;
            } else
            {
                _NameError = true;
            }
            EnableBtn();
        }

        private void psw_input_TextChanged(object sender, EventArgs e)
        {
            if(psw_input.TextLength == 0)
            {
                _PswError = false;
            } else
            {
                _PswError = true;
            }
            EnableBtn();
        }
        private void EnableBtn()
        {
            if (_NameError && _PswError )
            {

                Login_btn.Enabled = true;
            }
            else
            {
                Login_btn.Enabled = false;
            }
        }

        private void userStateUpdate(int id)
        {
            DatabaseConnection dt = new DatabaseConnection();
            string sql = "update users set state = @state where id = @id;";
            using (MySqlCommand cmd = new MySqlCommand(sql, dt.con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@state", false);
                try
                {
                    dt.con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error happened: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    dt.con.Close();
                }
            }
        }

    }
}


