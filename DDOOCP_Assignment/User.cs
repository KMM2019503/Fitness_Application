using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DDOOCP_Assignment
{
    public class User
    {
        private int _id;
        private string _name;
        

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        
        public User(int id, string name)
        {
            Id = id;
            Name = name;
        }

    }
}
