using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyConsole
{
    internal class Users
    {
        private int id;
        public int Id { get { return id; } set { id = value; } }

        private string name;
        public string Name { get { return name; } set { name = value; } }

        public static void MyUsers() 
        { 
            List<Users> users = new List<Users>(); 

            users.Add(new Users { Name = "Liam Kilsdonk", Id = 1 });
            users.Add(new Users { Name = "Meneer Held", Id = 2 });
            users.Add(new Users { Name = "Luke Peters", Id = 3 });
            users.Add(new Users { Name = "Amber Opsteen", Id = 4 });
            users.Add(new Users { Name = "Daan Parker", Id = 5 }); 
        }
    }
}
