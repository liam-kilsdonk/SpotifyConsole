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

        private List<Nummer> playlist;
        public List<Nummer> Playlist { get { return playlist; } set { playlist = value; } }

        public Users(int id, string name)
        {
            this.id = id;
            this.name = name;
            this.playlist = new List<Nummer>();
        }

        public void AddSongToPlaylist(Nummer song)
        {
            playlist.Add(song);
            Console.WriteLine("Added song '{0} - {1}' to {2}'s playlist", song.Artist, song.Title, name);
        }

        public void DisplayPlaylist()
        {
            Console.WriteLine("{0}'s playlist:", name);
            foreach (Nummer song in playlist)
            {
                Console.WriteLine("- {0} - {1}", song.Artist, song.Title);
            }
        }

        public List<Nummer> ComparePlaylists(List<Nummer> myPlaylist)
        {
            List<Nummer> commonSongs = new List<Nummer>();
            foreach (Nummer song in myPlaylist)
            {
                if (playlist.Contains(song))
                {
                    commonSongs.Add(song);
                }
            }
            return commonSongs;
        }
    }
}
