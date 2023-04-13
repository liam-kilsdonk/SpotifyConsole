using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyConsole
{
    internal class Nummer
    {
        private int id;
        public int Id { get { return id; } set { id = value; } }

        private string title;
        public string Title { get { return title; } set { title = value; } }

        private string artist;
        public string Artist { get { return artist; } set { artist = value; } }

        private string album;
        public string Album { get { return album; } set { album = value; } }

        private string date;
        public string Date { get { return date; } set { date = value; } }

        private double duration;
        public double Duration { get { return duration; } set { duration = value; } }

        public Nummer(int Id, string Title, string Artiest, string Album, string Date, double Duration) { 

            this.Id = Id;
            this.Title = Title;
            this.Artist = Artiest;
            this.Album = Album;
            this.Date = Date;
            this.Duration = Duration;

        }
    }
}