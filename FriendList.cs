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

        private string name;
        public string Name { get { return name; } set { name = value; } }

        private List<FriendList> friends = new List<FriendList>();
        public List<FriendList> Friends { get { return friends; } }

        public FriendList(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }

        public void AddFriends(params FriendList[] friend)
        {
            friends.AddRange(friend);
        }
    }
}
