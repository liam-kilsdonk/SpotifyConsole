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


        private List<Album> albums = new List<Album>();
        public List<Album> Albums  { get { return albums; } }

        public Album(int Id, string Title, string Artiest)
        {
            this.Id = Id;
            this.Title = Title;
            this.Artist = Artiest;
        }

        public void AddAlbums(params Album[] album)
        {
            albums.AddRange(album);
        }
    }
}
