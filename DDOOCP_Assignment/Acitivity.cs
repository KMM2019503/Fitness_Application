using K4os.Compression.LZ4.Internal;
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
    public class Acitivity
    {
        private User user;
        private Target target;
        public Acitivity(User user, Target target)
        {
            this.user = user;
            this.target = target;
        }

        // This method mainly work for inserting data in database. If success return true.
        public bool MakingActivity(double caloriesBurned, string name)
        {
            DateTime currentDateTime = DateTime.Today;
            string formattedDate = currentDateTime.ToString("yyyy-MM-dd");
            string sql = "insert into histories (user_id, tarCalo_id , calories_burned,name,date) values (@user_id, @tarCalo_id , @cal_burned, @name , @date)";
            DatabaseConnection dc = new DatabaseConnection();
            using (MySqlCommand cmd = new MySqlCommand(sql, dc.con))
            {
                cmd.Parameters.AddWithValue("@user_id", this.user.Id);
                cmd.Parameters.AddWithValue("@tarCalo_id", this.target.Id);
                cmd.Parameters.AddWithValue("@cal_burned", caloriesBurned);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@date", formattedDate);

                try
                {
                    dc.con.Open();
                    cmd.ExecuteNonQuery();
                    target.CheckingStatus(target, caloriesBurned);
                    if (target.Success)
                    {
                        MessageBox.Show("Congraduration!! you have successful your target");
                        AdminDashboard ad = new AdminDashboard(user);
                        ad.Show();
                        
                    }
                    else
                    {
                        ActivitiesMenu actMenu = new ActivitiesMenu(user, target);
                        actMenu.Show();
                        
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error inserting into the database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                finally
                {
                    dc.con.Close();
                }
            }
        }
    }
}
