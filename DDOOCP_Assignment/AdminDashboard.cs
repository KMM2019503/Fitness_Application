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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DDOOCP_Assignment
{
    public partial class AdminDashboard : Form
    {
        public DatabaseConnection dc = new DatabaseConnection();
        private User current_user;
        private bool target;
        private bool newUser;
        private bool newTartgetCreation = false;
        private Target current_target = new Target();

        public AdminDashboard()
        {
            InitializeComponent();
        }

        public AdminDashboard(User current_user) : this()
        {
            this.current_user = current_user;
            name_holder.Text = current_user.Name;
            
            DatabaseConnection dc = new DatabaseConnection();
            string sql = "SELECT * FROM targetCaloreis WHERE user_id = @user_id AND target_number = ( SELECT MAX(target_number) FROM targetCaloreis WHERE user_id = @user_id );";
            using (MySqlCommand cmd = new MySqlCommand(sql, dc.con))
            {
                cmd.Parameters.AddWithValue("@user_id", current_user.Id);
                try
                {
                     dc.con.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            //Old user
                            this.target = true;
                            this.newUser = false;
                            registerCurrentTarget();
                            LoadDataForHistories();
                            LoadActivitiesHistories();
                        }
                        else
                        {
                            //new user
                            this.target = false;
                            this.newUser = true;
                            Profile.SelectedIndex = 1;
                            MessageBox.Show("Please create targets that are challenging for your body.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error during login: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                     dc.con.Close();
                }
            }
        }

        private void submit_btn_Click(object sender, EventArgs e)
        {
            if (calo_input.Value == 0)
            {
                MessageBox.Show("Put the target calories input value");
                return;
            }
            if (current_weight_input.Value == 0)
            {
                MessageBox.Show("Put the current weight value");
                return;
            }
            bool creationTargetForOldUser = false;
            if (!newUser)
            {
                if (!current_target.Success)
                {
                    DialogResult result = MessageBox.Show("You have unsuccessful target, are you sure want to create new target?", "Confirmation", MessageBoxButtons.OKCancel);
                    if (result == DialogResult.OK)
                    {
                        creationTargetForOldUser = true;
                    }
                } else
                {
                    creationTargetForOldUser = true;
                }
                
            }

            if (creationTargetForOldUser || this.newUser)
            {

                int target_num = 0;
                bool success = false;
                if (this.target == false)
                {
                    target_num = 1;
                }
                else
                {
                    target_num = current_target.Target_num + 1;
                }
                DateTime currentDateTime = DateTime.Today;
                string formattedDate = currentDateTime.ToString("yyyy-MM-dd");
                double cal = Convert.ToDouble(calo_input.Value);
                double weight = Convert.ToDouble(current_weight_input.Value);
                string sql = "insert into targetCaloreis (target_number, user_id, current_weight,target_cal,success,date,burned_cal) " +
                    "values (@target_number, @user_id,@current_weight,@target_cal,@success, @date, @burned_cal )";
                DatabaseConnection dc = new DatabaseConnection();
                using (MySqlCommand cmd = new MySqlCommand(sql,  dc.con))
                {
                    cmd.Parameters.AddWithValue("@target_number", target_num);
                    cmd.Parameters.AddWithValue("@user_id", current_user.Id);
                    cmd.Parameters.AddWithValue("@success", success);
                    cmd.Parameters.AddWithValue("@target_cal", cal);
                    cmd.Parameters.AddWithValue("@current_weight", weight);
                    cmd.Parameters.AddWithValue("@date", formattedDate);
                    cmd.Parameters.AddWithValue("@burned_cal", 0.0);
                    try
                    {
                         dc.con.Open();
                        cmd.ExecuteNonQuery();
                        this.newTartgetCreation = true;
                        MessageBox.Show("Target Creation Successfully", "Success", MessageBoxButtons.OK);
                        registerCurrentTarget();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error inserting into the database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                         dc.con.Close();
                    }
                }
            }
            else
            {
                return;
            }


        }
        //this method is finding the last target that created the user.
        private void registerCurrentTarget()
        {
            string sql = "SELECT * FROM targetCaloreis WHERE user_id = @id AND target_number = (SELECT MAX(target_number) FROM targetCaloreis WHERE user_id = @id);";
            DatabaseConnection dc = new DatabaseConnection();
            using (MySqlCommand cmd = new MySqlCommand(sql,  dc.con))
            {
                cmd.Parameters.AddWithValue("@id", current_user.Id);

                try
                {
                     dc.con.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int id = int.Parse(reader["id"].ToString());
                            int tar_num = Convert.ToInt32(reader["target_number"]);
                            int user_id = Convert.ToInt32(reader["user_id"]);
                            double cur_weight = Convert.ToDouble(reader["current_weight"]);
                            double tar_calo = Convert.ToDouble(reader["target_cal"]);
                            bool success = Convert.ToBoolean(reader["success"]);
                            DateTime date = Convert.ToDateTime(reader["date"].ToString());
                            Target new_target = new Target(id, tar_num, user_id, cur_weight, tar_calo, success, date);
                            new_target.Burned_calo = Convert.ToDouble(reader["burned_cal"]);
                            if (new_target.Success)
                            {
                                MessageBox.Show("You completed the last target! Create a new target for challenging");
                                this.current_target = new_target;
                                weight_holder.Text = current_target.Current_weight.ToString();
                                calo_holder.Text = current_target.Target_calo.ToString();
                                calories_burned_input.Text = current_target.Burned_calo.ToString("0.00");
                            }
                            else
                            {
                                if (!newTartgetCreation && !newUser)
                                {
                                    MessageBox.Show("You uncompleted the last target!");
                                }
                                this.current_target = new_target;
                                weight_holder.Text = current_target.Current_weight.ToString();
                                calo_holder.Text = current_target.Target_calo.ToString();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid Target", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error during finding last target: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                     dc.con.Close();
                }
            }

        }

        private void go_to_activity_Click(object sender, EventArgs e)
        {
            if (current_target.Id == 0)
            {
                MessageBox.Show("First, You need to create a target", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if(current_target.Success)
            {
                MessageBox.Show("You completed the last target! Create a new target for a new challenge.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ActivitiesMenu act = new ActivitiesMenu(current_user, current_target);
                act.Show();
                this.Hide();
            }

        }
        // this method is load target data form targets table from database
        private void LoadDataForHistories()
        {
            
            string sql = @"select current_weight As 'Weight',target_cal As 'Target Calories' ,format(burned_cal, 1) As 'Calories Burned', date As 'Date', success As 'Success' from targetCaloreis where user_id = @user_id;";
            DataTable dataTable = new DataTable();
            DatabaseConnection dc = new DatabaseConnection();
            using (MySqlCommand cmd = new MySqlCommand(sql,  dc.con))
            {
                cmd.Parameters.AddWithValue("@user_id", current_user.Id);
                try
                {
                     dc.con.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        
                            DataTable dt = new DataTable();
                            dt.Load(reader);
                            targets_histories.DataSource = dt;
                        
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error during Loading the histories: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                     dc.con.Close();
                }
            }
        }
        // this method is load activities log data form histories table from database
        private void LoadActivitiesHistories()
        {
            string sql = @"SELECT 
                            tc.target_number AS 'Target Number', 
                            upper(h.name) AS 'Acitivity Name',
                            FORMAT(h.calories_burned, 2) AS 'Calories Burned', 
                            h.date AS 'Date'
                            FROM 
                            targetCaloreis tc
                            JOIN 
                                histories h ON tc.id = h.tarCalo_id
                            WHERE 
                                h.user_id = @user_id;";
            using (MySqlCommand cmd = new MySqlCommand(sql, dc.con))
            {
                cmd.Parameters.AddWithValue("@user_id", current_user.Id);
                try
                {
                    dc.con.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        activities_histories.DataSource = dt;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error during Loading the histories: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    dc.con.Close();
                }
            }
        }

        private void form_close_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Logout(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }


    }
}
