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
    public partial class JumpRope : Form
    {
        User user;
        Target target;
        string name = "JumpRope";
        public JumpRope()
        {
            InitializeComponent();
        }
        public JumpRope(User user, Target target) : this()
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
            double jump_no = (int)jump_input.Value;
            if (jump_no == 0)
            {
                MessageBox.Show("Please Enter distance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double MET = 0;
            System.Windows.Forms.RadioButton selectedType = type.Controls.OfType<System.Windows.Forms.RadioButton>().FirstOrDefault(r => r.Checked);

            if (selectedType != null)
            {
                if (double.TryParse(selectedType.Tag.ToString(), out double metValue))
                {
                    MET = metValue;
                }
                else
                {
                    MessageBox.Show("Invalid MET value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Please select a type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double jump_rate = jump_no / time;
            double caloriesBurned = (time * MET * jump_rate * 55.43) / 60;

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
