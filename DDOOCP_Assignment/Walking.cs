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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace DDOOCP_Assignment
{
    
    public partial class Walking : Form
    {
        private User user;
        private Target target;
        private string name = "walking";
       
        public Walking(User user, Target target)
        {
            InitializeComponent();
            this.user = user;
            this.target = target;
            name_holder.Text = user.Name;
            weight_holder.Text = this.target.Current_weight.ToString();
            tar_cal_holder.Text = this.target.Target_calo.ToString();
        }

        private void cal_btn_Click(object sender, EventArgs e)
        {
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

            double time = (int)time_input.Value;
            if (time == 0)
            {
                MessageBox.Show("Please Enter duration time.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            
            double caloriesBurned = MET * target.Current_weight * (time / 60);
            DialogResult result = MessageBox.Show("Calories burned = " + caloriesBurned.ToString("0.00") + ". Save the Data", "Confirmation", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                Acitivity act = new Acitivity(user, target);
                bool success = act.MakingActivity(caloriesBurned, this.name);
                if(success)
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
