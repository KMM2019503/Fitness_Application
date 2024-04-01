using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DDOOCP_Assignment
{
    internal class ActivitiesInsertion
    {
        User user;
        Target target;
        public ActivitiesInsertion(User user, Target target) {
            this.user = user;
            this.target = target;   
        }

        public bool InsertHistories (string name, double caloriesBurned)
        {
            DateTime currentDateTime = DateTime.Today;
            string formattedDate = currentDateTime.ToString("yyyy-MM-dd");
            DialogResult result = MessageBox.Show("Calories burned = " + caloriesBurned.ToString("0.00") + ". Save the Data", "Confirmation", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                string sql = "insert into histories (user_id, tarCalo_id , calories_burned,name,date) values (@user_id, @tarCalo_id , @cal_burned, @name , @date)";
                DatabaseConnection dc = new DatabaseConnection();
                using (MySqlCommand cmd = new MySqlCommand(sql, dc.con))
                {
                    cmd.Parameters.AddWithValue("@user_id", user.Id);
                    cmd.Parameters.AddWithValue("@tarCalo_id", target.Id);
                    cmd.Parameters.AddWithValue("@cal_burned", caloriesBurned);
                    cmd.Parameters.AddWithValue("@name", this.name);
                    cmd.Parameters.AddWithValue("@date", formattedDate);

                    try
                    {
                        dc.con.Open();
                        cmd.ExecuteNonQuery();
                        this.target.Burned_calo += caloriesBurned;
                        target = target.UpdateTarget(target);
                        if (target.Success)
                        {
                            MessageBox.Show("Congraduration!! you have successful your target");
                            AdminDashboard ad = new AdminDashboard(user);
                            ad.Show();
                            this.Hide();
                        }
                        else
                        {
                            Acitivities act = new Acitivities(user, target);
                            act.Show();
                            this.Hide();
                        }

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
    }
}
