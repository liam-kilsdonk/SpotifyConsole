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

        private List<Nummer> nummers = new List<Nummer>();
        public List<Nummer> Nummers { get { return nummers; } }

        public PlayList(int Id, string Name) { 

            this.Id= Id;
            this.Name = Name;
        }

        //public void AddSongs(Nummer piet)
        //{
        //this.Nummers = new List<Nummer>();
        //this.Nummers.Add(piet);
        //}

        public void AddSongs(params Nummer[] songs)
        {
            nummers.AddRange(songs);
        }
    }
}
