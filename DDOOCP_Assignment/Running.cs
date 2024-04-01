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

namespace DDOOCP_Assignment
{
    public partial class Running : Form
    {
        private User user;
        private Target target;
        private string name = "Running";
        public Running()
        {
            InitializeComponent();
        }
        public Running(User user, Target target) : this() 
        {
            
            this.user = user;
            this.target = target;
            name_holder.Text = user.Name;
            weight_holder.Text = this.target.Current_weight.ToString();
            tar_cal_holder.Text = this.target.Target_calo.ToString();
        }

        private void cal_btn_Click(object sender, EventArgs e)
        {
            double time = (int)time_input.Value;
            if (time == 0)
            {
                MessageBox.Show("Please Enter duration time.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            double distance = (int)distance_input.Value;
            if (distance == 0)
            {
                MessageBox.Show("Please Enter distance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            double speed = (int)speed_input.Value;
            if (speed == 0)
            {
                MessageBox.Show("Please Enter avarage.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // convert speed in km to m
            double speed_in_m = (speed * 1000) / 3600;
            double caloriesBurned = (( (0.035 * target.Current_weight) + (0.029 * speed_in_m * target.Current_weight)/0.1 ) / 60) * time;

            DateTime currentDateTime = DateTime.Today;
            string formattedDate = currentDateTime.ToString("yyyy-MM-dd");

            DialogResult result = MessageBox.Show("Calories burned = " + caloriesBurned.ToString("0.00") + ". Save the Data", "Confirmation", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                Acitivity act = new Acitivity(user, target);
                bool success = act.MakingActivity(caloriesBurned, this.name);
                if (success)
                {
                    this.Hide();
                }
            }
            else
            {
                return;
            }
        }

        private void form_close_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void GoToActivitiesMenu(object sender, EventArgs e)
        {
            ActivitiesMenu at = new ActivitiesMenu(user, target);
            at.Show();
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
