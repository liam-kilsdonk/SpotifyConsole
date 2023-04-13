using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyConsole
{
    internal class Album
    {
        private int id;
        public int Id { get { return id; } set { id = value; } }

        private string title;
        public string Title { get { return title; } set { title = value; } }

        private string artist;
        public string Artist { get { return artist; } set { artist = value; } }

        public List<Nummer> Nummers { get; set; }

        public Album()
        {
            Nummers= new List<Nummer>();
        }

        public static void MyAlbum()
        {
            List<Album> albums = new List<Album>();

            albums.Add(new Album { Id = 1, Title = "Sunshine", Artist = "Liam" });
        }
    }
}
