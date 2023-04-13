using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyConsole
{
    internal class FriendList
    {
        private int id;
        public int Id { get { return id; } set { id = value; } }

        public static void MyFriend()
        {
            List<FriendList> friend = new List<FriendList>();

            friend.Add(new FriendList { Id = 1 });
        }
    }
}
