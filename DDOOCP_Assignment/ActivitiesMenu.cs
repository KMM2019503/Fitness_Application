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
    public partial class ActivitiesMenu : Form
    {
        private User user;
        private Target target;
        public ActivitiesMenu()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        public ActivitiesMenu(User user, Target target) : this()
        {
            this.user = user;
            this.target = target;
            user_name_holder.Text = user.Name;
            cal_target_holder.Text = target.Target_calo.ToString("0.00");
            weight_holder.Text = target.Current_weight.ToString();
            curret_tar_cal_burn_holder.Text = target.Burned_calo.ToString("0.00");
            int progress_num = (int)((double)target.Burned_calo / target.Target_calo * 100);

            cal_burned_progress_bar.Value = progress_num > 100 ? 100 : progress_num;
            LoadDataForHistories();
        }

        private void form_close_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // this method is load data form histories from database
        private void LoadDataForHistories()
        {

            string sql = @"select name As 'Name',format(calories_burned, 1) As 'Calories Burned', date As 'Date' from histories where user_id = @user_id and tarCalo_id = @target_id;";
            DataTable dataTable = new DataTable();

            DatabaseConnection dc = new DatabaseConnection();
            using (MySqlCommand cmd = new MySqlCommand(sql, dc.con))
            {
                cmd.Parameters.AddWithValue("@user_id", user.Id);
                cmd.Parameters.AddWithValue("@target_id", target.Id);
                try
                {
                    dc.con.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        dataTable.Load(reader);
                        histories_data.DataSource = dataTable;
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

        private void walking_btn_Click(object sender, EventArgs e)
        {
            Walking wal = new Walking(user, target);
            wal.Show();
            this.Hide();
        }

        private void running_btn_Click(object sender, EventArgs e)
        {
            Running rn = new Running(user, target);
            rn.Show();
            this.Hide();
        }

        private void swimming_btn_Click(object sender, EventArgs e)
        {
            Swimming swm = new Swimming(user, target);
            swm.Show();
            this.Hide();
        }

        private void jump_rope_Click(object sender, EventArgs e)
        {
            JumpRope jr = new JumpRope(user, target);
            jr.Show();
            this.Hide();
        }

        private void weightlifiting_btn_Click(object sender, EventArgs e)
        {
            Weightlifting wf = new Weightlifting(user, target);
            wf.Show();
            this.Hide();
        }

        private void bicycling_btn_Click(object sender, EventArgs e)
        {
            Cycling cy = new Cycling(user, target);
            cy.Show();
            this.Hide();
        }

        private void GoToDashborad(object sender, EventArgs e)
        {
            AdminDashboard ad = new AdminDashboard(user);
            ad.Show();
            this.Hide();
        }

        private void logout_btn_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();  
            this.Hide();
        }

        
    }
}
