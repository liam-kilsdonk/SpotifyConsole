using SpotifyConsole;
using System.Collections.Generic;

Nummer song1 = new Nummer(1, "HDMI", "BONES", "Rotten", "2014", 30.40);
Nummer song2 = new Nummer(2, "Bob marley", "Three Little Birds", "Exodus", "1977", 30.40);
Nummer song3 = new Nummer(3, "Ava Max", "Sweet but Psycho", "Heaven & Hell", "2020", 30.40);
Nummer song4 = new Nummer(4, "Ericdoa", "Fantasize", "Fantasize", "2021", 30.40);
Nummer song5 = new Nummer(5, "Pop Smoke", "Mood Swings", "Shoot for the Stars, Aim for the Moon", "2019", 30.40);

PlayList Liam = new PlayList(1, "Weekend");

Liam.AddSongs(song1, song2, song3, song4, song5);

List<PlayList> playlists = new List<PlayList>();

playlists.Add(Liam);

Console.WriteLine("<================================================>");
Console.WriteLine("Welkom bij Liam's Spotify Console aplicatie");
Console.WriteLine("1. Play Nummer\n\r" +
    "2. Speellijst zien\n\r" +
    "3. Vriendlijst zien\n\r" +
    "4. Album's zien\n\r" +
    "0. exit");
Console.WriteLine("<================================================>");

Console.WriteLine("Voer een [cijfer] in: ");
int userInput = Convert.ToInt32(Console.ReadLine());

switch (userInput)
{
    case 1:
        PlayNummer();
        break;
    case 2:
        ShowPlayList(playlists);
        break;
    case 3:
        ShowFriendList();
        break;
    case 4:
        ShowAlbumList();
        break;
    case 0:
        break;
}

static void PlayNummer()
{
    Console.WriteLine($"Songs in {Liam.Name} playlist:"); foreach (Nummer song in Liam.Nummers) { Console.WriteLine("{0}. {1} - {2} ({3})", song.Id, song.Title, song.Artist, song.Date); }
}

static void ShowPlayList(List<PlayList> playlists)
{
    Console.WriteLine("Playlists:");

    //List<PlayList> playlists
    foreach (PlayList playlist in playlists)
    {
        Console.WriteLine("{0}. {1}", playlist.Id, playlist.Name);
    }
}

static void ShowFriendList()
{
    //
}

static void ShowAlbumList()
{
    //
}