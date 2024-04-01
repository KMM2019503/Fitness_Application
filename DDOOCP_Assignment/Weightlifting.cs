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
    public partial class Weightlifting : Form
    {
        private User user;
        private Target target;
        private string name = "WeightLifting";
        public Weightlifting()
        {
            InitializeComponent();
        }
        public Weightlifting(User user, Target target) : this()
        {
            this.user = user;
            this.target = target;
            name_holder.Text = user.Name;
            weight_holder.Text = this.target.Current_weight.ToString();
            tar_cal_holder.Text = this.target.Target_calo.ToString();
        }
        
        

        private void cal_btn_Click_1(object sender, EventArgs e)
        {
            double sets = (int)sets_input.Value;
            if (sets == 0)
            {
                MessageBox.Show("Please Enter the number of sets.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            double reps = (int)reps_input.Value;
            if (reps == 0)
            {
                MessageBox.Show("Please Enter the number of reps.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            double weight = (int)weight_lifted_input.Value;
            if (weight == 0)
            {
                MessageBox.Show("Please Enter avarage.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            double caloriesBurned = ((weight * sets * reps) / 1000) * 44.184;

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

        private void logout_btn_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        

        private void GoToActivitiesMenu(object sender, EventArgs e)
        {
            ActivitiesMenu at = new ActivitiesMenu(user, target);
            at.Show();
            this.Hide();
        }
    }
}
