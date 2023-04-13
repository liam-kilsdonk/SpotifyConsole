using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyConsole
{
    internal class PlayList
    {
        private int id;
        public int Id { get { return id; } set { id = value; } }

        private string name;
        public string Name { get { return name; } set { name = value; } }

        private List<Nummer> Nummers { get; set; }

        public PlayList(int Id, string Name) { 

            this.Id= Id;
            this.Name = Name;
        }

        public void AddSongs(Nummer piet)
        {
            this.Nummers.Add(piet);
        }
    }
}
