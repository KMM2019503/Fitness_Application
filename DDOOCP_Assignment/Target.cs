using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DDOOCP_Assignment
{
    public class Target
    {
        private int id;
        private int target_num;
        private int user_id;
        private double current_weight;
        private double target_calo;
        private double burned_calo = 0.0;
        private bool success = false;
        private DateTime date;
        public Target()
        {

        }

        public Target(int id, int target_num, int user_id, double current_weight, double target_calo, bool success, DateTime date)
        {
            this.id = id;
            this.target_num = target_num;
            this.user_id = user_id;
            this.current_weight = current_weight;
            this.target_calo = target_calo;
            this.success = success;
            this.date = date;
        }

        public int Id { get => id; set => id = value; }
        public int Target_num { get => target_num; set => target_num = value; }
        public int User_id { get => user_id; set => user_id = value; }
        public double Current_weight { get => current_weight; set => current_weight = value; }
        public double Target_calo { get => target_calo; set => target_calo = value; }
        public bool Success { get => success; set => success = value; }
        public DateTime Date { get => date; set => date = value; }
        public double Burned_calo { get => burned_calo; set => burned_calo = value; }

        //This is target update class 
        public Target UpdateTarget(Target target)
        {
            DatabaseConnection dc = new DatabaseConnection();
            if (target.Burned_calo >= target.Target_calo)
            {
                target.Success = true;
            }
            string sql = "UPDATE targetCaloreis SET current_weight = @current_weight, target_cal = @target_cal, success = @success, burned_cal= @burned_cal, date = @date WHERE id = @id";
            using (MySqlCommand cmd = new MySqlCommand(sql, dc.con))
            {

                cmd.Parameters.AddWithValue("@current_weight", target.Current_weight);
                cmd.Parameters.AddWithValue("@target_cal", target.Target_calo);
                cmd.Parameters.AddWithValue("@success", target.Success);
                cmd.Parameters.AddWithValue("@date", target.Date);
                cmd.Parameters.AddWithValue("@burned_cal", target.Burned_calo);
                cmd.Parameters.AddWithValue("@id", target.Id);

                try
                {
                    dc.con.Open();
                    cmd.ExecuteNonQuery();
                    //MessageBox.Show("Target updated successfully");
                    return target;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating target: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return target;
                }
                finally
                {
                    dc.con.Close();
                }
            }
        }

        public Target CheckingStatus(Target target, double caloriesBurned)
        {
            target.Burned_calo += caloriesBurned;
            return target.UpdateTarget(target);

        }
    }
}
